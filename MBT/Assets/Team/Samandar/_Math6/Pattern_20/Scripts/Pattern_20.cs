using DG.Tweening;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_20 : GeneralTest
{
    public GameEvent FinishButton;
    private TextAsset _jsonText;
    public GameObject PenTool;
    public GameObject PointPositions;
    public GameObject PointPosition;
    public GameObject Points;
    public GameObject Point;    
    public GameObject CellParent;
    public GameObject Cell;
    public GameObject Koordinata;
    public GameObject Y;
    public GameObject X;
    public List<char> AlphabetList;
    public GameObject PositionX;
    public List<GameObject> PointList;
    public List<GameObject> PointPositionList;
    public List<GameObject> CellObj;
    public List<GameObject> CanvasOut;
    public List<GameObject> PositionOut;
    public List<GameObject> DotsList = new();
    public List<CellPattern_20> CellGroup = new();
    public List<float> PositionOY;
    public List<string> NumbersList;
    public static Pattern_20 Instance;
    public float width;
    public float height;
    //bool Yoqish;
    public bool _istrue = true;
    //bool _isTrueOneTime = true;
    public bool _click;
    public Data_20 Data20 = new();
    public float percentage;
    public List<string> _pointData;


    private void Awake()
    {
        CellParent.GetComponent<CellParent_20>().Pattern_20 = this;
        percentage = Cell.transform.localScale.x;
        PointPositions.GetComponent<PointPositions>().Pattern_20 = this;
        Points.GetComponent<Points>().Pattern_20 = this;        
        Instance = this;
    }


    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_jsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_20");
        Data20 = jo.ToObject<Data_20>();
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
        DisplayQuestion(Data20.title);
    }


    void Start()
    {
        CellPosition();
        PosY();
        InstantiatePrefabs();
        //PointData();
        ReDotPositions();
        RePositions();

        for (int i = 0; i < PointList.Count; i++)
        {
            PointList[i].transform.GetComponent<PointsPattern_20>().Pattern_20 = this;
        }
        Main();
    }

    void Main()
    {
        for (int i = 0; i < Data20.options.Count; i++)
        {
            var likeName = Data20.options[i];
            likeName = likeName.Remove(0,1);
            
            if (likeName.Contains('('))
            {
                likeName = likeName.Replace("(", "");
            }
            if (likeName.Contains(')'))
            {
                likeName = likeName.Replace(")", "");
            }
            if (likeName.Contains(';'))
            {
                likeName = likeName.Replace(";", ",");
            }
            _pointData.Add(likeName);
        }        
    }

    void InstantiatePrefabs()
    {
        GameObject posX = Instantiate(PositionX);
        PositionOut.Add(posX);        
        GameObject obj = Instantiate(CellParent);
        CanvasOut.Add(obj);
    }

    void ReDotPositions()
    {        
        GameObject dotposition = Instantiate(PointPositions);
        CanvasOut.Add(dotposition);
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float offset = dotposition.GetComponent<SpriteRenderer>().sprite.bounds.size.x * 0.5f * 0.3f;
        pos = new Vector3(pos.x - (10 * offset), transform.position.y, 0);
        dotposition.transform.position = pos;
    }

    void RePositions()
    {
        GameObject dot = Instantiate(Points);
        CanvasOut.Add(dot);        
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float offset = dot.GetComponent<SpriteRenderer>().sprite.bounds.size.x * 0.5f * 0.3f;
        pos = new Vector3(pos.x - (50 * offset), transform.position.y, 0);
        dot.transform.position = pos;        
    }   

    public void XYPosition()
    {
        X.transform.position = new Vector3(CellObj[49].transform.position.x + CellObj[49].GetComponent<Transform>().localScale.x * 1.2f, CellObj[49].transform.position.y * 1.1f, 0);
        Y.transform.position = new Vector3(CellObj[94].transform.position.x, CellObj[94].transform.position.y + CellObj[94].GetComponent<Transform>().localScale.y, 0);
    }

    public void PosY()
    {
        float pos1 = PenTool.transform.position.y + 6 * percentage;
        for (int i = 0; i < 11; i++)
        {
            pos1 -= percentage;
            PositionOY.Add(pos1);
        }
    }

    public void Active()
    {
        if (_click)
        {
            ES3.Save<bool>("Pattern_20_Check", true);
        }
    }
   
    private void OnDisable()
    {
        if (CanvasOut.Count > 0)
        {
            for (int i = 0; i < CanvasOut.Count; i++)
            {
                if (CanvasOut[i] != null)
                {
                    CanvasOut[i].SetActive(false);
                }
            }
            for (int i = 0; i < PositionOut.Count; i++)
            {
                if (PositionOut[i] != null)
                {
                    PositionOut[i].SetActive(false);
                }
            }
        }
    }

    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }

    void CellPosition()
    {
        GameObject obj = Instantiate(Koordinata);
        obj.transform.position = new Vector3(PenTool.transform.position.x, PenTool.transform.position.y, -1);
        CanvasOut.Add(obj);
    }    

    public void Check()
    {
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        if(NumbersList.SequenceEqual(_pointData))
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
            Logging.Log("true");
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
            Logging.Log("false");
        }
        ES3.Save("ResultList", currentList);
        ES3.Save<bool>("Pattern_20_Check", true);
        GetComponent<Pattern>().IsEdited = true;
        TestManager.Instance.CheckAllIsDone();
    }
}

[SerializeField]
public class Data_20
{
    public string title;
    public List<string> options;
}