using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_25 : GeneralTest
{
    public GameEvent FinishButton;
    private TextAsset _jsonText;
    public GameObject Dot;
    public GameObject DotPrefabs;
    public GameObject CellParent;
    public GameObject Cell;
    public GameObject Koordinata;
    public GameObject DotParent;
    public GameObject PenTool;
    public GameObject Y;
    public GameObject X;
    public GameObject PositionX;
    public List<GameObject> CellObj;
    public List<GameObject> CanvasOut;
    public List<GameObject> PositionOut;
    public List<GameObject> DotsList = new();
    public List<CellPattern_25> CellGroup = new();
    public List<float> PositionOY;
    public List<Button> Buttons = new();
    public List<string> NumberList;
    public static Pattern_25 Instance;
    public float width;
    public float height;
    bool Yoqish;
    public bool _istrue = true;
    //bool _isTrueOneTime = true;
    public bool _click;
    public Data_25 Data25 = new();
    public float percentage;


    private void Awake()
    {
        CellParent.GetComponent<CellParent_25>().Pattern_25 = this;
        percentage = Cell.transform.localScale.x;
        InstantiatePrefabs();
        DotPrefabs.GetComponent<PointsPattern_25>().Pattern_25 = this;
        Instance = this;
    }

    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_jsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_25");
        Data25 = jo.ToObject<Data_25>();
    }

    private void OnEnable()
    {        
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
        for (int i = 0; i < PositionOut.Count; i++)
        {
            PositionOut[i].SetActive(true);
        }
        DisplayQuestion(Data25.title);
    }


    void InstantiatePrefabs()
    {
        GameObject dot = Instantiate(Dot);
        GameObject posX = Instantiate(PositionX);
        PositionOut.Add(posX);
        DotParent = dot;
        GameObject obj = Instantiate(CellParent);
        CanvasOut.Add(dot);
        CanvasOut.Add(obj);
    }

    public void XYPosition()
    {
        X.transform.position = new Vector3(CellObj[49].transform.position.x + CellObj[49].GetComponent<Transform>().localScale.x * 1.2f, CellObj[49].transform.position.y * 1.1f, 0);
        Y.transform.position = new Vector3(CellObj[94].transform.position.x, CellObj[94].transform.position.y + CellObj[94].GetComponent<Transform>().localScale.y, 0);
    }

    public void PosY()
    {
        float pos1 = CanvasOut[2].transform.position.y + 6 * percentage;
        for (int i = 0; i < 11; i++)
        {
            pos1 -= percentage;
            PositionOY.Add(pos1);
        }
    }

    void Start()
    {
        CellPosition();
        PosY();
    }

    public void Active()
    {
        if (_click)
        {
            ES3.Save<bool>("Pattern_25_Check", true);
        }
    }

    public void CheckToolIsEnable()
    {
        int n = 0;
        foreach (Button btn in Buttons)
        {
            if (btn.GetComponent<ButtonClick_25>().IsEnable)
            {
                switch (n)
                {
                    case 0:
                        TurnOnTurnOf();
                        break;
                    case 1:
                        DestroyPointLine();
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
                if (CanvasOut[i] != null)                
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
        Yoqish = Buttons[0].GetComponent<ButtonClick_25>().IsEnable;
        Buttons[1].GetComponent<Button>().interactable = false;
        if (Yoqish == true)
        {
            PenTool.SetActive(true);
            PenTool.transform.GetChild(0).transform.gameObject.SetActive(true);
        }
    }


    void CellPosition()
    {
        GameObject obj = Instantiate(Koordinata);
        obj.transform.position = PenTool.transform.position;
        CanvasOut.Add(obj);
    }


    public void Check()
    {
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        List<string> options = Data25.options;

        for (int i = 0; i < options.Count; i++)        {
            //Debug.Log(options[i]);
        }

        for (int i = 0; i < NumberList.Count; i++)        {
            Debug.Log(NumberList[i] + "  options[0] " + options[0] + "  options.count = " + options.Count);
        }

        bool isEqual = NumberList.OrderBy(x => x).SequenceEqual(options.OrderBy(x => x));
        if (isEqual == true)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
            Debug.Log("correct");
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
            Debug.Log("wrong");
        }
        ES3.Save("ResultList", currentList);
        ES3.Save<bool>("Pattern_25_Check", true);
        GetComponent<Pattern>().IsEdited = true;
        TestManager.Instance.CheckAllIsDone();
    }


    public void DestroyPointLine()
    {
        DotsList.Clear();
        for (int i = 0; i < DotParent.transform.childCount; i++)
        {
            Destroy(DotParent.transform.GetChild(i).gameObject);
        }
        if (Buttons[0].GetComponent<ButtonClick_25>().IsEnable == false)
        {
            PenTool.SetActive(true);
            PenTool.transform.GetChild(0).transform.gameObject.SetActive(false);
        }
        Buttons[0].GetComponent<Button>().interactable = true;
        Buttons[1].GetComponent<Button>().interactable = false;
        NumberList.Clear();
        GetComponent<Pattern>().IsEdited = false;
        TestManager.Instance.CheckAllIsDone();
    }
    

}

[SerializeField]
public class Data_25
{
    public string title;
    public List<string> options;
}

