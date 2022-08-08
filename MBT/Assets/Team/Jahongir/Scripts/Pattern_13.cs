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

public class Pattern_13 : MonoBehaviour
{
    public GameObject PuzzleQuestion;
    public GameObject PuzzleAnswer;
    public TextAsset _currentJsonText;
    private bool _isTrue = true;
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
            if (i%2==0)
            {
                GameObject puzzle = Instantiate(PuzzleQuestion, transform.GetChild(0));
                puzzle.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_13Obj.options[i];
            }
            else
            {
                GameObject puzzle = Instantiate(PuzzleQuestion, transform.GetChild(1));
                puzzle.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_13Obj.options[i];
            }

        }
    }
}
[SerializeField]
public class Data_13
{
    public string title;
    public List<string> options;
}
