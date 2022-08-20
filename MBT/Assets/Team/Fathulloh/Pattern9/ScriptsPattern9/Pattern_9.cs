using Extension;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pattern_9 : GeneralTest
{    
    public GameEvent ActiveNext;
    public GameEvent DeactiveNext;
    public GameEvent FinishEvent;

    private TextAsset _currentJsonText;

    public GameObject ParentComparisonPrefab;
    public List<GameObject> ComparisonObjects;

    Data_9 Pattern_9Obj = new();    

    public TMP_Text TextForTranslating;
    float xPos, yDistance, xDistance;
    public int totalFullAns, totalCorrectAns;

    bool _isTrue = true;

    private void OnEnable()
    {
        if (ES3.Load<bool>("Pattern_9_Check"))
        {
            ActiveNext.Raise();
        }
        else
            DeactiveNext.Raise();

        if (_isTrue)
        {
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;
            
            ReadFromJson();
        }        

        DisplayQuestion(Pattern_9Obj.title);
    }


    //private void Awake()
    //{   // 4-bob 40-49    7-bob 50-59(49, 58),      8-bob 50-59
    //    //TestManager.Instance.PassToNextClicked += Check;

    //    //Mbt.SaveJsonPath("Pattern_9",8, 55);
    //    //ES3.Save<string>("LanguageKey", "Uzb");
    //    //ES3.Save<int>("ClassKey", 6);

    //    //JsonCollectionSO.DataBase.Clear();
    //    //CurrentJsonText = Mbt.GetDesiredData(JsonCollectionSONew);
    //    //ReadFromJson();
    //}



    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr); // null        
    }


    void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_9");
        Pattern_9Obj = jo.ToObject<Data_9>();
        CreatePrefabs();
    }


    void CreatePrefabs()
    {        
        int optionsCount = Pattern_9Obj.options.Count;
        /*Pattern_9Obj.options = */Pattern_9Obj.options.ShuffleList();

        xDistance = ParentComparisonPrefab.transform.GetChild(1).position.x - ParentComparisonPrefab.transform.GetChild(0).position.x ;
        xPos = xDistance - ParentComparisonPrefab.transform.GetChild(0).GetComponent<RectTransform>().rect.width;
        yDistance = xPos + ParentComparisonPrefab.transform.GetChild(0).GetComponent<RectTransform>().rect.height;
        //Debug.Log("xDistance = " + xDistance + " yDistance = " + yDistance);
        
        for (int i = 0; i < optionsCount; i++)
        {
            GameObject obj = Instantiate(ParentComparisonPrefab, this.transform);
            Vector3 oldPos = obj.transform.localPosition;
            obj.transform.localPosition = new Vector3(oldPos.x, oldPos.y + (float)(optionsCount - 1) / 2 * yDistance - yDistance * i, oldPos.z);
            
            //if (i != 0)             {
            //    obj.transform.localPosition = new Vector3(oldPos.x, oldPos.y - yDistance * i, oldPos.z);
            //}              
            ComparisonObjects.Add(obj);
        }

        WriteToPrefab();
    }


    void WriteToPrefab()
    {
        for (int i = 0; i < ComparisonObjects.Count; i++)
        {
            ComparisonObjects[i].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_9Obj.options[i].left;
            ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP9>().CorrectAnswer = Pattern_9Obj.options[i].sign.ToString();
            ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP9>().Pattern9 = this;
            ComparisonObjects[i].transform.GetChild(2).transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_9Obj.options[i].right;
        }
    }


    public void Check()
    {   
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");

        if (CurrentAnswerStatus)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
        }
        ES3.Save("ResultList", currentList);

        ES3.Save<bool>("Pattern_9_Check", true);
        //ActivateNext();
    }


    //void ActivateNext()
    //{
    //    int index = TestManager.Instance.ActivePatterns.FindIndex(o => o == gameObject);
    //    index++;
    //    TestManager.Instance.ActivePatterns[index].SetActive(true);
    //    gameObject.SetActive(false);
    //}


    public bool CurrentAnswerStatus;
    public int correctCount;
    public void CheckAllAnswers()
    {
        int n = Pattern_9Obj.options.Count;

        totalFullAns = 0;
        totalCorrectAns = 0;

        for (int i = 0; i < n; i++)
        {
            string currentAnswer = ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP9>().CurrentAnswer;
            string correctAnswer = ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP9>().CorrectAnswer;
            if (currentAnswer != null)
                totalFullAns++;
            if (correctAnswer == currentAnswer)
                totalCorrectAns++;
        }

        if (totalCorrectAns == n)        {
            //Debug.Log("Everything is true.");
            CurrentAnswerStatus = true;
        }
        else if (totalFullAns == n)        {
            //Debug.Log("Some thing is wrong.");
            CurrentAnswerStatus = false;
        }
        else
        {
            CurrentAnswerStatus = false;
        }

        correctCount = 0;
        for (int i = 0; i < Pattern_9Obj.options.Count; i++)
        {
            string currentAnswer = ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP9>().CurrentAnswer;
            if (currentAnswer.Length == 1)
            {
                correctCount++;
            }
        }

        if (correctCount == Pattern_9Obj.options.Count)
        {
            if (TestManager.Instance.CheckIsLast())            
                FinishEvent.Raise();            
            else            
                ActiveNext.Raise();
            
            //Debug.Log("ActiveNext.Raise()");
            ES3.Save<bool>("Pattern_9_Check", true);
        }
        else
        {
            DeactiveNext.Raise();
            //Debug.Log("DeactiveNext.Raise()");
            ES3.Save<bool>("Pattern_9_Check", false);
            GameManager.Instance.CurrentCircleObj.IsDone = false;
            GetComponent<Pattern>().IsStatus = false;
        }
    }


}


[SerializeField]
public class Data_9
{
    public string title;
    public List<Options_9> options = new();
}

[SerializeField]
public class Options_9
{
    public string left;
    public char sign;
    public string right;
}


