using DG.Tweening;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_10 : GeneralTest 
{
    public GameEvent FinishEvent;
    public SpriteCollectionSO SpriteCollectionSO;
    private TextAsset _currentJsonText;
    public GameObject OptionPrefab;
    public GameObject Tile1Prefab;
    public GameObject Tile2Prefab;
    public GameObject DeleteButton;
    public GameObject ReturnButton;
    public List<GameObject> Tile1;
    public List<GameObject> CollectedPrefabs;
    public bool CorrectPattern = false;
    private int _correctCount = 0;
    private Sprite _spriteImage;
    private float _resultNum = 0;
    bool _isTrue = true;
    Data_10 Pattern_10Obj = new();
    private GameObject _canvas;


    private void Awake()
    {
        _canvas = GameObject.FindGameObjectWithTag("Canvas").gameObject; 
        float result = (float)Screen.width / (float)Screen.height;
        if (result >= 2)
        {
            transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition = new Vector3(-287, 246);
        }
        else if (result > 1.5)
        {
            transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition = new Vector3(-165, 288);
            transform.GetChild(0).GetComponent<RectTransform>().offsetMin = new Vector2(25, 242-(485/2));
            transform.GetChild(0).GetComponent<RectTransform>().offsetMax = new Vector2(-1427, transform.GetChild(0).GetComponent<RectTransform>().offsetMin.y + 485f);
            transform.GetChild(1).GetComponent<RectTransform>().offsetMin = new Vector2(693, 242 - (485 / 2));
            transform.GetChild(1).GetComponent<RectTransform>().offsetMax = new Vector2(-250, transform.GetChild(0).GetComponent<RectTransform>().offsetMin.y + 485f);
        }
        else if (result < 1.5)
        {
            transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition = new Vector3(-165, 370);
            transform.GetChild(0).GetComponent<RectTransform>().offsetMin = new Vector2(30, 242 - (485 / 2));
            transform.GetChild(0).GetComponent<RectTransform>().offsetMax = new Vector2(-1153, transform.GetChild(0).GetComponent<RectTransform>().offsetMin.y + 485f);
            transform.GetChild(0).GetComponent<RectTransform>().DOScale(0.8f, 0);
            transform.GetChild(1).GetComponent<RectTransform>().offsetMin = new Vector2(505, 242 - (485 / 2));
            transform.GetChild(1).GetComponent<RectTransform>().offsetMax = new Vector2(-132, transform.GetChild(0).GetComponent<RectTransform>().offsetMin.y + 485f);
            transform.GetChild(1).GetComponent<RectTransform>().DOScale(0.8f, 0);
        }
    }

    private void OnEnable()
    {
        if (_isTrue)
        {
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;
            ReadFromJson();
        }
        DisplayQuestion(Pattern_10Obj.title);
    }

    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_10");
        Pattern_10Obj = jo.ToObject<Data_10>();
        CreatePrefabs();
    }

    public void CreatePrefabs()
    {
        transform.GetChild(3).GetChild(0).GetComponent<P10_ReturnControl>().Pattern10 = this;
        transform.GetChild(3).GetChild(1).GetComponent<P10_DeleteControl>().Pattern10 = this;
        //This is for options
        for (int i = 0; i < Pattern_10Obj.options.Count; i++)
        {
            string str = Pattern_10Obj.options[i][0];
            _spriteImage = GetDesiredSprite(str, SpriteCollectionSO);
            GameObject obj = Instantiate(OptionPrefab, transform.GetChild(2).transform);
            obj.transform.GetChild(2).GetComponent<Image>().sprite = _spriteImage;
            obj.transform.GetChild(1).GetComponent<TEXDraw>().text = " = " + Pattern_10Obj.options[i][1] + " " + Pattern_10Obj.options[i][2];
            obj.transform.GetChild(2).GetComponent<P10_ButtonControl>().Pattern10 = this;
            obj.transform.GetChild(2).GetComponent<P10_ButtonControl>().CanvasObj = _canvas;
            obj.transform.GetChild(2).GetComponent<P10_ButtonControl>().Value = float.Parse(Pattern_10Obj.options[i][1]);
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
                obj1.transform.GetChild(1).gameObject.GetComponent<P10_ItemSlot>().CollectedNumber = float.Parse(Pattern_10Obj.statements[1][i]);
            }
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


    //Bu Metod Noto‘gri joyga qo‘yilgan prefablarni uchirib beradi
    public void DeleteWrongPrefab()
    {
        for (int i = 0; i < transform.GetChild(2).childCount; i++)
        {
            if (transform.GetChild(2).GetChild(i).childCount > 3)
            {
                GameObject.Destroy(transform.GetChild(2).GetChild(i).GetChild(3).gameObject);
            }
        }
    }


    //Bu metod barcha joylangan prefablarni o‘chirib beradi
    public void DeleteButtonControl()
    {
        if (CorrectPattern)
        {  
            CorrectPattern = false;
        }
        for (int i = 0; i < Tile1.Count; i++)
        {
            for (int j = 1; j < Tile1[i].transform.childCount; j++)
            {
                GameObject.Destroy(Tile1[i].transform.GetChild(j).gameObject);
            }
        }
        for (int a = 0; a < CollectedPrefabs.Count; a++)
        {
            CollectedPrefabs.Clear();
        }
        GetComponent<Pattern>().IsEdited = false;
        TestManager.Instance.CheckAllIsDone();
    }


    //Bu metod 1 martalik orqaga qaytarish qismini bajarib beradi
    public void ReturnBUttonControl()
    {
        if (CollectedPrefabs.Count == 1)
        {
            GameObject.Destroy(CollectedPrefabs[CollectedPrefabs.Count - 1]);
            CollectedPrefabs.Remove(CollectedPrefabs[CollectedPrefabs.Count - 1]);
            GetComponent<Pattern>().IsEdited = false;
            TestManager.Instance.CheckAllIsDone();
        }
        else
        {
            if (CollectedPrefabs[CollectedPrefabs.Count - 1] .transform.parent.childCount > 9)
            {
                for (int i = 0; i < CollectedPrefabs[CollectedPrefabs.Count - 1].transform.parent.childCount; i++)
                {
                    CollectedPrefabs[CollectedPrefabs.Count - 1].transform.parent.GetChild(i).GetComponent<RectTransform>().localScale += new Vector3(0.1f, 0.1f, 0.1f);
                }
                CollectedPrefabs[CollectedPrefabs.Count - 1].transform.parent.GetComponent<HorizontalLayoutGroup>().spacing += 15;
            }
            GameObject.Destroy(CollectedPrefabs[CollectedPrefabs.Count - 1]);
            CollectedPrefabs.Remove(CollectedPrefabs[CollectedPrefabs.Count - 1]);
        }
    }


    // Bu metod To‘g‘ri yoki noto‘g‘ri bajarilganini tekshirib beradi
    public void Result()
    {
        int a = 0;
        for (int i = 0; i < Tile1.Count; i++)
        {
            if (Tile1[i].transform.childCount>1)
            {
                a++;
            }
        }

        if (a>0)
        {
            GetComponent<Pattern>().IsEdited = true;
        }
        else
        {
            GetComponent<Pattern>().IsEdited = false;
        }
        TestManager.Instance.CheckAllIsDone();
        for (int i = 0; i < Tile1.Count; i++)
        {
            for (int j = 1; j < Tile1[i].transform.childCount; j++)
            {
                _resultNum += Tile1[i].transform.GetChild(j).GetComponent<P10_ButtonControl>().Value;
            }

            if (Mathf.Approximately(_resultNum, Tile1[i].GetComponent<P10_ItemSlot>().CollectedNumber))
            {
                Debug.Log(_resultNum);
                _correctCount++;
            }
            _resultNum = 0;
        }
        Debug.Log(_correctCount);
    }
    public void Check()
    {
        
        if (_correctCount == Tile1.Count)
        {
            CorrectPattern = true;
        }
        else
        {
            CorrectPattern = false;
        }
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        if (CorrectPattern)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
            Debug.Log("Correct");
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
            Debug.Log("Wrong");
        }
        _correctCount = 0;
        ES3.Save("ResultList", currentList);
    }
}

[SerializeField]
public class Data_10
{
    public string title;
    public List<List<string>> statements;
    public List<List<string>> options;
}
