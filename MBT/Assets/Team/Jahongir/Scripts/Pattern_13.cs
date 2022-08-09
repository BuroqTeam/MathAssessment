using Extension;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_13 : GeneralTest
{
    public GameObject PuzzleQuestion;
    public GameObject PuzzleAnswer;
    private TextAsset _currentJsonText;
    public List<GameObject> QuestionPuzles = new();
    public List<GameObject> AnswerPuzles = new();
    private bool _isTrue = true;
    private List<string> _question = new();
    private List<string> _answer = new();
    private int ResultNumber = 0;
    Data_13 Pattern_13Obj = new();

   
    private void OnEnable()
    {
        if (_isTrue)
        {
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;
            if (_currentJsonText != null)
            {
                Debug.Log(_currentJsonText.text);
            }
            else
            {
                Debug.Log("Not Found Data");
            }
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
    public void Result()
    {
        for (int i = 0; i < QuestionPuzles.Count; i++)
        {
            if (QuestionPuzles[i].GetComponent<P13_Puzzle1>().QuestionId == QuestionPuzles[i].GetComponent<P13_Puzzle1>().AttechedPuzzle.GetComponent<P13_Puzzle2>().AnswerId)
            {
                ResultNumber++;
            }
        }
        if (ResultNumber == QuestionPuzles.Count)
        {
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Wrong");
        }
    }
    public void Check()
    {
        Result();
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        if (ResultNumber == QuestionPuzles.Count)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
        }
        ES3.Save("myList", currentList);
        ActivateNext();
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
public class Data_13
{
    public string title;
    public List<string> options;
}
