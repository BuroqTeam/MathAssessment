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
    public TextAsset CurrentJsonText;
    Data_10 Pattern_10Obj = new Data_10();

    private void Awake()
    {
        Mbt.SaveJsonPath(0, 72);

        ES3.Save<string>("LanguageKey", "Uzb");

        ES3.Save<int>("ClassKey", 6);

        Tekshir();
    }

    private void Tekshir()
    {
        DataBase.CreateDict();
        TextAsset TextAsset = new TextAsset();
        string currentLanguage = ES3.Load<string>("LanguageKey");
        int currentClass = ES3.Load<int>("ClassKey");
        Dictionary<int, List<TextAsset>> JsonDictionary = new Dictionary<int, List<TextAsset>>();
        JsonDictionary = DataBase.DataBase;
        List<TextAsset> list = new List<TextAsset>();
        if (JsonDictionary.TryGetValue(currentClass, out list))
        {
            foreach (TextAsset txtAsset in list)
            {
                if (txtAsset.name.Equals(currentLanguage))
                {
                    TextAsset = txtAsset;
                }
            }
        }
        CurrentJsonText = TextAsset;
        ReadJson();
    }

    private void OnEnable()
    {
        DisplayQuestion(Pattern_10Obj.title);
    }

    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr); // null        
    }

    public void ReadJson()
    {
        var jsonObj = JObject.Parse(CurrentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj);
        Pattern_10Obj = jo.ToObject<Data_10>();
        CreatePrefabs();
    }

    public void CreatePrefabs()
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
