using Extension;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_13 : GeneralTest
{
    public GameEvent ActNext;
    public GameEvent DeactNext;
    public GameObject PuzzleQuestion;
    public GameObject PuzzleAnswer;
    private TextAsset _currentJsonText;
    public List<GameObject> QuestionPuzles = new();
    public List<GameObject> AnswerPuzles = new();
    public List<GameObject> SelectedPuzles = new();
    private bool _isTrue = true;
    private List<string> _question = new();
    private List<string> _answer = new();
    Data_13 Pattern_13Obj = new();

   
    private void OnEnable()
    {
        if (_isTrue)
        {
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;
            ReadFromJson();
        }
        DisplayQuestion(Pattern_13Obj.title);
        if (ES3.Load<bool>("Pattern_13_Check"))
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
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_13");
        Pattern_13Obj = jo.ToObject<Data_13>();
        CreatePrefab();
    }
    public void CreatePrefab()
    {
        for (int i = 0; i < Pattern_13Obj.options.Count; i++)
        {
            if (i % 2 == 0)
            {
                _question.Add(Pattern_13Obj.options[i]);
            }
            else
            {
                _answer.Add(Pattern_13Obj.options[i]);
            }
        }
        _question = _question.ShuffleList();
        _answer = _answer.ShuffleList();

        for (int i = 0; i < Pattern_13Obj.options.Count / 2; i++)
        {
            GameObject puzzle = Instantiate(PuzzleQuestion, transform.GetChild(1));
            puzzle.GetComponent<P13_Puzzle1>().QuestionId = _question[i].Remove(3, _question[i].Length - 3);
            puzzle.transform.GetChild(1).GetChild(0).GetComponent<TEXDraw>().text = _question[i].Remove(0, 3);
            puzzle.GetComponent<P13_Puzzle1>().Pattern13 = this;
            QuestionPuzles.Add(puzzle);
            GameObject puzzle1 = Instantiate(PuzzleAnswer, transform.GetChild(0));
            puzzle1.GetComponent<P13_Puzzle2>().AnswerId = _answer[i].Remove(3, _answer[i].Length - 3);
            puzzle1.transform.GetChild(0).GetChild(0).GetComponent<TEXDraw>().text = _answer[i].Remove(0, 3);
            AnswerPuzles.Add(puzzle1);
        }
    }
    

    public void CheckButton()
    {
        if (SelectedPuzles.Count == QuestionPuzles.Count)
        {
            ActNext.Raise();
            ES3.Save<bool>("Pattern_13_Check", true);
        }
        else
        {
            DeactNext.Raise();
            ES3.Save<bool>("Pattern_13_Check", false);
            GameManager.Instance.CurrentCircleObj.IsDone = false;
        }
    }
    public void Check()
    {  
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        if (SelectedPuzles.Count == QuestionPuzles.Count)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
        }
        ES3.Save("myList", currentList);
        ES3.Save<bool>("Pattern_13_Check", true);
    }
}
[SerializeField]
public class Data_13
{
    public string title;
    public List<string> options;
}
