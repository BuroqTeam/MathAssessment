using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject FinishButton;
    public ProgressKeySO ProgressSave;
    public ResultSO ResultSO;
    public GameObject NumberPrefab;
    public GameObject NumberParent;
    public UnityEvent NewQuestionEvent;
    public UnityEvent FinishEvent;

   
    public List<QuestionNumber> QuestionNumbers = new();
    
    public int CurrentQuestionNumber, MaximumQuestionNumber;
   
   
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

    public void CreateNumbers()
    {
       
        MaximumQuestionNumber = TestManager.Instance.ActivePatterns.Count;
        for (int i = 0; i < TestManager.Instance.ActivePatterns.Count; i++)
        {
            GameObject questionNumber = Instantiate(NumberPrefab, NumberParent.transform.position, Quaternion.identity);
            questionNumber.transform.SetParent(NumberParent.transform);
            questionNumber.transform.localScale = Vector3.one;
            questionNumber.GetComponent<QuestionNumber>().InitialCondition(i);
            QuestionNumbers.Add(questionNumber.GetComponent<QuestionNumber>());
        }
        TestManager.Instance.ActivePatterns[CurrentQuestionNumber].SetActive(true);
        NewQuestionEvent.Invoke();
        QuestionNumbers[0].PlayAnimation();
    }


  

    public void SetActiveNextQuestion()
    {
        NewQuestionEvent.Invoke();
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

    public void EnableFinishButton()
    {
        FinishButton.SetActive(true);
    }

    public void ClickFiishButton()
    {
        CalculateResult();
        UpdateProgress();
        FinishEvent.Invoke();
    }

}
