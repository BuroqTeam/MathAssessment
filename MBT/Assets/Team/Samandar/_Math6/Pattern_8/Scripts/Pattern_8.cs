using MBT.Extension;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_8 : GeneralTest
{
    private TextAsset _jsonText;
    public static Pattern_8 Instance;
    public GameObject CellPosition;
    public GameObject CellParent;
    public GameObject PointParent;
    public GameObject LineRenderer;
    public GameObject MeshRenderer;
    public GameObject LinePosition;
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
        List<string> proportion = Data8.proportion;
        float m = float.Parse(proportion[0]);
        float n = float.Parse(proportion[1]);
        Parties.Add(m);
        Parties.Add(n);
    }
  
    public void Check()
    {
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        List<string> proportion = Data8.proportion;
        
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
            rectangle();
        }
        //if ()
        //{
        //    currentList[GetComponent<Pattern>().QuestionNumber] = true;

        //}
        //else
        //{
        //    currentList[GetComponent<Pattern>().QuestionNumber] = false;

        //}
        //ES3.Save("ResultList", currentList);
        //ES3.Save<bool>("Pattern_15_Check", true);
        //GetComponent<Pattern>().IsEdited = true;
        //TestManager.Instance.CheckAllIsDone();
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
    void Start()
    {
        
    }
    public void JsonTextToInt()
    {
        
        string figureString_1 = "rightTriangle";
        string figureString_2 = "triangle";
        string figureString_3 = "rectangle";
        string figureType = Data8.figureType;        
        if (figureType == figureString_1)
        {
            Logging.Log("Togri burchakli uchburchak");
            Figure = 2;
        }
        else if(figureType == figureString_2)
        {
            Logging.Log("Uchburchak");
            Figure = 3;
        }
        else if (figureType == figureString_3)
        {
            Logging.Log("Turtburchak");
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
        CanvasOut[2].transform.GetComponent<LineControllarPattern10>().Pattern_8 = this;
        GameObject meshRenderer = Instantiate(MeshRenderer);
        CanvasOut.Add(meshRenderer);
        CanvasOut[3].transform.GetComponent<MeshController>().Pattern_8 = this;
    }
    
    public void SquareLocation()
    {
        for (float i = 0; i < width; i+=percentage)
        {
            for (float j = 0; j < height; j+=percentage)
            {
                GameObject SpawnedCell = Instantiate(Cell, new Vector3(i, j), Quaternion.identity);
                //SpawnedCell.name = $"Cell {i}, {j}";                
                CellGroup.Add(SpawnedCell.GetComponent<Cell>());                
            }
        }        
    }

    void rectangle()
    {

    }
    void Triangle()
    {
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        List<string> proportion = Data8.proportion;

        Transform pos1 = PointList[0].transform;
        Transform pos2 = PointList[1].transform;
        Transform pos3 = PointList[2].transform;

        if (pos1.position.x == pos2.position.x)
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
                Logging.Log("current-1");
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
                Logging.Log("wrong-2");
            }
        }
        else if (pos1.position.y == pos2.position.y)
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
        else if (pos1.position.x == pos3.position.x)
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
                Logging.Log("current-4");
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
                Logging.Log("wrong-5");
            }
        }
        else if (pos1.position.y == pos3.position.y)
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
                Logging.Log("current-6");
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
                Logging.Log("wrong-7");
            }
        }       
        else if (pos2.position.x == pos3.position.x)
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
                Logging.Log("current-8");
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
                Logging.Log("wrong-9");
            }
        }
        else if (pos2.position.y == pos3.position.y)
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
                Logging.Log("current-10");
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
                Logging.Log("wrong-11");
            }
        }       
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
            Logging.Log("wrong-20");
        }
    }
    void RightTriangle()
    {
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        List<string> proportion = Data8.proportion;

        Transform pos1 = PointList[0].transform;
        Transform pos2 = PointList[1].transform;
        Transform pos3 = PointList[2].transform;

        if (pos1.position.x == pos2.position.x && pos1.position.y == pos3.position.y)
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
            if (Mathf.Approximately (c / b , Parties[0] / Parties[1]))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                Logging.Log("current-5");
            }
            else if (Mathf.Approximately (c / b , Parties[1] / Parties[0]))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                Logging.Log("current-6");
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
                Logging.Log("wrong-7");
            }
        }
        else if (pos1.position.x == pos3.position.x && pos1.position.y == pos2.position.y)
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
            if (Mathf.Approximately(c / b, Parties[0] / Parties[1]))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                Logging.Log("current4");
            }
            else if (Mathf.Approximately(c / b, Parties[1] / Parties[0]))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                Logging.Log("current5");
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
                Logging.Log("wrong6");
            }
        }
        else if (pos2.position.x == pos1.position.x && pos2.position.y == pos3.position.y)
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
            if (Mathf.Approximately(c / b, Parties[0] / Parties[1]))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                Logging.Log("current7");
            }
            else if (Mathf.Approximately(c / b, Parties[1] / Parties[0]))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                Logging.Log("current8");
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
                Logging.Log("wrong9");
            }
        }
        else if (pos2.position.x == pos3.position.x && pos2.position.y == pos1.position.y)
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
            if (Mathf.Approximately(c / b, Parties[0] / Parties[1]))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                Logging.Log("current10");
            }
            else if (Mathf.Approximately(c / b, Parties[1] / Parties[0]))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                Logging.Log("current11");
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
                Logging.Log("wrong12");
            }
        }
        else if (pos3.position.x == pos1.position.x && pos3.position.y == pos2.position.y)
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
            if (Mathf.Approximately(c / b, Parties[0] / Parties[1]))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                Logging.Log("current13");
            }
            else if (Mathf.Approximately(c / b, Parties[1] / Parties[0]))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                Logging.Log("current14");
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
                Logging.Log("wrong15");
            }
        }
        else if (pos3.position.x == pos2.position.x && pos3.position.y == pos1.position.y)
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
            if (c / b == Parties[0] / Parties[1])
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                Logging.Log("current16");
            }
            else if (Mathf.Approximately(c / b, Parties[1] / Parties[0]))
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                Logging.Log("current17");
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = false;
                Logging.Log("wrong18");
            }
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
            Logging.Log("wrong19");
        }
    }
}
[SerializeField]
public class Data_8
{
    public string title;
    public string figureType;
    public List<string> proportion;
}
