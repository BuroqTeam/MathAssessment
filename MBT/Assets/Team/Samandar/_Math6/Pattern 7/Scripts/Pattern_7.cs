using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pattern_7 : GeneralTest
{
    public TextAsset _jsonText;
    public GameEvent FinishButton;
    public GameEvent ActiveNext;
    public GameEvent DeactiveNext;
    public static Pattern_7 Instance;    
    public float width;
    public float height;
    public GameObject PenTool;
    public List<Button> Buttons = new();
    public Data_7 Data7 = new();
    public GameObject Line;
    public GameObject Dot;
    public GameObject DotPrefabs;
    public GameObject CellParent;
    public GameObject Cell;
    public GameObject Koordinata;
    GameObject CellInstanse;
    public float percentage;
    public List<CellPattern7> CellGroup = new();
    public List<GameObject> CellObj;
    public List<GameObject> CanvasOut;
    bool Yoqish;
    public bool _istrue = true;
    bool _isTrueOneTime = true;
    public PointsPattern7 Point;
    public CellPattern7 cellPattern7;
    public GameObject DotParent;
    public GameObject LineParent;
    public int BobID, QuestionID;
    public GameObject Question;
    public bool _click;
    private void Awake()
    {
        CellParent.GetComponent<CellParent>().Pattern_7 = this;
        percentage = Cell.transform.localScale.x;
        InstantiatePrefabs();
        DotPrefabs.GetComponent<PointsPattern7>().Pattern_7 = this;
        Instance = this;        
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_jsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_7");
        Data7 = jo.ToObject<Data_7>();
    }
    private void OnEnable()
    {
        if (ES3.Load<bool>("Pattern_7_Check"))
        {
            ActiveNext.Raise();
        }
        else
        {
            //DeactiveNext.Raise();
        }
        if (_istrue)
        {
            _istrue = false;
            _jsonText = GetComponent<Pattern>().Json;
            ReadFromJson();            
        }
        for (int i = 0; i < CanvasOut.Count; i++)
        {
            CanvasOut[i].SetActive(true);
        }
        DisplayQuestion(Data7.title);

    }

    void InstantiatePrefabs()
    {
        GameObject dot = Instantiate(Dot);
        GameObject line = Instantiate(Line);
        DotParent = dot;
        LineParent = line;
        GameObject obj = Instantiate(CellParent);
        CanvasOut.Add(dot);
        CanvasOut.Add(line);
        CanvasOut.Add(obj);
    }
    void Start()
    {
        CellPosition();
        //ReadFromJson();
    }

    public void Active()
    {
        if (_click)
        {
            if (TestManager.Instance.CheckIsLast())
            {
                FinishButton.Raise();
            }
            else
            {
                ActiveNext.Raise();
            }
            ES3.Save<bool>("Pattern_7_Check", true);
        }
    }
    public void CheckToolIsEnable()
    {
        int n = 0;
        foreach (Button btn in Buttons)
        {
            if (btn.GetComponent<ButtonClick>().IsEnable)
            {
                switch (n)
                {
                    case 0:
                        Debug.Log("1");
                        TurnOnTurnOf();
                        break;
                    case 1:
                        Debug.Log("2");
                        LineParentTurnOn();
                        break;
                    case 2:
                        Debug.Log("3");
                        OnDestroy();
                        break;                  
                }

            }           
            n++;
        }
    }
    private void OnDisable()
    {
        
        if (CanvasOut.Count > 0)
        {
            for (int i = 0; i < CanvasOut.Count; i++)
            {
                CanvasOut[i].SetActive(false);
            }

        }
    }
    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }
    public void TurnOnTurnOf()
    {
        
        Yoqish = Buttons[0].GetComponent<ButtonClick>().IsEnable;
        Buttons[2].GetComponent<Button>().interactable = false;
        if (Yoqish == true)
        {
            PenTool.SetActive(true);
        }            
    }
    void CellPosition()
    {
        GameObject obj = Instantiate(Koordinata);
        Koordinata.transform.position = PenTool.transform.position;
        CanvasOut.Add(obj);
    }
    public void LineParentTurnOn()
    {
        LineParent.transform.GetChild(0).gameObject.SetActive(true);
        LineParent.transform.GetChild(0).transform.GetComponent<LineRenderer>().loop = true;
        if (Buttons[0].GetComponent<ButtonClick>().IsEnable == false)
        {
            PenTool.SetActive(false);
        }
    }

    public void False()
    {
        if (LineParent.transform.childCount == 1)
        {
            _isTrueOneTime = false;
            LineParent.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void Check()
    {
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        //AnswerPattern_15._PattenBool = _pattenBool;
        //if (_pattenBool == true && _click == true)
        //{
        //    currentList[GetComponent<Pattern>().QuestionNumber] = true;
        //    Debug.Log("Corrent");
        //}
        //else
        //{
        //    currentList[GetComponent<Pattern>().QuestionNumber] = false;
        //    Debug.Log("Wrong");
        //}
        ES3.Save("ResultList", currentList);
        ES3.Save<bool>("Pattern_15_Check", true);

    }
    public void OnDestroy()
    {
        Destroy(LineParent.transform.GetChild(0).gameObject);
        for (int i = 0; i < DotParent.transform.childCount; i++)
        {
            Destroy(DotParent.transform.GetChild(i).gameObject);
        }
        Buttons[0].GetComponent<Button>().interactable = true;
        Buttons[1].GetComponent<Button>().interactable = false;
    }
    void Update()
    {
        if (_isTrueOneTime)
        {
           
        }
    }


}
[SerializeField]
public class Data_7
{
    public string title;
    public List<string> options;    
}