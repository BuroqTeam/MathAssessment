using DG.Tweening;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_18 : GeneralTest
{
    private TextAsset _jsonText;
    public GameObject CellParent;
    public GameObject Cell;
    public GameObject Koordinata;
    public GameObject PenTool;
    public GameObject Y;
    public GameObject X;
    public GameObject PositionX;
    public List<Button> Choraklar;
    public string chorak;
    public string ChorakNumber;
    public List<GameObject> CellObj;
    public List<GameObject> CanvasOut;
    public List<CellPattern_18> CellGroup = new();
    public List<float> PositionOY;
    public List<Button> Buttons = new();
    public List<string> NumberList;
    public static Pattern_18 Instance;
    public float width;
    public float height;
    public bool _istrue = true;
    public bool _click;
    public Data_18 Data18 = new();
    public float percentage;
    private void Awake()
    {
        CellParent.GetComponent<CellParent_18>().Pattern_18 = this;
        percentage = Cell.transform.localScale.x;
        InstantiatePrefabs();
        Instance = this;
        chorak = 1.ToString();
    }
    public void Check() 
    {
        GetComponent<Pattern>().IsEdited = true;
        //TestManager.Instance.CheckAllIsDone();
        chorak = Data18.options;
        chorak = 1.ToString();
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");

        if (chorak == ChorakNumber)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
            Debug.Log("correct");
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
            Debug.Log("Wrong");
        }
        ES3.Save("ResultList", currentList);
    }
    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_jsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj,"Pattern_18");
        Data18 = jo.ToObject<Data_18>();
    }
    private void OnEnable()
    {
        if (ES3.Load<bool>("Pattern_18_Check"))
        {

        }
        else
        {

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
        //for (int i = 0; i < PositionOut.Count; i++)
        //{
        //    PositionOut[i].SetActive(true);
        //}
        //DisplayQuestion(Data18.title);

    }

    void InstantiatePrefabs()
    {        
        GameObject obj = Instantiate(CellParent);
        CanvasOut.Add(obj);
    }
    public void XYPosition()
    {
        X.transform.position = new Vector3(CellObj[49].transform.position.x + CellObj[49].GetComponent<Transform>().localScale.x * 1.2f, CellObj[49].transform.position.y * 1.1f, 0);
        Y.transform.position = new Vector3(CellObj[94].transform.position.x, CellObj[94].transform.position.y + CellObj[94].GetComponent<Transform>().localScale.y, 0);
    }
    public void PosY()
    {
        float pos1 = CanvasOut[0].transform.position.y - 6 * percentage;
        for (int i = 0; i < 11; i++)
        {
            pos1 += percentage;
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
           ES3.Save<bool>("Pattern_18_Check", true);
        }
    }
    
    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }

    void CellPosition()
    {
        GameObject obj = Instantiate(Koordinata);
        obj.transform.position = PenTool.transform.position;
        CanvasOut.Add(obj);        
    }
    
}
[SerializeField]
public class Data_18
{
    public string title;
    public string options;
}