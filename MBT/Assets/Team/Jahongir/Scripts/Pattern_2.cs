using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_2 : GeneralTest
{
    public GameEvent FinishEvent;
    public GameObject Button;
    private TextAsset _currentJsonText;
    public int CorrectAnswerNumber = 0;
    public int SelectAnswerNumber = 0;
    public int ResultNumber = 0;
    bool _isTrue = true;
    public List<GameObject> Buttons = new();
    Data_2 Pattern_2Obj = new();

    private void OnEnable()
    {
        if (_isTrue)
        {
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;
            ReadFromJson();
        }
        DisplayQuestion(Pattern_2Obj.title);
    }
    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);      
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_2");
        Pattern_2Obj = jo.ToObject<Data_2>();
        CreatePrefabs();
    }

    public void CreatePrefabs()
    {
        if (Pattern_2Obj.options.Count % 4 == 0)
        {
            int x = -100, y = 110, w = 0;
            for (int i = 0; i < Pattern_2Obj.options.Count; i++)
            {
                if (i < Pattern_2Obj.options.Count / 2)
                {
                    GameObject button = Instantiate(Button, transform);
                    button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(x - ((Pattern_2Obj.options.Count / 4 - 1) - i) * 220, y, 0);
                    button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_2Obj.options[i];
                    button.GetComponent<P2_ButtonControl>().Pattern2 = this;
                    Buttons.Add(button);
                }
                else
                {
                    GameObject button = Instantiate(Button, transform);
                    button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(x - ((Pattern_2Obj.options.Count / 4 - 1) - w) * 220, -y, 0);
                    button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_2Obj.options[i];
                    button.GetComponent<P2_ButtonControl>().Pattern2 = this;
                    w++;
                    Buttons.Add(button);
                }
            }
        }
        else
        {
            int y = 110, q = 0;
            for (int i = 0; i < Pattern_2Obj.options.Count; i++)
            {
                if (i < Pattern_2Obj.options.Count / 2)
                {
                    GameObject button = Instantiate(Button, transform);
                    button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3((-(Pattern_2Obj.options.Count / 4) + i) * 220, y, 0);
                    button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_2Obj.options[i];
                    button.GetComponent<P2_ButtonControl>().Pattern2 = this;
                    Buttons.Add(button);
                }
                else
                {
                    GameObject button = Instantiate(Button, transform);
                    button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3((-(Pattern_2Obj.options.Count / 4) + q) * 220, -y, 0);
                    button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_2Obj.options[i];
                    button.GetComponent<P2_ButtonControl>().Pattern2 = this;
                    q++;
                    Buttons.Add(button);
                }
            }   
        }
    }
   
    public void CheckButton()
    {
        int a = 0;
        for (int i = 0; i < Buttons.Count; i++)
        {
            if (Buttons[i].GetComponent<P2_ButtonControl>().Select)
            {
                a++;
            }
        }
        if (a>0)
        {
            GetComponent<Pattern>().IsEdited = true;
        }
        else
        {
            GetComponent<Pattern>().IsEdited = false;
        }
        TestManager.Instance.CheckAllIsDone();
    }
    public void Check()
    {
        CheckButton();
        for (int i = 0; i < Buttons.Count; i++)
        {
            if (Buttons[i].GetComponent<P2_ButtonControl>().CorrectAnswer)
            {
                CorrectAnswerNumber++;
            }
            if (Buttons[i].GetComponent<P2_ButtonControl>().CorrectAnswer && Buttons[i].GetComponent<P2_ButtonControl>().Select)
            {
                ResultNumber++;
            }
            if (Buttons[i].GetComponent<P2_ButtonControl>().Select)
            {
                SelectAnswerNumber++;
            }

        }
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        if (CorrectAnswerNumber == ResultNumber && ResultNumber== SelectAnswerNumber)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
            CorrectAnswerNumber = 0;
            ResultNumber = 0;
            SelectAnswerNumber = 0;
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
            CorrectAnswerNumber = 0;
            ResultNumber = 0;
            SelectAnswerNumber = 0;
        }
        ES3.Save("ResultList", currentList);
    }
}


[SerializeField]
public class Data_2
{
    public string title;
    public List<string> options;
}
