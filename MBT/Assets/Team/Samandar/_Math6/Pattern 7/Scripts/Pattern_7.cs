using DG.Tweening;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_7 : GeneralTest
{
    private TextAsset _jsonText;
    public GameObject Line;
    public GameObject Dot;
    public GameObject DotPrefabs;
    public GameObject CellParent;
    public GameObject Cell;
    public GameObject Koordinata;
    public GameObject DotParent;
    public GameObject LineParent;
    public GameObject PenTool;
    //public GameObject PositionY;
    public GameObject PositionX;
    public List<GameObject> CellObj;
    public List<GameObject> CanvasOut;
    public List<GameObject> PositionOut;
    public List<GameObject> DotsList = new();
    public List<CellPattern7> CellGroup = new();
    public List<float> PositionOY;
    public List<Button> Buttons = new();
    public List<string> NumberList;
    //public List<string> NumberY;
    //public List<string> NumberX;
    public static Pattern_7 Instance;
    public float width;
    public float height;
    bool Yoqish;
    public bool _istrue = true;
    bool _isTrueOneTime = true;
    public bool _click;
    public Data_7 Data7 = new();
    public float percentage;
    private void Awake()
    {
        CellParent.GetComponent<CellParent>().Pattern_7 = this;
        percentage = Cell.transform.localScale.x;
        InstantiatePrefabs();
        DotPrefabs.GetComponent<PointsPattern7>().Pattern_7 = this;
        Instance = this;
        Debug.Log(PenTool.transform.position);
        
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
        for (int i = 0; i < PositionOut.Count; i++)
        {
            PositionOut[i].SetActive(true);
        }
        DisplayQuestion(Data7.title);

    }

    void InstantiatePrefabs()
    {
        GameObject dot = Instantiate(Dot);
        GameObject line = Instantiate(Line);
        //GameObject posY = Instantiate(PositionY);
        GameObject posX = Instantiate(PositionX);
        PositionOut.Add(posX);
        //PositionOut.Add(posY);
        DotParent = dot;
        LineParent = line;
        GameObject obj = Instantiate(CellParent);
        CanvasOut.Add(dot);
        CanvasOut.Add(line);
        CanvasOut.Add(obj);
    }
    public void PosY()
    {
        float pos1 = CanvasOut[3].transform.position.y - 6 * percentage;
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
        //ReadFromJson();
    }

    public void Active()
    {
        if (_click)
        {
            //if (TestManager.Instance.CheckIsLast())
            //{
            //    FinishButton.Raise();
            //}
            //else
            //{
                
            //}
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
                        TurnOnTurnOf();
                        break;
                    case 1:                        
                        LineParentTurnOn();
                        break;
                    case 2:                        
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
        obj.transform.position = PenTool.transform.position;
        CanvasOut.Add(obj);
        Debug.Log(obj.transform.position);
    }
    public void LineParentTurnOn()
    {
        Rectangle();
        LineParent.transform.GetChild(0).gameObject.SetActive(true);
        LineParent.transform.GetChild(0).transform.GetComponent<LineRenderer>().loop = true;
        if (Buttons[0].GetComponent<ButtonClick>().IsEnable == false)
        {
            PenTool.SetActive(false);
        }
        for (int i = 0; i < DotsList.Count; i++)
        {
            DotsList[i].transform.GetComponent<PointsPattern7>().GetData();
            DotsList[i].transform.GetComponent<PointsPattern7>().Numbers();
            
        }
        Check();
    }
    public void NewPosPoint()
    {
        NumberList.Clear();
        for (int i = 0; i < DotsList.Count; i++)
        {

            DotsList[i].GetComponent<PointsPattern7>().GetData();
        }
    }
    void Rectangle()
    {
        if (DotsList.Count == 4)
        {
            if (DotsList[0].transform.position.x < DotsList[1].transform.position.x && DotsList[2].transform.position.x < DotsList[3].transform.position.x && DotsList[0].transform.position.y > DotsList[2].transform.position.y && DotsList[1].transform.position.y > DotsList[3].transform.position.y)
            {
                Debug.Log("1");
                DotsList[2].transform.DOMove(DotsList[3].transform.position, 0);
                DotsList[3].transform.DOMove(DotsList[2].transform.position, 0);
            }
            else if (DotsList[0].transform.position.x < DotsList[2].transform.position.x && DotsList[1].transform.position.x < DotsList[3].transform.position.x && DotsList[0].transform.position.y > DotsList[1].transform.position.y && DotsList[2].transform.position.y > DotsList[3].transform.position.y)
            {
                Debug.Log("2");
                DotsList[2].transform.DOMove(DotsList[3].transform.position, 0);
                DotsList[3].transform.DOMove(DotsList[2].transform.position, 0);
            }
            else if (DotsList[0].transform.position.x < DotsList[3].transform.position.x && DotsList[2].transform.position.x < DotsList[1].transform.position.x && DotsList[0].transform.position.y > DotsList[2].transform.position.y && DotsList[3].transform.position.y > DotsList[1].transform.position.y)
            {
                Debug.Log("3");
                DotsList[2].transform.DOMove(DotsList[1].transform.position, 0);
                DotsList[1].transform.DOMove(DotsList[2].transform.position, 0);
            }
            else if (DotsList[0].transform.position.x < DotsList[2].transform.position.x && DotsList[1].transform.position.x > DotsList[3].transform.position.x && DotsList[0].transform.position.y > DotsList[3].transform.position.y && DotsList[2].transform.position.y > DotsList[1].transform.position.y)
            {
                Debug.Log("4");
                DotsList[1].transform.DOMove(DotsList[2].transform.position, 0);
                DotsList[2].transform.DOMove(DotsList[1].transform.position, 0);
            }
            else if (DotsList[0].transform.position.x > DotsList[1].transform.position.x && DotsList[2].transform.position.x > DotsList[3].transform.position.x && DotsList[0].transform.position.y > DotsList[2].transform.position.y && DotsList[1].transform.position.y > DotsList[3].transform.position.y)
            {
                Debug.Log("5");
                DotsList[1].transform.DOMove(DotsList[0].transform.position, 0);
                DotsList[0].transform.DOMove(DotsList[1].transform.position, 0);
            }
            else if (DotsList[2].transform.position.x < DotsList[0].transform.position.x && DotsList[3].transform.position.x < DotsList[1].transform.position.x && DotsList[0].transform.position.y > DotsList[1].transform.position.y && DotsList[2].transform.position.y > DotsList[3].transform.position.y)
            {
                Debug.Log("6");
                DotsList[2].transform.DOMove(DotsList[3].transform.position, 0);
                DotsList[3].transform.DOMove(DotsList[2].transform.position, 0);
            }
            else if (DotsList[2].transform.position.x < DotsList[0].transform.position.x && DotsList[1].transform.position.x < DotsList[3].transform.position.x && DotsList[0].transform.position.y > DotsList[3].transform.position.y && DotsList[2].transform.position.y > DotsList[1].transform.position.y)
            {
                Debug.Log("7");
                DotsList[1].transform.DOMove(DotsList[2].transform.position, 0);
                DotsList[2].transform.DOMove(DotsList[1].transform.position, 0);
            }
            else if (DotsList[0].transform.position.x > DotsList[3].transform.position.x && DotsList[2].transform.position.x > DotsList[1].transform.position.x && DotsList[0].transform.position.y > DotsList[2].transform.position.y && DotsList[3].transform.position.y > DotsList[1].transform.position.y)
            {
                Debug.Log("8");
                DotsList[2].transform.DOMove(DotsList[1].transform.position, 0);
                DotsList[1].transform.DOMove(DotsList[2].transform.position, 0);
            }
            else if (DotsList[0].transform.position.x < DotsList[1].transform.position.x && DotsList[2].transform.position.x < DotsList[3].transform.position.x && DotsList[0].transform.position.y < DotsList[2].transform.position.y && DotsList[1].transform.position.y < DotsList[3].transform.position.y)
            {
                Debug.Log("9");
                DotsList[3].transform.DOMove(DotsList[2].transform.position, 0);
                DotsList[2].transform.DOMove(DotsList[3].transform.position, 0);
            }
            else if (DotsList[0].transform.position.x < DotsList[2].transform.position.x && DotsList[1].transform.position.x < DotsList[3].transform.position.x && DotsList[0].transform.position.y < DotsList[1].transform.position.y && DotsList[2].transform.position.y < DotsList[3].transform.position.y)
            {
                Debug.Log("10");
                DotsList[3].transform.DOMove(DotsList[2].transform.position, 0);
                DotsList[2].transform.DOMove(DotsList[3].transform.position, 0);
            }
            else if (DotsList[2].transform.position.x < DotsList[1].transform.position.x && DotsList[0].transform.position.x < DotsList[3].transform.position.x && DotsList[0].transform.position.y < DotsList[1].transform.position.y && DotsList[2].transform.position.y > DotsList[3].transform.position.y)
            {
                Debug.Log("11");
                DotsList[1].transform.DOMove(DotsList[2].transform.position, 0);
                DotsList[2].transform.DOMove(DotsList[1].transform.position, 0);
            }
            else if (DotsList[0].transform.position.x < DotsList[2].transform.position.x && DotsList[3].transform.position.x < DotsList[1].transform.position.x && DotsList[0].transform.position.y < DotsList[3].transform.position.y && DotsList[2].transform.position.y < DotsList[1].transform.position.y)
            {
                Debug.Log("12");
                DotsList[1].transform.DOMove(DotsList[2].transform.position, 0);
                DotsList[2].transform.DOMove(DotsList[1].transform.position, 0);
            }
            else if (DotsList[0].transform.position.x > DotsList[1].transform.position.x && DotsList[2].transform.position.x > DotsList[3].transform.position.x && DotsList[0].transform.position.y < DotsList[2].transform.position.y && DotsList[1].transform.position.y < DotsList[3].transform.position.y)
            {
                Debug.Log("13");
                DotsList[1].transform.DOMove(DotsList[0].transform.position, 0);
                DotsList[0].transform.DOMove(DotsList[1].transform.position, 0);
            }
            else if (DotsList[0].transform.position.x > DotsList[2].transform.position.x && DotsList[1].transform.position.x > DotsList[3].transform.position.x && DotsList[0].transform.position.y < DotsList[1].transform.position.y && DotsList[2].transform.position.y < DotsList[3].transform.position.y)
            {
                Debug.Log("14");
                DotsList[2].transform.DOMove(DotsList[3].transform.position, 0);
                DotsList[3].transform.DOMove(DotsList[2].transform.position, 0);
            }
            else if (DotsList[0].transform.position.x > DotsList[3].transform.position.x && DotsList[2].transform.position.x > DotsList[1].transform.position.x && DotsList[0].transform.position.y < DotsList[2].transform.position.y && DotsList[1].transform.position.y > DotsList[3].transform.position.y)
            {
                Debug.Log("15");
                DotsList[2].transform.DOMove(DotsList[1].transform.position, 0);
                DotsList[1].transform.DOMove(DotsList[2].transform.position, 0);
            }
            else if (DotsList[0].transform.position.x > DotsList[2].transform.position.x && DotsList[1].transform.position.x < DotsList[3].transform.position.x && DotsList[0].transform.position.y < DotsList[3].transform.position.y && DotsList[2].transform.position.y < DotsList[1].transform.position.y)
            {
                Debug.Log("16");
                DotsList[2].transform.DOMove(DotsList[1].transform.position, 0);
                DotsList[1].transform.DOMove(DotsList[2].transform.position, 0);
            }           
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
    public void CheckDrop()
    {
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        List<string> options = Data7.options;
        bool isEqual = NumberList.OrderBy(x => x).SequenceEqual(options.OrderBy(x => x));
        if (isEqual == true && Buttons[1].transform.GetComponent<ButtonClick>().IsEnable == true)
        {
            if (DotsList.Count == 4)
            {
                if (DotsList[0].transform.position.x < DotsList[1].transform.position.x && DotsList[2].transform.position.x < DotsList[3].transform.position.x && DotsList[0].transform.position.y > DotsList[2].transform.position.y && DotsList[1].transform.position.y > DotsList[3].transform.position.y)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;                    
                    Debug.Log("Wrong1");
                }
                else if (DotsList[0].transform.position.x < DotsList[2].transform.position.x && DotsList[1].transform.position.x < DotsList[3].transform.position.x && DotsList[0].transform.position.y > DotsList[1].transform.position.y && DotsList[2].transform.position.y > DotsList[3].transform.position.y)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                    Debug.Log("Wrong2");
                }
                else if (DotsList[0].transform.position.x < DotsList[3].transform.position.x && DotsList[2].transform.position.x < DotsList[1].transform.position.x && DotsList[0].transform.position.y > DotsList[2].transform.position.y && DotsList[3].transform.position.y > DotsList[1].transform.position.y)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                    Debug.Log("Wrong3");
                }
                else if (DotsList[0].transform.position.x < DotsList[2].transform.position.x && DotsList[1].transform.position.x > DotsList[3].transform.position.x && DotsList[0].transform.position.y > DotsList[3].transform.position.y && DotsList[2].transform.position.y > DotsList[1].transform.position.y)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                    Debug.Log("Wrong4");
                }
                else if (DotsList[0].transform.position.x > DotsList[1].transform.position.x && DotsList[2].transform.position.x > DotsList[3].transform.position.x && DotsList[0].transform.position.y > DotsList[2].transform.position.y && DotsList[1].transform.position.y > DotsList[3].transform.position.y)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                    Debug.Log("Wrong5");
                }
                else if (DotsList[2].transform.position.x < DotsList[0].transform.position.x && DotsList[3].transform.position.x < DotsList[1].transform.position.x && DotsList[0].transform.position.y > DotsList[1].transform.position.y && DotsList[2].transform.position.y > DotsList[3].transform.position.y)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                    Debug.Log("Wrong6");
                }
                else if (DotsList[2].transform.position.x < DotsList[0].transform.position.x && DotsList[1].transform.position.x < DotsList[3].transform.position.x && DotsList[0].transform.position.y > DotsList[3].transform.position.y && DotsList[2].transform.position.y > DotsList[1].transform.position.y)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                    Debug.Log("Wrong7");
                }
                else if (DotsList[0].transform.position.x > DotsList[3].transform.position.x && DotsList[2].transform.position.x > DotsList[1].transform.position.x && DotsList[0].transform.position.y > DotsList[2].transform.position.y && DotsList[3].transform.position.y > DotsList[1].transform.position.y)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                    Debug.Log("Wrong8");
                }
                else if (DotsList[0].transform.position.x < DotsList[1].transform.position.x && DotsList[2].transform.position.x < DotsList[3].transform.position.x && DotsList[0].transform.position.y < DotsList[2].transform.position.y && DotsList[1].transform.position.y < DotsList[3].transform.position.y)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                    Debug.Log("Wrong9");
                }
                else if (DotsList[0].transform.position.x < DotsList[2].transform.position.x && DotsList[1].transform.position.x < DotsList[3].transform.position.x && DotsList[0].transform.position.y < DotsList[1].transform.position.y && DotsList[2].transform.position.y < DotsList[3].transform.position.y)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                    Debug.Log("Wrong10");
                }
                else if (DotsList[2].transform.position.x < DotsList[1].transform.position.x && DotsList[0].transform.position.x < DotsList[3].transform.position.x && DotsList[0].transform.position.y < DotsList[1].transform.position.y && DotsList[2].transform.position.y > DotsList[3].transform.position.y)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                    Debug.Log("Wrong11");
                }
                else if (DotsList[0].transform.position.x < DotsList[2].transform.position.x && DotsList[3].transform.position.x < DotsList[1].transform.position.x && DotsList[0].transform.position.y < DotsList[3].transform.position.y && DotsList[2].transform.position.y < DotsList[1].transform.position.y)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                    Debug.Log("Wrong12");
                }
                else if (DotsList[0].transform.position.x > DotsList[1].transform.position.x && DotsList[2].transform.position.x > DotsList[3].transform.position.x && DotsList[0].transform.position.y < DotsList[2].transform.position.y && DotsList[1].transform.position.y < DotsList[3].transform.position.y)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                    Debug.Log("Wrong13");
                }
                else if (DotsList[0].transform.position.x > DotsList[2].transform.position.x && DotsList[1].transform.position.x > DotsList[3].transform.position.x && DotsList[0].transform.position.y < DotsList[1].transform.position.y && DotsList[2].transform.position.y < DotsList[3].transform.position.y)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                    Debug.Log("Wrong14");
                }
                else if (DotsList[0].transform.position.x > DotsList[3].transform.position.x && DotsList[2].transform.position.x > DotsList[1].transform.position.x && DotsList[0].transform.position.y < DotsList[2].transform.position.y && DotsList[1].transform.position.y > DotsList[3].transform.position.y)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                    Debug.Log("Wrong15");
                }
                else if (DotsList[0].transform.position.x > DotsList[2].transform.position.x && DotsList[1].transform.position.x < DotsList[3].transform.position.x && DotsList[0].transform.position.y < DotsList[3].transform.position.y && DotsList[2].transform.position.y < DotsList[1].transform.position.y)
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = false;
                    Debug.Log("Wrong16");
                }
                else
                {
                    currentList[GetComponent<Pattern>().QuestionNumber] = true;
                    Debug.Log("Corrent1");
                }                
            }
            else
            {
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
                Debug.Log("Corrent2");
            }
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
            Debug.Log("Wrong");
        }
        ES3.Save("ResultList", currentList);
        ES3.Save<bool>("Pattern_15_Check", true);
        GetComponent<Pattern>().IsEdited = true; ES3.Save("ResultList", currentList);
        ES3.Save<bool>("Pattern_15_Check", true);
        GetComponent<Pattern>().IsEdited = true;
        TestManager.Instance.CheckAllIsDone();
    }
    public void Check()
    {
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        List<string> options = Data7.options;        
        bool isEqual = NumberList.OrderBy(x => x).SequenceEqual(options.OrderBy(x => x));
        if (isEqual == true && Buttons[1].transform.GetComponent<ButtonClick>().IsEnable == true)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
            Debug.Log("Corrent");             
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
            Debug.Log("Wrong");
        }
        ES3.Save("ResultList", currentList);
        ES3.Save<bool>("Pattern_15_Check", true);
        GetComponent<Pattern>().IsEdited = true;
        TestManager.Instance.CheckAllIsDone();
    }

    public void DestroyPointLine()
    {
        DotsList.Clear();
        if (LineParent.transform.GetChild(0).gameObject != null)
        {
            Destroy(LineParent.transform.GetChild(0).gameObject);
        }
        
        for (int i = 0; i < DotParent.transform.childCount; i++)
        {
            Destroy(DotParent.transform.GetChild(i).gameObject);
        }
        if (Buttons[0].GetComponent<ButtonClick>().IsEnable == false)
        {
            PenTool.SetActive(false);
        }
        Buttons[0].GetComponent<Button>().interactable = true;
        Buttons[1].GetComponent<Button>().interactable = false;
        Buttons[2].GetComponent<Button>().interactable = false;
        NumberList.Clear();
        GetComponent<Pattern>().IsEdited = false;
        TestManager.Instance.CheckAllIsDone();
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