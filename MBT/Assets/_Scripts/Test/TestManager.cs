using MBT.Extension;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    public GameObject CircleParent;
    public GameObject CirclePrefab;
    public Button NextButton;
    public TEXDraw QuestionText;
    public GameObject PatternParent;       
    public PatternSO[] PatternGroup;
    public DataBaseSO[] Group;
    public event Action PassToNextClicked;

    [HideInInspector]
    public List<Button> CircleButtons = new();

    protected PatternSO PatternSO;
    protected DataBaseSO JsonCollectionSO;

    private readonly List<GameObject> _activePatterns = new();
    private TextAsset _curentJson;
    private int _numberOfQuestions;
    private JObject _jo;

    private const string subjectKey = "Subject", testGroupKey = "TestGroup", 
        subject = "Algebra", chapterKey = "Chapter", jQuestionsPath = "questions", jPatternPath = "pattern", jChaptersPath = "chapters";


    public static TestManager Instance;
    

    private void Awake()
    {
        Instance = this;
        NextButton.onClick.AddListener(TaskOnClick);
        GetComponent<GeneralTest>().QuestionText = QuestionText;
        GetData();       
    }

    void GetData()
    {
        if (ES3.Load<string>(subjectKey).Equals(subject))
        {
            PatternSO = PatternGroup[0];
            JsonCollectionSO = Group[0];
        }
        else
        {
            PatternSO = PatternGroup[1];
            JsonCollectionSO = Group[1];
        }
        CountNumberOfQuestions();
    }

    void CountNumberOfQuestions()
    {      
        _curentJson = Mbt.GetDesiredJSONData(JsonCollectionSO);
        JsonCollectionSO.DataBase.Clear();
        _jo = JObject.Parse(_curentJson.text);
        JArray questions = (JArray)_jo[jChaptersPath][ES3.Load<int>(chapterKey)][jQuestionsPath];
        IList<Question> questionGroup = questions.ToObject<IList<Question>>();

        string sample = questionGroup[0].pattern;
        _numberOfQuestions = 0;
        for (int i = 0; i < questionGroup.Count; i++)
        {            
            if (sample.Equals(questionGroup[i].pattern))
            {
                _numberOfQuestions++;
            }
        }
        GenerateQuestionIndexList();        
    }

    void GenerateQuestionIndexList()
    {        
        List<JObject> jsonList = new();
        int k = ES3.Load<int>(testGroupKey);
        k--;
        List<int> questionIndexList = new ();
        for (int i = 0; i < _numberOfQuestions; i++)
        {
            JObject singleQuestion = (JObject)_jo[jChaptersPath][ES3.Load<int>(chapterKey)][jQuestionsPath][k];
            questionIndexList.Add(k);
            jsonList.Add(singleQuestion);
            k += _numberOfQuestions;
        }
        CreateExistedPatterns(jsonList, questionIndexList);
    }
   
    void CreateExistedPatterns(List<JObject> jsonList, List<int> questionIndexList)
    {       
        int index = 0, questionNum = 0;
        foreach (GameObject pattern in PatternSO.PatternPrefabs)
        {
            pattern.GetComponent<Pattern>().Json = _curentJson;
            foreach (JObject jObj in jsonList)
            {
                if (pattern.GetComponent<Pattern>().PatternID.Equals(jObj[jPatternPath].ToString()))
                {                    
                    Mbt.SaveJsonPath(
                        "Pattern_" + pattern.GetComponent<Pattern>().PatternID,
                        ES3.Load<int>(chapterKey), 
                        questionIndexList[index]);

                    if (pattern.GetComponent<Pattern>().IsAvailable)
                    {
                        GameObject obj = Instantiate(pattern);                        
                        obj.GetComponent<Pattern>().QuestionNumber = questionNum;
                        obj.transform.SetParent(PatternParent.transform);
                        obj.transform.localScale = Vector3.one;
                        obj.SetActive(false);
                        StreatchObj(obj);
                        _activePatterns.Add(obj);

                        GameObject circleButton = Instantiate(CirclePrefab, CircleParent.transform);
                        circleButton.transform.SetParent(CircleParent.transform);
                        circleButton.transform.localScale = Vector3.one;
                        circleButton.GetComponent<CircleButton>().InitialCondition(questionNum, CircleParent);
                        CircleButtons.Add(circleButton.GetComponent<Button>());                        
                        questionNum++;                        
                    }                    
                    index++;
                }
            }
        }        
        _activePatterns[0].SetActive(true);
        SetCircles();
    }

    void StreatchObj(GameObject obj)
    {
        obj.GetComponent<RectTransform>().anchorMin = new(0, 0);
        obj.GetComponent<RectTransform>().anchorMax = new(1, 1);

        obj.GetComponent<RectTransform>().offsetMin = new(0, 0);
        obj.GetComponent<RectTransform>().offsetMax = new(0, 0);
    }

    void SetCircles()
    {
        foreach (Button btn in CircleButtons)
        {
            btn.GetComponent<CircleButton>().CollectCircles();
        }


    }

    void TaskOnClick()
    {
        PassToNextClicked?.Invoke();
    }

    


}
