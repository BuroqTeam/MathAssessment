using MBT.Extension;
using Newtonsoft.Json.Linq;
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
    public List<int> Figure;    
    private void Awake()
    {
        JsonTextToInt();
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
        Logging.Log("Togri burchakli uchburchak");
        string figureString_1 = "rightTriangle";
        string figureString_2 = "triangle";
        string figureString_3 = "rectangle";
        string figureType = Data8.figureType;
        Logging.Log(figureType);
        if (figureType == figureString_1)
        {
            Logging.Log("Togri burchakli uchburchak");
            Figure[0] = 2;
        }
        else if(figureType == figureString_2)
        {
            Logging.Log("Uchburchak");
            Figure[1] = 3;
        }
        else if (figureType == figureString_3)
        {
            Logging.Log("Turtburchak");
            Figure[2] = 4;
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

    void Update()
    {
        
    }
}
[SerializeField]
public class Data_8
{
    public string title;
    public string figureType;
    public List<string> proportion;
}
