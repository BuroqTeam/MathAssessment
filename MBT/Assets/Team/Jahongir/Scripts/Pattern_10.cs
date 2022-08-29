using MBT.Extension;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Pattern_10 : GeneralTest 
{
    public GameEvent ActNext;
    public GameEvent DeactNext;
    public GameEvent FinishEvent;
    public GameEvent InvitePrefEvent;
    public GameEvent NotLocatedEvent;
    public SpriteCollectionSO SpriteCollectionSO;
    public TextAsset CurrentJsonText;
    public GameObject OptionPrefab;
    public GameObject Tile1Prefab;
    public GameObject Tile2Prefab;
    public List<GameObject> Tile1;
    private Sprite _spriteImage;
    bool _isTrue = true;
    Data_10 Pattern_10Obj = new();

    private void OnEnable()
    {
        if (_isTrue)
        {
            _isTrue = false;
            //CurrentJsonText = GetComponent<Pattern>().Json;
            ReadFromJson();
        }
        DisplayQuestion(Pattern_10Obj.title);
        if (ES3.Load<bool>("Pattern_10_Check"))
        {
            ActNext.Raise();
        }
        else
        {
            DeactNext.Raise();
        }
    }

    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(CurrentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_10");
        Pattern_10Obj = jo.ToObject<Data_10>();
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
            obj.transform.GetChild(2).GetComponent<Image>().sprite = _spriteImage;
            obj.transform.GetChild(1).GetComponent<TEXDraw>().text = " = " + Pattern_10Obj.options[i][1] + " " + Pattern_10Obj.options[i][2];
            obj.transform.GetChild(2).GetComponent<P10_ButtonControl>().Pattern10 = this;
            obj.transform.GetChild(2).GetComponent<P10_ButtonControl>().CanvasObj = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
            obj.transform.GetChild(2).GetComponent<P10_ButtonControl>().Value = Int32.Parse(Pattern_10Obj.options[i][1]);
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
                obj1.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                obj1.transform.GetChild(1).GetChild(0).gameObject.AddComponent<P10_ItemSlot>();
                obj1.transform.GetChild(1).gameObject.AddComponent<P10_ItemSlot>();
                obj1.transform.GetChild(1).gameObject.GetComponent<P10_ItemSlot>().Index = i;
                obj1.transform.GetChild(1).gameObject.GetComponent<P10_ItemSlot>().Pattern10 = this;

            }
        }
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

    public void Result()
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
