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

public class Pattern_6 : TestManager
{
    public TextAsset CurrentJsonText;
    public PatternSO[] PaGroup;
    public DataBaseSO[] Groups;
    private DataBaseSO _jsCollectionSO;
    Data_6 Pattern_6Obj = new Data_6();

    private void Awake()
    {
       
    }

    private void OnEnable()
    {
        if (ES3.Load<string>("Subject").Equals("Algebra"))
        {
            PatternSO = PatternGroup[0];
            _jsCollectionSO = Group[0];
        }
        else
        {
            PatternSO = PatternGroup[1];
            _jsCollectionSO = Group[1];
        }
        CurrentJsonText = Mbt.GetDesiredData(_jsCollectionSO);
        ReadFromJson();
        DisplayQuestion(Pattern_6Obj.title);
    }

    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);

        //QuestionObj.GetComponent<TEXDraw>().text = Pattern5Obj.question.title;
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(CurrentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_6");
        Pattern_6Obj = jo.ToObject<Data_6>();
        transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_6Obj.problem[0];
    }
    public void Result()
    {
        if (transform.GetChild(1).GetChild(0).GetComponent<TEXDraw>().text == Pattern_6Obj.solution[0])
        {
            Debug.Log("Correct");
        }
    }
}

[SerializeField]
public class Data_6
{
    public string title;
    public List<string> problem;
    public List<string> solution;
}

