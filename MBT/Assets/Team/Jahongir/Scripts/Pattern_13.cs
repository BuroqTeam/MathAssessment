using Extension;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_13 : GeneralTest
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

        }
        else
        {
            
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
        if (SelectedPuzles.Count > 0)
        {
            //if (TestManager.Instance.CheckIsLast())
            //{
            //    FinishEvent.Raise();
            //}
            //else
            //{
                
            //}
            //ES3.Save<bool>("Pattern_13_Check", true);
            GetComponent<Pattern>().IsEdited = true;
        }
        else
        {
            //ES3.Save<bool>("Pattern_13_Check", false);
            GetComponent<Pattern>().IsEdited = false;
        }
    }
    public void Check()
    {
        if (SelectedPuzles.Count == AnswerPuzles.Count)
        {
            for (int i = 0; i < QuestionPuzles.Count; i++)
            {
                if (QuestionPuzles[i].GetComponent<P13_Puzzle1>().QuestionId == QuestionPuzles[i].GetComponent<P13_Puzzle1>().AttechedPuzzle.GetComponent<P13_Puzzle2>().AnswerId)
                {
                    _resultNumber++;
                }
            }
            List<bool> currentList = new();
            currentList = ES3.Load<List<bool>>("ResultList");
            Debug.Log(_resultNumber);
            Debug.Log(QuestionPuzles.Count);
            if (_resultNumber == QuestionPuzles.Count)
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
            ES3.Save<bool>("Pattern_13_Check", true);
        }
        else
        {
            Debug.Log("Wrong");
        }
        
    } 
}
[SerializeField]
public class Data_13
{
    public string title;
    public List<string> options;
}
