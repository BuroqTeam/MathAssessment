using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_16 : GeneralTest
{
    public List<GameObject> ExistentPrefabs = new();
    public TextAsset _currentJsonText;
    bool _isTrue = true;
    Data_16 Pattern_16Obj = new();

    private void Awake()
    {
        Mbt.SaveJsonPath("Pattern_13", 0, 92);

        ES3.Save<string>("LanguageKey", "Uzb");

        ES3.Save<int>("ClassKey", 6);

    }

    private void OnEnable()
    {
        if (_isTrue)
        {
            _isTrue = false;
            //_currentJsonText = GetComponent<Pattern>().Json;
            ReadFromJson();
        }
        DisplayQuestion(Pattern_16Obj.title);
    }
    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }
    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_16");
        Pattern_16Obj = jo.ToObject<Data_16>();
        CreatePrefabs();
    }

    public void CreatePrefabs()
    {
        transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_16Obj.problem[0] + "  " + Pattern_16Obj.problem[1] + "  " + Pattern_16Obj.problem[2];
    }
}
[SerializeField]
public class Data_16
{
    public string title;
    public List<string> problem;
    public List<string> solution;
}

