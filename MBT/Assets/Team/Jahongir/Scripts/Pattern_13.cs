using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using MBT.Extension;
using System;
using Extension;

public class Pattern_13 : MonoBehaviour
{
    public GameObject PuzzleQuestion;
    public GameObject PuzzleAnswer;
    public TextAsset _currentJsonText;
    private bool _isTrue = true;
    private List<string> _question = new();
    private List<string> _answer = new();
    Data_13 Pattern_13Obj = new();

    private void Awake()
    {
        Mbt.SaveJsonPath("Pattern_13", 0, 72);

        ES3.Save<string>("LanguageKey", "Uzb");

        ES3.Save<int>("ClassKey", 6);
    }

    private void OnEnable()
    {
        if (_isTrue)
        {
            _isTrue = false;
            //_currentJsonText = GetComponent<Pattern>().Json;
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
            GameObject puzzle = Instantiate(PuzzleQuestion, transform.GetChild(0));
            puzzle.GetComponent<P13_Puzzle1>().QuestionId = _question[i].Remove(3, 5);
            puzzle.transform.GetChild(0).GetComponent<TEXDraw>().text = _question[i].Remove(0, 3);
            GameObject puzzle1 = Instantiate(PuzzleAnswer, transform.GetChild(1));
            puzzle1.GetComponent<P13_Puzzle2>().AnswerId = _question[i].Remove(3, 5);
            puzzle1.transform.GetChild(0).GetChild(0).GetComponent<TEXDraw>().text = _answer[i].Remove(0, 3);
        }
    }
}
[SerializeField]
public class Data_13
{
    public string title;
    public List<string> options;
}
