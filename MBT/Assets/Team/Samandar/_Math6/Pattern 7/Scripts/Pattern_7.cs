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
    public Data_7 Data7 = new Data_7();
    public GameObject Line;
    public GameObject Dot;
    public GameObject DotPrefabs;
    public GameObject CellParent;
    public GameObject Cell;
    public GameObject Koordinata;
    GameObject CellInstanse;
    public Transform Camera;
    public float percentage;
    public List<CellPattern7> CellGroup = new();
    public List<GameObject> CellObj;
    bool Yoqish;
    public bool _istrue = true;
    bool _isTrueOneTime = true;
    public PointsPattern7 Point;
    public CellPattern7 cellPattern7;
    public Transform DotParent;
    public Transform LineParent;
    public int BobID, QuestionID;
    public GameObject Question;
    public bool _click;
    private void Awake()
    {
        //Transform dot = Instantiate(Dot.transform);
        //Transform line = Instantiate(Line.transform);
        //DotParent = dot;
        //LineParent = line;
        //GameObject obj = Instantiate(CellParent);
        //CellParent.GetComponent<CellParent>().Pattern_7 = this;
        //DotPrefabs.GetComponent<PointsPattern7>().Pattern_7 = this;
        //Instance = this;
        //percentage = Cell.transform.localScale.x;
        //CellPosition();
        
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
        Transform dot = Instantiate(Dot.transform);
        Transform line = Instantiate(Line.transform);
        DotParent = dot;
        LineParent = line;
        GameObject obj = Instantiate(CellParent);
        CellParent.GetComponent<CellParent>().Pattern_7 = this;
        DotPrefabs.GetComponent<PointsPattern7>().Pattern_7 = this;
        Instance = this;
        percentage = Cell.transform.localScale.x;
        CellPosition();
        //DisplayQuestion(DataObj.title);

    }

    void Start()
    {
        ReadFromJson();
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
        if (CellObj.Count > 0)
        {
            for (int i = 0; i < CellObj.Count; i++)
            {
                CellObj[i].SetActive(false);
            }
            //for (int i = 0; i < Operations.Count; i++)
            //{
            //    Operations[i].SetActive(false);
            //}

        }
    }
    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }
    public void TurnOnTurnOf()
    {
        Yoqish = Buttons[0].GetComponent<ButtonClick>().IsEnable;
        if (Yoqish == true)
        {
            PenTool.SetActive(true);
        }            
    }
    void CellPosition()
    {
        GameObject obj = Instantiate(Koordinata);
        Koordinata.transform.position = PenTool.transform.position;
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
        //Destroy(LineParent.transform.GetChild(0).gameObject);
        //for (int i = 0; i < DotParent.transform.childCount; i++)
        //{
        //    Destroy(DotParent.transform.GetChild(i).gameObject);
        //}
    }


    //public void SquareLocation()
    //{
        
    //    for (float i = 0; i < width; i += percentage)
    //    {
    //        for (float j = 0; j < height; j += percentage)
    //        {
    //            GameObject SpawnedCell = Instantiate(Cell, new Vector3(i, j), Quaternion.identity, CellParent.transform);
    //            CellGroup.Add(SpawnedCell.GetComponent<CellPattern7>());
    //            CellInstanse = SpawnedCell;
    //        }
    //    }
    //    Camera.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, transform.position.z);
    //} 

    void Update()
    {
        if (_isTrueOneTime)
        {
           
        }
    }


}




public class Pattern5 : MonoBehaviour
{
    public TextAsset JsonText;
    private GameObject MainParent;
    public GameObject QuestionObj;

    public int BobID, QuestionID;


    public List<GameObject> positionObjs;
    public GameObject NumPrefab;
    //public GameObject Number;
    public GameObject ParentForPos;
    public Data_7 Pattern5Obj = new Data_7();

    void Start()
    {
        //QuestionObject = gameObject.transform.parent.transform.parent.GetChild(8).gameObject;
        MainParent = gameObject.transform.parent.transform.parent.gameObject;
        //QuestionObj = MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject;
        QuestionObj = gameObject.transform.parent.transform.parent.GetChild(8).gameObject;


        ReadFromJson();

        CreatePrefabs();
    }


    public void DisplayQuestion()
    {
        //QuestionObj.GetComponent<TEXDraw>().text = Pattern5Obj.title[0];
    }


    public void ReadFromJson()
    {
        
        BobID = Random.Range(0, 10);
        QuestionID = Random.Range(40, 50);
        Debug.Log("BobID = " + BobID + " QuestionID = " + QuestionID);
        var jsonObj = JObject.Parse(JsonText.text);

        //var likeName = jsonObj["chapters"][0]["questions"][0]["question"]["options"][1].Value<string>();        
        //var test1 = jsonObj["chapters"][0]["questions"][40]["id"].Value<string>();
        //Debug.Log("likeName = " + likeName + " test1 = " + test1);
        Pattern5Obj = jsonObj["chapters"][0]["questions"][QuestionID].ToObject<Data_7>();
        //var Pattern5Obj = jsonObj["chapters"][0]["questions"][40].ToObject<Pattern5Data>();

        //Debug.Log("ID = " + Pattern5Obj.id + " Problems count = " + Pattern5Obj.problem.Count);
        //for (int i = 0; i < Pattern5Obj.problem.Count; i++)        {
        //    Debug.Log("    " + Pattern5Obj.problem[i]);
        //}
        QuestionObj.GetComponent<TEXDraw>().text = "320 150 000 000 000";

        //QuestionObj.GetComponent<TEXDraw>().text = Pattern5Obj.title;

       
    }


    public void CreatePrefabs()
    {
        for (int i = 0; i < positionObjs.Count; i++)
        {
            Vector3 locPos = positionObjs[i].GetComponent<RectTransform>().localPosition;

            GameObject obj = Instantiate(NumPrefab, ParentForPos.transform);
            obj.transform.localPosition = locPos;
            //obj.transform.parent = ParentForPos.GetComponent<RectTransform>().transform;            
            //obj.transform.SetParent(ParentForPos.transform);            
        }
    }


}

[SerializeField]
public class Data_7
{
    public string title;
    public List<string> options;    
}