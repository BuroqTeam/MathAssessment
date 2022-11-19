using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_22 : GeneralTest
{
    public GameEvent FinishEvent;
    public TEXDraw AnswerText;
    private TextAsset _currentJsonText;
    bool _isTrue = true;
    Data_22 Pattern_6Obj = new();


    private void Start()
    {
        float result = (float)Screen.width / (float)Screen.height;
        if (result >= 2)
        {
            transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector3(810, 195);
            transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(1275, 150);

            //Debug.Log("2");
        }
        else if (result > 1.5)
        {
            transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector3(700, 210);
            transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(1050, 120);
        }
        else if (result < 1.5)
        {

        }
    }


    private void OnEnable()
    {
        if (_isTrue)
        {
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;
            ReadFromJson();
        }
        DisplayQuestion(Pattern_6Obj.title);
    }
    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_22");
        Pattern_6Obj = jo.ToObject<Data_22>();
        transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_6Obj.problem[0];
    }

    public void Check()
    {
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        if (transform.GetChild(1).GetChild(0).GetComponent<TEXDraw>().text == Pattern_6Obj.solution[0])
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
        }
        ES3.Save("ResultList", currentList);
    }

    public void AnswerDone()
    {
        if (AnswerText.text.Length != 0)
        {
            GetComponent<Pattern>().IsEdited = true;
        }
        else
        {
            GetComponent<Pattern>().IsEdited = false;
        }
        TestManager.Instance.CheckAllIsDone();
    }
}

[SerializeField]
public class Data_22
{
    public string title;
    public List<string> problem;
    public List<string> solution;
}

