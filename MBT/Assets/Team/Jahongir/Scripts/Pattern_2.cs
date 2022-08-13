using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_2 : GeneralTest
{
    public GameEvent ActNext;
    public GameEvent DeactNext;
    public GameObject Button;
    private TextAsset _currentJsonText;
    private int CorrectAnswerNumber = 0;
    private int SelectAnswerNumber = 0;
    private int ResultNumber = 0;
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
        if (ES3.Load<bool>("Pattern_2_Check"))
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
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_2");
        Pattern_2Obj = jo.ToObject<Data_2>();
        CreatePrefabs();
    }

    public void CreatePrefabs()
    {
        if (Pattern_2Obj.options.Count % 4 == 0)
        {
            int x = -100, y = 100, w = 0;
            for (int i = 0; i < Pattern_2Obj.options.Count; i++)
            {
                if (i < Pattern_2Obj.options.Count / 2)
                {
                    GameObject button = Instantiate(Button, transform);
                    button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(x - ((Pattern_2Obj.options.Count / 4 - 1) - i) * 200, y, 0);
                    button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_2Obj.options[i];
                    button.GetComponent<P2_ButtonControl>().Pattern2 = this;
                    Buttons.Add(button);
                }
                else
                {
                    GameObject button = Instantiate(Button, transform);
                    button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(x - ((Pattern_2Obj.options.Count / 4 - 1) - w) * 200, -y, 0);
                    button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_2Obj.options[i];
                    button.GetComponent<P2_ButtonControl>().Pattern2 = this;
                    w++;
                    Buttons.Add(button);
                }
            }
        }
        else
        {
            int y = 100, q = 0;
            for (int i = 0; i < Pattern_2Obj.options.Count; i++)
            {
                if (i < Pattern_2Obj.options.Count / 2)
                {
                    GameObject button = Instantiate(Button, transform);
                    button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3((-(Pattern_2Obj.options.Count / 4) + i) * 200, y, 0);
                    button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_2Obj.options[i];
                    button.GetComponent<P2_ButtonControl>().Pattern2 = this;
                    Buttons.Add(button);
                }
                else
                {
                    GameObject button = Instantiate(Button, transform);
                    button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3((-(Pattern_2Obj.options.Count / 4) + q) * 200, -y, 0);
                    button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_2Obj.options[i];
                    button.GetComponent<P2_ButtonControl>().Pattern2 = this;
                    q++;
                    Buttons.Add(button);
                }
            }   
        }
    }
    public void Result()
    {
        for (int i = 0; i < Buttons.Count; i++)
        {
            if (Buttons[i].GetComponent<P2_ButtonControl>().CorrectAnswer)
            {
                CorrectAnswerNumber++;
            }
            if (Buttons[i].GetComponent<P2_ButtonControl>().Select)
            {
                SelectAnswerNumber++;
            }
            if (Buttons[i].GetComponent<P2_ButtonControl>().Select && Buttons[i].GetComponent<P2_ButtonControl>().CorrectAnswer)
            {
                ResultNumber++;
            }
        }
        if (CorrectAnswerNumber == SelectAnswerNumber && ResultNumber == SelectAnswerNumber)
        {
            Debug.Log("Correct");
            CorrectAnswerNumber = 0;
            SelectAnswerNumber = 0;
            ResultNumber = 0;
        }
        else
        {
            Debug.Log("Wrong");
            CorrectAnswerNumber = 0;
            SelectAnswerNumber = 0;
            ResultNumber = 0;
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
            ActNext.Raise();
            ES3.Save<bool>("Pattern_2_Check", true);
        }
        else
        {
            DeactNext.Raise();
            GameManager.Instance.CurrentCircleObj.IsDone = false;
            ES3.Save<bool>("Pattern_2_Check", false);
            GameManager.Instance.CurrentCircleObj.IsDone = false;
            GetComponent<Pattern>().IsStatus = false;
        }
    }
    public void Check()
    {
        Result();
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        if (CorrectAnswerNumber == SelectAnswerNumber && ResultNumber == SelectAnswerNumber)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
        }
        ES3.Save("myList", currentList);
        ES3.Save<bool>("Pattern_2_Check", true);
    }

    void ActivateNext()
    {
        int index = TestManager.Instance.ActivePatterns.FindIndex(o => o == gameObject);
        index++;
        TestManager.Instance.ActivePatterns[index].SetActive(true);
        gameObject.SetActive(false);
    }


}


[SerializeField]
public class Data_2
{
    public string title;
    public List<string> options;
}
