using Extension;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_21 : GeneralTest
{
    public GameEvent FinishEvent;
    public GameObject PuzzleQuestion;
    public GameObject PuzzleAnswer;
    private int _resultNumber = 0;
    private TextAsset _currentJsonText;
    public List<GameObject> QuestionPuzles = new();
    public List<GameObject> AnswerPuzles = new();
    public List<GameObject> SelectedPuzles = new();
    private bool _isTrue = true;
    private List<string> _question = new();
    private List<string> _answer = new();
    Data_21 Pattern_13Obj = new();


    private void OnEnable()
    {
        if (_isTrue)
        {
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;
            ReadFromJson();
        }
        DisplayQuestion(Pattern_13Obj.title);
    }

    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_21");
        Pattern_13Obj = jo.ToObject<Data_21>();
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
            puzzle.GetComponent<P21_Puzzle1>().QuestionId = _question[i].Remove(3, _question[i].Length - 3);
            puzzle.transform.GetChild(1).GetChild(0).GetComponent<TEXDraw>().text = _question[i].Remove(0, 3);
            puzzle.GetComponent<P21_Puzzle1>().Pattern13 = this;
            QuestionPuzles.Add(puzzle);
            GameObject puzzle1 = Instantiate(PuzzleAnswer, transform.GetChild(0));
            puzzle1.GetComponent<P21_Puzzle2>().AnswerId = _answer[i].Remove(3, _answer[i].Length - 3);
            puzzle1.transform.GetChild(0).GetChild(0).GetComponent<TEXDraw>().text = _answer[i].Remove(0, 3);
            AnswerPuzles.Add(puzzle1);
        }
    }


    public void CheckButton()
    {
        if (SelectedPuzles.Count > 0)
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
        List<bool> currentList = new();
        if (SelectedPuzles.Count == AnswerPuzles.Count)
        {
            for (int i = 0; i < QuestionPuzles.Count; i++)
            {
                if (QuestionPuzles[i].GetComponent<P21_Puzzle1>().QuestionId == QuestionPuzles[i].GetComponent<P21_Puzzle1>().AttechedPuzzle.GetComponent<P21_Puzzle2>().AnswerId)
                {
                    _resultNumber++;
                }
            }
            currentList = ES3.Load<List<bool>>("ResultList");
            if (_resultNumber == QuestionPuzles.Count)
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
            }
            ES3.Save("ResultList", currentList);
        }
        else
        {
            currentList = ES3.Load<List<bool>>("ResultList");
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
        }
        _resultNumber = 0;
    }
}
[SerializeField]
public class Data_21
{
    public string title;
    public List<string> options;
}
