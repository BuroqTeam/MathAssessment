using MBT.Extension;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pattern_8 : GeneralTest
{
    private TextAsset _jsonText;
    public static Pattern_8 Instance;
    public GameObject CellPosition;
    public GameObject CellParent;
    public GameObject PointParent;
    public GameObject LineRenderer;
    public GameObject LinePosition;
    public List<int> PartiesInt;
    public List<GameObject> CanvasOut;
    public List<GameObject> CellObj;
    public List<GameObject> PointList;
    public float width;
    public float height;
    public GameObject Cell;
    public float percentage;
    public List<Cell> CellGroup = new();
    public float Pivot;
    public bool _istrue = true;
    public Data_8 Data8 = new();
    public int Figure;
    public List<float> Parties;
    public float a;
    public float b;
    public float c;
    public float d;
    public List<float> Tomonlar;
    public List<int> TomonlarInt;
    public GameObject Olcham;
    private void Awake()
    {        
        Instance = this;
        percentage = Cell.transform.localScale.x;
        InstantiateObj();        
    }

    private void OnEnable()
    {        
        if (ES3.Load<bool>("Pattern_8_Check"))
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
        DisplayQuestion(Data8.title);
        JsonTextToInt();
        DataParties();
        
    }

    void DataParties()
    {
        Parties.Clear();
        PartiesInt.Clear();
        List<string> proportion = Data8.proportion;
        float m = float.Parse(proportion[0]);
        float n = float.Parse(proportion[1]);
        Parties.Add(m);
        Parties.Add(n);
        int a = Int32.Parse(proportion[0]);
        int b = Int32.Parse(proportion[1]);
        PartiesInt.Add(a);
        PartiesInt.Add(b);
    }

    public void ActeveteButton()
    {
        GetComponent<Pattern>().IsEdited = true;
        TestManager.Instance.CheckAllIsDone();
    }

    public void Check()
    {            
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
             
        if (Figure == 2)
        {            
            RightTriangle();
        }
        else if (Figure == 3)
        {           
            Triangle();
        }
        else if (Figure == 4)
        {         
            Rectangle();
        }
    }

    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }
    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_jsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_8");
        Data8 = jo.ToObject<Data_8>();
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
        }
    }
   
    public void JsonTextToInt()
    {
        
        string figureString_1 = "rightTriangle";
        string figureString_2 = "triangle";
        string figureString_3 = "rectangle";
        string figureType = Data8.figureType;        
        if (figureType == figureString_1)
        {
            Figure = 2;
        }
        else if(figureType == figureString_2)
        {
            Figure = 3;
        }
        else if (figureType == figureString_3)
        {
            Figure = 4;
        }
    }

    public void Point()
    {
        for (int i = 0; i < PointList.Count; i++)
        {
            PointList[i].GetComponent<DegnDrop>().Pattern_8 = this;
        }
    }

    void InstantiateObj()
    {
        GameObject cellParent = Instantiate(CellParent);       
        CanvasOut.Add(cellParent);
        CanvasOut[0].transform.GetComponent<CellParent8>().Pattern_8 = this;        
        GameObject pointsParent = Instantiate(PointParent);
        CanvasOut.Add(pointsParent);
        CanvasOut[1].transform.GetComponent<PointsParent>().Pattern_8 = this;
        GameObject lineRenderer = Instantiate(LineRenderer);
        CanvasOut.Add(lineRenderer);
        CanvasOut[2].transform.GetComponent<LineControllarPattern_8>().Pattern_8 = this;        
    }

    public void OlchamPosition()
    {
        Olcham.transform.position = new Vector3(CellObj[9].transform.position.x + 1.7f * percentage, CellObj[9].transform.position.y, 0);
    }
    
    void Rectangle()
    {
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        Transform pos1 = PointList[0].transform;
        Transform pos2 = PointList[1].transform;
        Transform pos3 = PointList[2].transform;
        Transform pos4 = PointList[3].transform;
        Tomonlar.Clear();
        TomonlarInt.Clear();
        if (Mathf.Approximately(pos1.position.x, pos4.position.x) && Mathf.Approximately(pos2.position.x, pos3.position.x) && Mathf.Approximately(pos1.position.y, pos2.position.y) && Mathf.Approximately(pos3.position.y, pos4.position.y))
        {
            // (pos3.positi.x == pos2.position.x && pos1.position.x == pos4.position.x && pos2.position.y == pos1.position.y && pos3.position.y == pos4.position.y)on
            if (pos1.position.y > pos4.position.y)
            {
                float BC = pos1.position.y - pos4.position.y;
                a = BC / percentage;
            }
            else if (pos1.position.y < pos4.position.y)
            {
                float BC = pos4.position.y - pos1.position.y;
                a = BC / percentage;
            }
            if (pos2.position.y > pos3.position.y)
            {
                float AC = pos2.position.y - pos3.position.y;
                b = AC / percentage;
            }
            else if (pos2.position.y < pos3.position.y)
            {
                float AC = pos3.position.y - pos2.position.y;
                b = AC / percentage;
            }
            if (pos1.position.x > pos2.position.x)
            {
                float AB = pos1.position.x - pos2.position.x;
                c = AB / percentage;
            }
            else if (pos1.position.x < pos2.position.x)
            {
                float AB = pos2.position.x - pos1.position.x;
                c = AB / percentage;
            }
            if (pos3.position.x > pos4.position.x)
            {
                float AB = pos3.position.x - pos4.position.x;
                d = AB / percentage;
            }
            else if (pos3.position.x < pos4.position.x)
            {
                float AB = pos4.position.x - pos3.position.x;
                d = AB / percentage;
            }
            Tomonlar.Add(a);
            Tomonlar.Add(c);
            int someInt = Convert.ToInt32(Tomonlar[0]);
            int someInt1 = Convert.ToInt32(Tomonlar[1]);
            TomonlarInt.Add(someInt);
            TomonlarInt.Add(someInt1);
            if (Mathf.Approximately(a, b) && Mathf.Approximately(c, d))
            {
                bool isEqual = PartiesInt.OrderBy(x => x).SequenceEqual(TomonlarInt.OrderBy(x => x));

                if (isEqual)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = true;
                }
                else
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                }
            }
        }
        else if (Mathf.Approximately(pos1.position.x, pos2.position.x) && Mathf.Approximately(pos3.position.x, pos4.position.x) && Mathf.Approximately(pos1.position.y, pos4.position.y) && Mathf.Approximately(pos2.position.y, pos3.position.y))
        {
            Logging.Log("Rectangle second if condition.");
            if (pos1.position.y > pos2.position.y)
            {
                float BC = pos1.position.y - pos2.position.y;
                a = BC / percentage;
            }
            else if (pos1.position.y < pos2.position.y)
            {
                float BC = pos2.position.y - pos1.position.y;
                a = BC / percentage;
            }
            if (pos3.position.y > pos4.position.y)
            {
                float AC = pos3.position.y - pos4.position.y;
                b = AC / percentage;
            }
            else if (pos3.position.y < pos4.position.y)
            {
                float AC = pos4.position.y - pos3.position.y;
                b = AC / percentage;
            }
            if (pos1.position.x > pos4.position.x)
            {
                float AB = pos1.position.x - pos4.position.x;
                c = AB / percentage;
            }
            else if (pos1.position.x < pos4.position.x)
            {
                float AB = pos4.position.x - pos1.position.x;
                c = AB / percentage;
            }
            if (pos2.position.x > pos3.position.x)
            {
                float AB = pos2.position.x - pos3.position.x;
                d = AB / percentage;
            }
            else if (pos2.position.x < pos3.position.x)
            {
                float AB = pos3.position.x - pos2.position.x;
                d = AB / percentage;
            }
            Tomonlar.Add(a);
            Tomonlar.Add(c);
            int someInt = Convert.ToInt32(Tomonlar[0]);
            int someInt1 = Convert.ToInt32(Tomonlar[1]);
            TomonlarInt.Add(someInt);
            TomonlarInt.Add(someInt1);
            if (Mathf.Approximately(a, b) && Mathf.Approximately(c, d))
            {
                bool isEqual = PartiesInt.OrderBy(x => x).SequenceEqual(TomonlarInt.OrderBy(x => x));

                if (isEqual)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = true;
                    Logging.Log("Rectangle Correct Condition 2");
                }
                else
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                    Logging.Log("Rectangle Wrong Condition 2");
                }
            }

        }
        
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
        }
        ES3.Save("ResultList", currentList);
        ES3.Save<bool>("Pattern_8_Check", true);
        TestManager.Instance.CheckAllIsDone();
    }
    void Triangle()
    {
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        Transform pos1 = PointList[0].transform;
        Transform pos2 = PointList[1].transform;
        Transform pos3 = PointList[2].transform;

        if (Mathf.Approximately(pos1.position.x, pos2.position.x))
        {
            if (pos1.position.y > pos2.position.y)
            {                
                float BC = pos1.position.y - pos2.position.y;
                a = BC / percentage;
            }
            else if (pos2.position.y > pos1.position.y)
            {                
                float BC = pos2.position.y - pos1.position.y;
                a = BC / percentage;
            }
            if (pos1.position.x > pos3.position.x)
            {
                float AD = pos1.position.x - pos3.position.x;
                d = AD / percentage;
            }
            else if (pos1.position.x < pos3.position.x)
            {
                float AD = pos3.position.x - pos1.position.x;
                d = AD / percentage;
            }
            if (pos1.position.y > pos3.position.y && pos2.position.y < pos3.position.y)
            {
                float BD = pos1.position.y - pos3.position.y;
                b = BD / percentage;
            }
            else if (pos1.position.y < pos3.position.y && pos2.position.y > pos3.position.y)
            {
                float BD = pos2.position.y - pos3.position.y;
                b = BD / percentage;
            }
            if (Mathf.Approximately (a , Parties[0]) && Mathf.Approximately(d , Parties[1]) && Mathf.Approximately(b , Parties[0] / 2))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
            }
        }
        else if (Mathf.Approximately(pos1.position.y, pos2.position.y))
        {
            if (pos1.position.x > pos2.position.x)
            {
                float BC = pos1.position.x - pos2.position.x;
                a = BC / percentage;
            }
            else if (pos2.position.x > pos1.position.x)
            {
                float BC = pos2.position.x - pos1.position.x;
                a = BC / percentage;
            }
            if (pos1.position.y > pos3.position.y)
            {
                float AD = pos1.position.y - pos3.position.y;
                d = AD / percentage;
            }
            else if (pos1.position.y < pos3.position.y)
            {
                float AD = pos3.position.y - pos1.position.y;
                d = AD / percentage;
            }
            if (pos1.position.x > pos3.position.x && pos2.position.x < pos3.position.x)
            {
                float BD = pos1.position.x - pos3.position.x;
                b = BD / percentage;
            }
            else if (pos1.position.x < pos3.position.x && pos2.position.x > pos3.position.x)
            {
                float BD = pos2.position.x - pos3.position.x;
                b = BD / percentage;
            }
            if (Mathf.Approximately(a, Parties[0]) && Mathf.Approximately(d, Parties[1]) && Mathf.Approximately(b, Parties[0] / 2))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                Logging.Log("current-3");
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
                Logging.Log("wrong-4");
            }
        }
        else if (Mathf.Approximately(pos1.position.x, pos3.position.x))
        {
            if (pos1.position.y > pos3.position.y)
            {
                float BC = pos1.position.y - pos3.position.y;
                a = BC / percentage;
            }
            else if (pos3.position.y > pos1.position.y)
            {
                float BC = pos3.position.y - pos1.position.y;
                a = BC / percentage;
            }
            if (pos1.position.x > pos2.position.x)
            {
                float AD = pos1.position.x - pos2.position.x;
                d = AD / percentage;
            }
            else if (pos1.position.x < pos2.position.x)
            {
                float AD = pos2.position.x - pos1.position.x;
                d = AD / percentage;
            }
            if (pos1.position.y > pos2.position.y && pos3.position.y < pos2.position.y)
            {
                float BD = pos1.position.y - pos2.position.y;
                b = BD / percentage;
            }
            else if (pos1.position.y < pos2.position.y && pos3.position.y > pos2.position.y)
            {
                float BD = pos3.position.y - pos2.position.y;
                b = BD / percentage;
            }
            if (Mathf.Approximately(a, Parties[0]) && Mathf.Approximately(d, Parties[1]) && Mathf.Approximately(b, Parties[0] / 2))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                //Logging.Log("current-4");
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
                //Logging.Log("wrong-5");
            }
        }
        else if (Mathf.Approximately(pos1.position.y, pos3.position.y))
        {
            if (pos1.position.x > pos3.position.x)
            {
                float BC = pos1.position.x - pos3.position.x;
                a = BC / percentage;
            }
            else if (pos3.position.x > pos1.position.x)
            {
                float BC = pos3.position.x - pos1.position.x;
                a = BC / percentage;
            }
            if (pos1.position.y > pos2.position.y)
            {
                float AD = pos1.position.y - pos2.position.y;
                d = AD / percentage;
            }
            else if (pos1.position.y < pos2.position.y)
            {
                float AD = pos2.position.y - pos1.position.y;
                d = AD / percentage;
            }
            if (pos1.position.x > pos2.position.x && pos3.position.x < pos2.position.x)
            {
                float BD = pos1.position.x - pos2.position.x;
                b = BD / percentage;
            }
            else if (pos1.position.x < pos2.position.x && pos3.position.x > pos2.position.x)
            {
                float BD = pos3.position.x - pos2.position.x;
                b = BD / percentage;
            }
            if (Mathf.Approximately(a, Parties[0]) && Mathf.Approximately(d, Parties[1]) && Mathf.Approximately(b, Parties[0] / 2))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                //Logging.Log("current-6");
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
                //Logging.Log("wrong-7");
            }
        }       
        else if (Mathf.Approximately(pos2.position.x, pos3.position.x))
        {
            if (pos2.position.y > pos3.position.y)
            {
                float BC = pos2.position.y - pos3.position.y;
                a = BC / percentage;
            }
            else if (pos3.position.y > pos2.position.y)
            {
                float BC = pos3.position.y - pos2.position.y;
                a = BC / percentage;
            }
            if (pos2.position.x > pos1.position.x)
            {
                float AD = pos2.position.x - pos1.position.x;
                d = AD / percentage;
            }
            else if (pos2.position.x < pos1.position.x)
            {
                float AD = pos1.position.x - pos2.position.x;
                d = AD / percentage;
            }
            if (pos2.position.y > pos1.position.y && pos3.position.y < pos1.position.y)
            {
                float BD = pos2.position.y - pos1.position.y;
                b = BD / percentage;
            }
            else if (pos2.position.y < pos1.position.y && pos3.position.y > pos1.position.y)
            {
                float BD = pos3.position.y - pos1.position.y;
                b = BD / percentage;
            }
            if (Mathf.Approximately(a, Parties[0]) && Mathf.Approximately(d, Parties[1]) && Mathf.Approximately(b, Parties[0] / 2))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                //Logging.Log("current-8");
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
                //Logging.Log("wrong-9");
            }
        }
        else if (Mathf.Approximately(pos2.position.y, pos3.position.y))
        {
            if (pos2.position.x > pos3.position.x)
            {
                float BC = pos2.position.x - pos3.position.x;
                a = BC / percentage;
            }
            else if (pos3.position.x > pos2.position.x)
            {
                float BC = pos3.position.x - pos2.position.x;
                a = BC / percentage;
            }
            if (pos2.position.y > pos1.position.y)
            {
                float AD = pos2.position.y - pos1.position.y;
                d = AD / percentage;
            }
            else if (pos2.position.y < pos1.position.y)
            {
                float AD = pos1.position.y - pos2.position.y;
                d = AD / percentage;
            }
            if (pos2.position.x > pos1.position.x && pos3.position.x < pos1.position.x)
            {
                float BD = pos2.position.x - pos1.position.x;
                b = BD / percentage;
            }
            else if (pos2.position.x < pos1.position.x && pos3.position.x > pos1.position.x)
            {
                float BD = pos3.position.x - pos1.position.x;
                b = BD / percentage;
            }
            if (Mathf.Approximately(a, Parties[0]) && Mathf.Approximately(d, Parties[1]) && Mathf.Approximately(b, Parties[0] / 2))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                //Logging.Log("current-10");
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
                //Logging.Log("wrong-11");
            }
        }       
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
        }
        ES3.Save("ResultList", currentList);
        ES3.Save<bool>("Pattern_8_Check", true);
        TestManager.Instance.CheckAllIsDone();
    }

    void RightTriangle()
    {
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        Transform pos1 = PointList[0].transform;
        Transform pos2 = PointList[1].transform;
        Transform pos3 = PointList[2].transform;        
        Tomonlar.Clear();
        TomonlarInt.Clear();        
        if (Mathf.Approximately(pos1.position.x, pos2.position.x) && Mathf.Approximately(pos1.position.y, pos3.position.y))
        {
            if (pos1.position.y > pos2.position.y)
            {
                float AB = pos1.position.y - pos2.position.y;
                c = AB / percentage;
            }
            else if (pos1.position.y < pos2.position.y)
            {
                float AB = pos2.position.y - pos1.position.y;
                c = AB / percentage;
            }
            if (pos1.position.x > pos3.position.x)
            {
                float AC = pos1.position.x - pos3.position.x;
                b = AC / percentage;
            }
            else if (pos1.position.x < pos3.position.x)
            {
                float AC = pos3.position.x - pos1.position.x;
                b = AC / percentage;
            }
            Tomonlar.Add(c);
            Tomonlar.Add(b);
            int someInt = Convert.ToInt32(Tomonlar[0]);
            int someInt1 = Convert.ToInt32(Tomonlar[1]);
            TomonlarInt.Add(someInt);
            TomonlarInt.Add(someInt1);
            bool isEqual = PartiesInt.OrderBy(x => x).SequenceEqual(TomonlarInt.OrderBy(x => x));
            if (isEqual)
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
            }            
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
            }
        }
        else if (Mathf.Approximately(pos1.position.x, pos3.position.x) && Mathf.Approximately(pos1.position.y, pos2.position.y))
        {
            if (pos1.position.y > pos3.position.y)
            {
                float AB = pos1.position.y - pos3.position.y;
                c = AB / percentage;
            }
            else if (pos1.position.y < pos3.position.y)
            {
                float AB = pos3.position.y - pos1.position.y;
                c = AB / percentage;
            }
            if (pos1.position.x > pos2.position.x)
            {
                float AC = pos1.position.x - pos2.position.x;
                b = AC / percentage;
            }
            else if (pos1.position.x < pos2.position.x)
            {
                float AC = pos2.position.x - pos1.position.x;
                b = AC / percentage;
            }
            Tomonlar.Add(c);
            Tomonlar.Add(b);
            int someInt = Convert.ToInt32(Tomonlar[0]);
            int someInt1 = Convert.ToInt32(Tomonlar[1]);
            TomonlarInt.Add(someInt);
            TomonlarInt.Add(someInt1);
            bool isEqual = PartiesInt.OrderBy(x => x).SequenceEqual(TomonlarInt.OrderBy(x => x));
            if (isEqual)
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
            }
        }
        else if (Mathf.Approximately(pos2.position.x, pos1.position.x) && Mathf.Approximately(pos2.position.y, pos3.position.y))
        {
            if (pos2.position.y > pos1.position.y)
            {
                float AB = pos2.position.y - pos1.position.y;
                c = AB / percentage;
            }
            else if (pos2.position.y < pos1.position.y)
            {
                float AB = pos1.position.y - pos2.position.y;
                c = AB / percentage;
            }
            if (pos2.position.x > pos3.position.x)
            {
                float AC = pos2.position.x - pos3.position.x;
                b = AC / percentage;
            }
            else if (pos2.position.x < pos3.position.x)
            {
                float AC = pos3.position.x - pos2.position.x;
                b = AC / percentage;
            }
            Tomonlar.Add(c);
            Tomonlar.Add(b);
            int someInt = Convert.ToInt32(Tomonlar[0]);
            int someInt1 = Convert.ToInt32(Tomonlar[1]);
            TomonlarInt.Add(someInt);
            TomonlarInt.Add(someInt1);
            bool isEqual = PartiesInt.OrderBy(x => x).SequenceEqual(TomonlarInt.OrderBy(x => x));
            if (isEqual)
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
            }
        }
        else if (Mathf.Approximately(pos2.position.x, pos3.position.x)  &&  Mathf.Approximately(pos2.position.y, pos1.position.y))
        {
            if (pos2.position.y > pos3.position.y)
            {
                float AB = pos2.position.y - pos3.position.y;
                c = AB / percentage;
            }
            else if (pos2.position.y < pos3.position.y)
            {
                float AB = pos3.position.y - pos2.position.y;
                c = AB / percentage;
            }
            if (pos2.position.x > pos1.position.x)
            {
                float AC = pos2.position.x - pos1.position.x;
                b = AC / percentage;
            }
            else if (pos2.position.x < pos1.position.x)
            {
                float AC = pos1.position.x - pos2.position.x;
                b = AC / percentage;
            }
            Tomonlar.Add(c);
            Tomonlar.Add(b);
            int someInt = Convert.ToInt32(Tomonlar[0]);
            int someInt1 = Convert.ToInt32(Tomonlar[1]);
            TomonlarInt.Add(someInt);
            TomonlarInt.Add(someInt1);
            bool isEqual = PartiesInt.OrderBy(x => x).SequenceEqual(TomonlarInt.OrderBy(x => x));
            if (isEqual)
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
            }
        }
        else if (Mathf.Approximately(pos3.position.x, pos1.position.x) && Mathf.Approximately(pos3.position.y, pos2.position.y))
        {
            if (pos3.position.y > pos1.position.y)
            {
                float AB = pos3.position.y - pos1.position.y;
                c = AB / percentage;
            }
            else if (pos3.position.y < pos1.position.y)
            {
                float AB = pos1.position.y - pos3.position.y;
                c = AB / percentage;
            }
            if (pos3.position.x > pos2.position.x)
            {
                float AC = pos3.position.x - pos2.position.x;
                b = AC / percentage;
            }
            else if (pos3.position.x < pos2.position.x)
            {
                float AC = pos2.position.x - pos3.position.x;
                b = AC / percentage;
            }
            Tomonlar.Add(c);
            Tomonlar.Add(b);
            int someInt = Convert.ToInt32(Tomonlar[0]);
            int someInt1 = Convert.ToInt32(Tomonlar[1]);
            TomonlarInt.Add(someInt);
            TomonlarInt.Add(someInt1);
            bool isEqual = PartiesInt.OrderBy(x => x).SequenceEqual(TomonlarInt.OrderBy(x => x));
            if (isEqual)
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
            }
        }
        else if (Mathf.Approximately(pos3.position.x, pos2.position.x) && Mathf.Approximately(pos3.position.y, pos1.position.y))
        {
            if (pos3.position.y > pos2.position.y)
            {
                float AB = pos3.position.y - pos2.position.y;
                c = AB / percentage;
            }
            else if (pos3.position.y < pos2.position.y)
            {
                float AB = pos2.position.y - pos3.position.y;
                c = AB / percentage;
            }
            if (pos3.position.x > pos1.position.x)
            {
                float AC = pos3.position.x - pos1.position.x;
                b = AC / percentage;
            }
            else if (pos3.position.x < pos1.position.x)
            {
                float AC = pos1.position.x - pos3.position.x;
                b = AC / percentage;
            }
            Tomonlar.Add(c);
            Tomonlar.Add(b);
            int someInt = Convert.ToInt32(Tomonlar[0]);
            int someInt1 = Convert.ToInt32(Tomonlar[1]);
            TomonlarInt.Add(someInt);
            TomonlarInt.Add(someInt1);
            bool isEqual = PartiesInt.OrderBy(x => x).SequenceEqual(TomonlarInt.OrderBy(x => x));
            if (isEqual)
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
            }
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
        }
        ES3.Save("ResultList", currentList);
        ES3.Save<bool>("Pattern_8_Check", true);
        TestManager.Instance.CheckAllIsDone();
    }
}

[SerializeField]
public class Data_8
{
    public string title;
    public string figureType;
    public List<string> proportion;
}
