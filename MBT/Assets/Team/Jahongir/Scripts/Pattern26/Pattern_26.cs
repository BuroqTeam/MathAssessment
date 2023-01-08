using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections;
using MBT.Extension;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_26 : GeneralTest
{
    public GameEvent FinishEvent;
    public GameObject P26_Prefab;
    public SpriteCollectionSO SpriteCollectionSO;
    public List<GameObject> ComparisonObjects;

    public bool CurrentAnswerStatus;
    public int correctCount;

    public int totalFullAns, totalCorrectAns;

    private TextAsset _currentJsonText;
    private Sprite _spriteImage;
    private Sprite _spriteImage1;

    Data_26 Pattern_26Obj = new();

    bool _isTrue = true;


    private void OnEnable()
    {
        if (_isTrue)
        {
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;

            ReadFromJson();
        }
        DisplayQuestion(Pattern_26Obj.title);
    }

    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr); // null        
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_26");
        Pattern_26Obj = jo.ToObject<Data_26>();
        CreatePrefabs();
    }

    public void CreatePrefabs()
    {
        //int optionsCount = Pattern_26Obj.options.Count;
        for (int i = 0; i < Pattern_26Obj.options.Count; i++)
        {
            GameObject obj = Instantiate(P26_Prefab, this.transform);
            string str = Pattern_26Obj.options[i][0];
            string str1 = Pattern_26Obj.options[i][Pattern_26Obj.options[i].Count-1];
            _spriteImage = GetDesiredSprite(str, SpriteCollectionSO);
            _spriteImage1 = GetDesiredSprite(str1, SpriteCollectionSO);
            obj.transform.GetChild(0).GetComponent<DropDownP26>().Pattern26 = this;
            for (int j = 1; j < Pattern_26Obj.options[i].Count - 1; j++)
            {
                if (Pattern_26Obj.options[i][j].Contains('*'))
                {
                    Pattern_26Obj.options[i][j] = Pattern_26Obj.options[i][j].Replace("[*]", "");
                    obj.transform.GetChild(0).GetComponent<DropDownP26>().CorrectAnswer = Pattern_26Obj.options[i][j];
                }
                obj.transform.GetChild(0).GetComponent<DropDownP26>().StrList.Add(Pattern_26Obj.options[i][j]);
            }
            obj.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = _spriteImage;
            obj.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = _spriteImage1;
            ComparisonObjects.Add(obj);
            Debug.Log(obj.transform.GetChild(0).GetComponent<DropDownP26>().StrList.Count);
        }

    }

    public void Check()
    {
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        if (CurrentAnswerStatus)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
            Debug.Log("true");
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
            Debug.Log("false");
        }
        ES3.Save("ResultList", currentList);
    }

    public void CheckAllAnswers()
    {
        PatternButtonBlue();
        int n = ComparisonObjects.Count;
        totalFullAns = 0;
        totalCorrectAns = 0;

        for (int i = 0; i < n; i++)
        {
            string currentAnswer = ComparisonObjects[i].transform.GetChild(0).GetComponent<DropDownP26>().CurrentAnswer;
            string correctAnswer = ComparisonObjects[i].transform.GetChild(0).GetComponent<DropDownP26>().CorrectAnswer;
            if (currentAnswer != null)
                totalFullAns++;
            if (correctAnswer == currentAnswer)
                totalCorrectAns++;
        }

        if (totalCorrectAns == n)
        {
            CurrentAnswerStatus = true;
        }
        else if (totalFullAns == n)
        {
            CurrentAnswerStatus = false;
        }
        else
        {
            CurrentAnswerStatus = false;
        }

        correctCount = 0;
        for (int i = 0; i < Pattern_26Obj.options.Count; i++)
        {
            if (ComparisonObjects[i].transform.GetChild(0).GetComponent<DropDownP26>().CurrentAnswer != Pattern_26Obj.options[i][0])
            {
                correctCount++;
            }
        }
    }

    public void PatternButtonBlue()        // Pattern scriptidagi isEdited ni true yoki false qilib beruvchi metod.
    {
        int fullDropDowns = 0;
        for (int i = 0; i < ComparisonObjects.Count; i++)
        {
            string currentAnswerStr = ComparisonObjects[i].transform.GetChild(0).GetComponent<DropDownP26>().CurrentAnswer;
            Debug.Log(ComparisonObjects[i].transform.GetChild(0).GetComponent<DropDownP26>().StrList[0]);
            if (currentAnswerStr != ComparisonObjects[i].transform.GetChild(0).GetComponent<DropDownP26>().StrList[0])
                fullDropDowns++;
            else ComparisonObjects[i].transform.GetChild(0).GetComponent<DropDownP26>().DropDownNonActive();
        }
        if (fullDropDowns > 0)
        {
            GetComponent<Pattern>().IsEdited = true;
            TestManager.Instance.CheckAllIsDone();
        }
        else
        {
            GetComponent<Pattern>().IsEdited = false;
            TestManager.Instance.CheckAllIsDone();
        }
    }

    public static Sprite GetDesiredSprite(string spriteAddress, SpriteCollectionSO spriteCollectionSO)
    {
        string[] splitedGroup = spriteAddress.Split("\\");
        string spriteName = splitedGroup[^1];
        splitedGroup = spriteName.Split(".");
        spriteName = splitedGroup[0];
        var desiredSprite = spriteCollectionSO.spriteGroup.Find(item => item.name == spriteName);
        return desiredSprite;
    }


}

[SerializeField]

public class Data_26
{
    public string title;
    public List<List<string>> options = new();
}