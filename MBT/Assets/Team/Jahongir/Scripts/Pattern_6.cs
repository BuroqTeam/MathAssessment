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
    public DataBaseSO DataBase;
    private AssetReference _jsonData;
    public TextAsset CurrentJsonText;
    Data_6 Pattern_6Obj = new Data_6();

    private void Awake()
    {
        //Mbt.SaveJsonPath(0, 50);
        //ES3.Save<string>("LanguageKey", "Class_6_Uzb");
        //ES3.Save<int>("ClassKey", 6);
        //_jsonData = Mbt.GetDesiredJSON(DataBase);
        //_jsonData.LoadAssetAsync<TextAsset>().Completed += DataBaseLoaded;
    }

    private void DataBaseLoaded(AsyncOperationHandle<TextAsset> obj)
    {
        CurrentJsonText = obj.Result;
        ReadFromJson();
    }

    private void Start()
    { 
        
    }
    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);

        //QuestionObj.GetComponent<TEXDraw>().text = Pattern5Obj.question.title;
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(CurrentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj);
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

