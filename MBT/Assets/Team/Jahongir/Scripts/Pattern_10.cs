using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using MBT.Extension;
using System;
using UnityEngine.UI;

public class Pattern_10 : TestManager
{
    public SpriteCollectionSO spriteCOllectionSO;
    public DataBaseSO DataBase;
    public TextAsset CurrentJsonText;
    public GameObject OptionPrefab;
    public Sprite SpriteName;
    Data_10 Pattern_10Obj = new Data_10();
    


    private void Awake()
    {
        //sp = Mbt.GetDesiredSprite("ss", spriteCOllectionSO);
        Mbt.SaveJsonPath(0, 62);

        ES3.Save<string>("LanguageKey", "Uzb");

        ES3.Save<int>("ClassKey", 6);

        CurrentJsonText = Mbt.GetDesiredJSONData(DataBase);

        ReadFromJson();
    }

    private void OnEnable()
    {
        DisplayQuestion(Pattern_10Obj.title);
    }

    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr); // null        
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(CurrentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj);
        Pattern_10Obj = jo.ToObject<Data_10>();
        CreatePrefabs();
    }

    public void CreatePrefabs()
    {
        string str = Pattern_10Obj.options[0][0];
        SpriteName = Mbt.GetDesiredSprite(str, spriteCOllectionSO);
        Debug.Log(SpriteName.name);
        for (int i = 0; i < Pattern_10Obj.options.Count; i++)
        {
            Instantiate(OptionPrefab, transform.GetChild(0).transform);
            //OptionPrefab.transform.GetChild(0).GetComponent<Image>()
            OptionPrefab.transform.GetChild(1).GetComponent<TEXDraw>().text = Pattern_10Obj.options[i][2];
            OptionPrefab.transform.GetChild(1).GetComponent<TEXDraw>().text = " " + Pattern_10Obj.options[i][1];
        }
        //Debug.Log(Pattern_10Obj.statements[0].Count);
    }




}

[SerializeField]
public class Data_10
{
    public string title;
    public List<List<string>> statements;
    public List<List<string>> options;
}
