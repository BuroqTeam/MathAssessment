using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using MBT.Extension;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_27 : GeneralTest
{
    public GameEvent FinishEvent;

    private TextAsset _currentJsonText;

    Data_27 Pattern_27Obj = new();

    

    public GameObject Prefab;

    public List<GameObject> Buttons_27;

    private Sprite _spriteImage;

    public SpriteCollectionSO SpriteCollectionSO;

    
    bool _isTrue = true;


    private void OnEnable()
    {
        if (_isTrue)
        {
            Debug.Log("11");
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;
            
            ReadFromJson();
        }
        Debug.Log(Pattern_27Obj.title);
        DisplayQuestion(Pattern_27Obj.title);
    }
    public override void DisplayQuestion(string questionStr)
    {
        Debug.Log("111");
        base.DisplayQuestion(questionStr);
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_27");
        Pattern_27Obj = jo.ToObject<Data_27>();
        CreatePrefabs();
    }

    public void CreatePrefabs()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject obj = Instantiate(Prefab, this.transform);
            obj.GetComponent<ButtonControl_27>().Pattern27 = this;
            string str = Pattern_27Obj.options[i];
            if (str.Contains('*'))
            {
                obj.GetComponent<ButtonControl_27>().Answer = true;
                str.Replace("[*]", "");
            }
            Debug.Log(str);
            _spriteImage = GetDesiredSprite(str, SpriteCollectionSO);
            obj.transform.GetChild(0).GetComponent<Image>().sprite = _spriteImage;
            Buttons_27.Add(obj);
        }
    }

    //Bu metod JSON dan keladigan sprite nomini ajratib spriteni topib beradi
    public static Sprite GetDesiredSprite(string spriteAddress, SpriteCollectionSO spriteCollectionSO)
    {
        string[] splitedGroup = spriteAddress.Split("\\");
        string spriteName = splitedGroup[^1];
        splitedGroup = spriteName.Split(".");
        spriteName = splitedGroup[0];
        var desiredSprite = spriteCollectionSO.spriteGroup.Find(item => item.name == spriteName);
        return desiredSprite;
    }

    public void BeforeSelect()
    {
        for (int i = 0; i < Buttons_27.Count; i++)
        {
            if (Buttons_27[i].GetComponent<ButtonControl_27>().Select)
            {
                Buttons_27[i].GetComponent<ButtonControl_27>().Select = false;
                Buttons_27[i].GetComponent<Image>().color = new Color32(255, 255, 255, 250);
            }
        }
        GetComponent<Pattern>().IsEdited = true;
        TestManager.Instance.CheckAllIsDone();
    }

    public void Check()
    {
        TestManager.Instance.CheckAllIsDone();
        GetComponent<Pattern>().IsEdited = true;
        int a = 0;
        for (int i = 0; i < Buttons_27.Count; i++)
        {
            if (Buttons_27[i].GetComponent<ButtonControl_27>().Select && Buttons_27[i].GetComponent<ButtonControl_27>().Answer)
            {
                a++;
            }
        }
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        if (a>0)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
            GetComponent<Pattern>().IsEdited = true;
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
        }
        ES3.Save("ResultList", currentList);
    }
}

[SerializeField]
public class Data_27
{
    public string title;
    public List<string> options;
}
