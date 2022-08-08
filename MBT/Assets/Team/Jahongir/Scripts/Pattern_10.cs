using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using MBT.Extension;
using System;
using UnityEngine.UI;

public class Pattern_10 : MonoBehaviour
{
    public SpriteCollectionSO SpriteCollectionSO;
    public TextAsset CurrentJsonText;
    public GameObject OptionPrefab;
    public GameObject Tile1Prefab;
    public GameObject Tile2Prefab;
    public List<GameObject> Tile1;
    private Sprite _spriteImage;
    Data_10 Pattern_10Obj = new();

    private void OnEnable()
    {
        //GetData();
        //JsonCollectionSO.DataBase.Clear();
        //CurrentJsonText = Mbt.GetDesiredJSONData(JsonCollectionSO);
        //ReadFromJson();
        //DisplayQuestion(Pattern_10Obj.title);
    }

    //public override void DisplayQuestion(string questionStr)
    //{
    //    base.DisplayQuestion(questionStr); // null        
    //}

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(CurrentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_10");
        Pattern_10Obj = jo.ToObject<Data_10>();
        Debug.Log(Pattern_10Obj);
        CreatePrefabs();
    }

    public void CreatePrefabs()
    {
        //This is for options
        for (int i = 0; i < Pattern_10Obj.options.Count; i++)
        {
            string str = Pattern_10Obj.options[i][0];
            _spriteImage = GetDesiredSprite(str, SpriteCollectionSO);
            GameObject obj = Instantiate(OptionPrefab, transform.GetChild(5).transform);
            obj.transform.GetChild(1).GetComponent<Image>().sprite = _spriteImage;
            obj.transform.GetChild(2).GetComponent<TEXDraw>().text = " = " + Pattern_10Obj.options[i][1] + " " + Pattern_10Obj.options[i][2];
            obj.transform.GetChild(1).GetComponent<P10_ButtonControl>().Pattern10 = this;
            obj.transform.GetChild(1).GetComponent<P10_ButtonControl>().Value = Int32.Parse(Pattern_10Obj.options[i][1]);
        }
        //This is for Table1
        for (int i = 0; i < Pattern_10Obj.statements[0].Count; i++)
            {
                GameObject obj1 = Instantiate(Tile1Prefab, transform.GetChild(0).transform);
                obj1.transform.GetChild(0).GetChild(0).GetComponent<TEXDraw>().text = Pattern_10Obj.statements[0][i];
                obj1.transform.GetChild(1).GetChild(0).GetComponent<TEXDraw>().text = Pattern_10Obj.statements[1][i];
                if (i == 0)
                {
                    obj1.transform.GetChild(0).GetChild(0).GetComponent<TEXDraw>().color = new Color32(0, 72, 124, 255);
                    obj1.transform.GetChild(1).GetChild(0).GetComponent<TEXDraw>().color = new Color32(0, 72, 124, 255);
                }
            }

        //This is for Table2
        for (int i = 0; i < Pattern_10Obj.statements[0].Count; i++)
        {
            GameObject obj1 = Instantiate(Tile2Prefab, transform.GetChild(1).transform);
            obj1.transform.GetChild(0).GetChild(0).GetComponent<TEXDraw>().text = Pattern_10Obj.statements[0][i];
            if (i == 0)
            {
                obj1.transform.GetChild(1).GetChild(0).GetComponent<TEXDraw>().text = Pattern_10Obj.statements[1][i];
                obj1.transform.GetChild(0).GetChild(0).GetComponent<TEXDraw>().color = new Color32(0, 72, 124, 255);
                obj1.transform.GetChild(1).GetChild(0).GetComponent<TEXDraw>().color = new Color32(0, 72, 124, 255);
            }
            else
            {
                Tile1.Add(obj1.transform.GetChild(1).gameObject);
            }
        }
        for (int i = 0; i < Tile1.Count; i++)
        {
            Destroy(Tile1[i].transform.GetChild(0));
        }
        

        ////This is for Grid1
        //for (int i = 0; i < Pattern_10Obj.statements.Count; i++)
        //{
        //    for (int j = 0; j < Pattern_10Obj.statements[i].Count; j++)
        //    {
        //        GameObject obj1 = Instantiate(Tile1Prefab, transform.GetChild(0).transform);
        //        obj1.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_10Obj.statements[i][j];
        //        if (j == 0)
        //        {
        //            obj1.transform.GetChild(0).GetComponent<TEXDraw>().color = new Color32(0, 72, 124, 255);
        //        }
        //    }
        //}
        ////This is for Grid2
        //transform.GetChild(1).GetComponent<GridLayoutGroup>().constraintCount = Pattern_10Obj.statements[0].Count;
        //for (int i = 0; i < Pattern_10Obj.statements[0].Count; i++)
        //{
        //    GameObject obj2 = Instantiate(Tile1Prefab, transform.GetChild(1).transform);
        //    obj2.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_10Obj.statements[0][i];
        //    if (i == 0)
        //    {
        //        obj2.transform.GetChild(0).GetComponent<TEXDraw>().color = new Color32(0, 72, 124, 255);
        //    }
        //}
        ////This is for Grid3
        //transform.GetChild(2).GetComponent<GridLayoutGroup>().constraintCount = Pattern_10Obj.statements[0].Count;
        //for (int i = 0; i < Pattern_10Obj.statements[1].Count; i++)
        //{
        //    GameObject obj3 = Instantiate(Tile2Prefab, transform.GetChild(2).transform);
        //    if (i == 0)
        //    {
        //        obj3.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_10Obj.statements[1][i];
        //        obj3.transform.GetChild(0).GetComponent<TEXDraw>().color = new Color32(0, 72, 124, 255);
        //    }
        //    else
        //    {
        //        Tile1.Add(obj3);
        //    }
        //}
        //Debug.Log(Tile1.Count);
        //transform.GetChild(2).transform.SetParent(transform.GetChild(1).transform);
    }

    public static Sprite GetDesiredSprite(string spriteAddress, SpriteCollectionSO spriteCollectionSO)
    {
        string[] splitedGroup = spriteAddress.Split("\\");
        string spriteName = splitedGroup[^1];
        splitedGroup = spriteName.Split(".");
        spriteName = splitedGroup[0];
        Debug.Log(spriteName);
        var desiredSprite = spriteCollectionSO.spriteGroup.Find(item => item.name == spriteName);
        return desiredSprite;
    }
}

[SerializeField]
public class Data_10
{
    public string title;
    public List<List<string>> statements;
    public List<List<string>> options;
}
