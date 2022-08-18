using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public ProgressKeySO ProgressSave;
    public ResultSO ResultSO;
    public GameObject CirclePrefab;
    public GameObject CircleParent;
    public UnityEvent NewQuestionEvent;
    public UnityEvent FinishEvent;

    [HideInInspector]
    public List<Circle> CircleGroup = new();
    [HideInInspector]
    public int CurrentQuestionNumber, MaximumQuestionNumber;
    [HideInInspector]
    public Circle CurrentCircleObj;
    public static GameManager Instance;
    public int MaximumPatternNumber;

    private void Awake()
    {
        CreateSaveVariablesForCheck();
        Instance = this;
       

    }

    void CreateSaveVariablesForCheck()
    {
        for (int i = 1; i <= MaximumPatternNumber; i++)
        {
            ES3.Save<bool>("Pattern_" + i.ToString() + "_Check", false);
        }
    }

    public void CreateCircles()
    {
       
        MaximumQuestionNumber = TestManager.Instance.ActivePatterns.Count;
        for (int i = 0; i < TestManager.Instance.ActivePatterns.Count; i++)
        {
            GameObject circle = Instantiate(CirclePrefab, CircleParent.transform.position, Quaternion.identity);
            circle.transform.SetParent(CircleParent.transform);
            circle.transform.localScale = Vector3.one;
            circle.GetComponent<Circle>().InitialCondition(i);
            CircleGroup.Add(circle.GetComponent<Circle>());
        }
        UpdateTestView(0, false);
        
    }


    public void UpdateTestView(int circleIdentity, bool IsNext)
    {
        
        CircleGroup[CurrentQuestionNumber].MakeDone();
        CurrentQuestionNumber = circleIdentity;        
        CurrentCircleObj = CircleGroup[CurrentQuestionNumber];       
        CircleGroup[CurrentQuestionNumber].MakeActive();
        NewQuestionEvent.Invoke();

        if (IsNext)
        {
            SetActiveNextQuestion();
        }
        else
        {
            TestManager.Instance.ActivePatterns[CurrentQuestionNumber].SetActive(true);
        }
        
    }

    void SetActiveNextQuestion()
    {
        foreach (GameObject obj in TestManager.Instance.ActivePatterns)
        {
            if (obj.activeSelf)
            {
                
                if (!obj.Equals(TestManager.Instance.ActivePatterns[CurrentQuestionNumber]))
                {
                    TestManager.Instance.ActivePatterns[CurrentQuestionNumber].SetActive(true);
                    obj.SetActive(false);
                }                   
                break;
            }           
        }        
    }

    public void CalculateResult()
    {
        int correctVal=0, wrongVal=0;
        List<bool> resultList = new(ES3.Load<List<bool>>("ResultList"));
        for (int i = 0; i < resultList.Count; i++)
        {
            Debug.Log(resultList[i]);
            if (resultList[i])
            {
                correctVal++;
            }
            else
            {
                wrongVal++;
            }
        }
        
        ResultSO.Correct = correctVal;
        ResultSO.Wrong = wrongVal;
        ResultSO.Percentage = correctVal * 100 / resultList.Count;
    }

    public void UpdateProgress()
    {
        if (ES3.KeyExists(ProgressSave.Key + ES3.Load<string>("Subject") + ES3.Load<int>("ClassKey").ToString()))
        {
            int selectedChapter = ES3.Load<int>("Chapter");
            Dictionary<int, List<float>> dict = ES3.Load<Dictionary<int, List<float>>>(ProgressSave.Key + ES3.Load<string>("Subject") + ES3.Load<int>("ClassKey").ToString());
            List<float> list = dict.ElementAt(selectedChapter).Value;
            int selectedTestGroup = ES3.Load<int>("TestGroup") - 1;            
            list[selectedTestGroup] = ResultSO.Percentage;
            ES3.Save<Dictionary<int, List<float>>>(ProgressSave.Key + ES3.Load<string>("Subject") + ES3.Load<int>("ClassKey").ToString(), dict);

        }
        
    }

}
