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
    Data_6 Pattern_6Obj = new Data_6();

    private void Awake()
    {
       
    }

    private void OnEnable()
    {
        GetData();
        JsonCollectionSO.DataBase.Clear();
        CurrentJsonText = Mbt.GetDesiredJSONData(JsonCollectionSO);
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

