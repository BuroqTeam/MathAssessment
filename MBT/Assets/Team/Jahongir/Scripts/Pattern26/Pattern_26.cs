using Extension;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_26 : GeneralTest
{
    public GameEvent FinishEvent;

    private TextAsset _currentJsonText;

    Data_26 Pattern_26Obj = new();

    bool _isTrue = true;


    private void OnEnable()
    {
        if (_isTrue)
        {
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;

            ReadFromJson();
        }
        DisplayQuestion(Pattern_26Obj.title);
    }

    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr); // null        
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_26");
        Pattern_26Obj = jo.ToObject<Data_26>();
        CreatePrefabs();
    }

    public void CreatePrefabs()
    {
        int optionsCount = Pattern_26Obj.options.Count;
        Pattern_26Obj.options.ShuffleList();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[SerializeField]

public class Data_26
{
    public string title;
    public List<Options_26> options = new();
}

public class Options_26
{
    public string image1;
    public List<string> check;
    public string image2;
}