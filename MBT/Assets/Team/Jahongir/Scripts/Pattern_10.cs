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
    public GameObject Tile1Prefab;
    public GameObject Tile2Prefab;
    private Sprite _spriteImage;
    Data_10 Pattern_10Obj = new Data_10();
    


    private void Awake()
    {
        Mbt.SaveJsonPath("key", 0, 100);


        ES3.Save<string>("LanguageKey", "Class_6_Uzb");

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
        var jsonObj = JObject.Parse(CurrentJsonData.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "key");
        Pattern_10Obj = jo.ToObject<Data_10>();
        CreatePrefabs();
    }

    public void CreatePrefabs()
    {
        transform.GetChild(1).GetComponent<GridLayoutGroup>().constraintCount = Pattern_10Obj.statements[0].Count;
        //This is for options
        for (int i = 0; i < Pattern_10Obj.options.Count; i++)
        {
            string str = Pattern_10Obj.options[i][0];
            _spriteImage = Mbt.GetDesiredSprite(str, spriteCOllectionSO);
            GameObject obj = Instantiate(OptionPrefab, transform.GetChild(0).transform);
            obj.transform.GetChild(1).GetComponent<Image>().sprite = _spriteImage;
            obj.transform.GetChild(2).GetComponent<TEXDraw>().text = " = " + Pattern_10Obj.options[i][1] +" " + Pattern_10Obj.options[i][2];
        }
        //This is for Grid1
        for (int i = 0; i < Pattern_10Obj.statements.Count ; i++)
        {
            for (int j = 0; j < Pattern_10Obj.statements[i].Count; j++)
            {
                GameObject obj1 = Instantiate(Tile1Prefab, transform.GetChild(1).transform);
                obj1.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_10Obj.statements[i][j];
                if (j == 0)
                {
                    obj1.transform.GetChild(0).GetComponent<TEXDraw>().color = new Color32(0, 72, 124, 255);
                }
            }
        }
        //This is for Grid2
        transform.GetChild(2).GetComponent<GridLayoutGroup>().constraintCount = Pattern_10Obj.statements[0].Count;
        for (int i = 0; i < Pattern_10Obj.statements[0].Count; i++)
        {
            GameObject obj2 = Instantiate(Tile1Prefab, transform.GetChild(2).transform);
            obj2.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_10Obj.statements[0][i];
            if (i == 0)
            {
                obj2.transform.GetChild(0).GetComponent<TEXDraw>().color = new Color32(0, 72, 124, 255);
            }
        }
        //This is for Grid3
        transform.GetChild(3).GetComponent<GridLayoutGroup>().constraintCount = Pattern_10Obj.statements[0].Count;
        for (int i = 0; i < Pattern_10Obj.statements[1].Count; i++)
        {
            GameObject obj3 = Instantiate(Tile2Prefab, transform.GetChild(3).transform);
            if (i == 0)
            {
                obj3.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_10Obj.statements[1][i];
                obj3.transform.GetChild(0).GetComponent<TEXDraw>().color = new Color32(0, 72, 124, 255);
            }
        }
        transform.GetChild(3).transform.SetParent(transform.GetChild(2).transform);
    }
}

[SerializeField]
public class Data_10
{
    public string title;
    public List<List<string>> statements;
    public List<List<string>> options;
}
