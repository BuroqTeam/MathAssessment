using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using MBT.Extension;
using System;

public class Pattern_10 : TestManager
{
    public DataBaseSO DataBase;
    public TextAsset CurrentJsonData;

    private AssetReference _jsonData;

    Data_10 Pattern_10Obj = new Data_10();

    private void Awake()
    {
        Mbt.SaveJsonPath(0, 100  );


        ES3.Save<string>("LanguageKey", "Class_6_Uzb");


        ES3.Save<int>("ClassKey", 6);


        _jsonData = Mbt.GetDesiredJSON(DataBase);
        _jsonData.LoadAssetAsync<TextAsset>().Completed += DataBaseLoaded;
    }



    private void DataBaseLoaded(AsyncOperationHandle<TextAsset> obj)
    {
        CurrentJsonData = obj.Result;
    }

    private void OnEnable()
    {
        DisplayQuestion(Pattern_10Obj.title);
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(CurrentJsonData.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj);
        Pattern_10Obj = jo.ToObject<Data_10>();
    }

    public void CreatePrefab()
    {

    }
}

[SerializeField]
public class Data_10
{
    public string title;
    public List<List<string>> statements;
    public List<List<string>> options;
}
