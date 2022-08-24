using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_6 : GeneralTest
{
    public GameEvent ActNext;
    public GameEvent DeactNext;
    public GameEvent FinishEvent;
    private  TextAsset _currentJsonText;
    bool _isTrue = true;
    Data_6 Pattern_6Obj = new();
   
    private void OnEnable()
    {
        if (_isTrue)
        {
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;
            ReadFromJson();
        }
        DisplayQuestion(Pattern_6Obj.title);
        if (ES3.Load<bool>("Pattern_6_Check"))
        {
            ActNext.Raise();
        }
        else
        {
            DeactNext.Raise();
        }
    }
    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_6");
        Pattern_6Obj = jo.ToObject<Data_6>();
        transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_6Obj.problem[0];
    }
    public void Result()
    {
        if (transform.GetChild(1).GetChild(0).GetComponent<TEXDraw>().text == Pattern_6Obj.solution[0])
        {
            
        }
    }
    public void Check()
    {
        Result();
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        if (transform.GetChild(1).GetChild(0).GetComponent<TEXDraw>().text == Pattern_6Obj.solution[0])
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
            Debug.Log("Correct");
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
            Debug.Log("Wrong");
        }
        ES3.Save("ResultList", currentList);
        ES3.Save<bool>("Pattern_6_Check", true);
    }
}

[SerializeField]
public class Data_6
{
    public string title;
    public List<string> problem;
    public List<string> solution;
}

