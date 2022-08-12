using Extension;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_5 : GeneralTest
{
    public GameEvent ActiveNext;
    public GameEvent DeactiveNext;

    //public TextAsset CurrentJsonText;
    private TextAsset _currentJsonText;    

    public List<GameObject> Numbers;
    public List<GameObject> Boxs;
    public List<GameObject> EmptyPositions;
    public List<GameObject> positionObjs;
    public GameObject NumPrefab;
    public GameObject NumberBoxPrefab;
    
    public GameObject ParentForPos;

    Data_5 Pattern_5Obj = new();
    int TotalCorrectAns;    // to'g'ri joylashtirilgan javoblar soni.
    int FullPositions;      // to'ldirilgan o'rinlar soni.

    bool _isTrue = true;

    private void OnEnable()       // +++
    {
        if (ES3.Load<bool>("Pattern_5"))
        {
            ActiveNext.Raise();
        }
        else
            DeactiveNext.Raise();

        if (_isTrue)
        {
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;
            
            ReadFromJson();
        }

        DisplayQuestion(Pattern_5Obj.title);
    }


    //private void Awake()
    //{
    //    //TestManager.Instance.PassToNextClicked += Check;
    //    //Mbt.SaveJsonPath("Pattern_5", 0, 40);
    //    //ES3.Save<string>("LanguageKey", "Uzb");
    //    //ES3.Save<int>("ClassKey", 6);
    //    //ReadFromJson();
    //}


    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }


    public void ReadFromJson()  // Bu method orginal prefabda ishlamaydigan qilinadi. Chunki data boshqa joydan beriladi.
    {                
        //var jsonObj = JObject.Parse(CurrentJsonText.text);

        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_5");
        Pattern_5Obj = jo.ToObject<Data_5>();
        CreatePrefabs();                
    }



    void CreatePrefabs()
    {
        List<string> str = Pattern_5Obj.problem; 
        str = str.ShuffleList();
        Pattern_5Obj.problem = str;
        //Pattern_5Obj.problem = Pattern_5Obj.problem.ShuffleList();

        for (int i = 0; i < Pattern_5Obj.solution.Count; i++)
        {
            List<string> newList = Pattern_5Obj.solution[i];

            GameObject obj = Instantiate(NumberBoxPrefab, this.transform.GetChild(0));
            if (Pattern_5Obj.solution.Count == 2)            {
                Vector3 oldPos = obj.transform.localPosition;
                obj.transform.localPosition = new Vector3(((float)System.Math.Pow(-1, i)) * 275, oldPos.y, 0);
            }
            else if (Pattern_5Obj.solution.Count == 3)            {
                Vector3 oldPos = obj.transform.localPosition;
                obj.transform.localPosition = new Vector3((i - 1) * 550, oldPos.y, 0);
            }

            obj.transform.GetChild(0).GetComponent<TEXDraw>().text = newList[0];
            Boxs.Add(obj);
            for (int j = 1; j < obj.transform.childCount; j++)            {
                EmptyPositions.Add(obj.transform.GetChild(j).gameObject);
                obj.transform.GetChild(j).GetComponent<NumBoxP_5>().CurrentSolution = newList;
            }
        }

        for (int i = 0; i < Pattern_5Obj.problem.Count; i++)
        {
            positionObjs[i].SetActive(true);
            Vector3 locPos = positionObjs[i].GetComponent<RectTransform>().localPosition;
            
            GameObject obj = Instantiate(NumPrefab, ParentForPos.transform);
            obj.transform.localPosition = locPos;
            obj.GetComponent<DragAndDropPattern5>().WriteCurrentAns(Pattern_5Obj.problem[i]);
            obj.GetComponent<DragAndDropPattern5>().EmptyPositions = EmptyPositions;
            obj.GetComponent<DragAndDropPattern5>().Pattern5 = this;

            Numbers.Add(obj);                       
        }        
    }


    public void Check()
    {   
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");

        if (CurrentAnswerStatus)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
        }
        ES3.Save("myList", currentList);

        ES3.Save<bool>("Pattern_5", true);

        //ActivateNext();
    }


    //void ActivateNext()
    //{
    //    int index = TestManager.Instance.ActivePatterns.FindIndex(o => o == gameObject);
    //    index++;
    //    TestManager.Instance.ActivePatterns[index].SetActive(true);
    //    gameObject.SetActive(false);
    //}



    public bool CurrentAnswerStatus;

    public void CheckIsFinishing()
    {
        int numbers = Numbers.Count;
        TotalCorrectAns = 0;
        for (int i = 0; i < numbers; i++)
        {
            bool _isTrue = Numbers[i].GetComponent<DragAndDropPattern5>()._NumIsCorrectPosition;
            if (_isTrue)            
                TotalCorrectAns++;            
        }

        FullPositions = 0;

        for (int i = 0; i < EmptyPositions.Count; i++)
        {
            if (!EmptyPositions[i].GetComponent<NumBoxP_5>()._IsEmpty)            
                FullPositions++;            
        }
        //Debug.Log(fullPositions);
        if (FullPositions == EmptyPositions.Count)
        {
            ActiveNext.Raise();
            
            if (TotalCorrectAns == numbers)
            {
                CurrentAnswerStatus = true;
                Debug.Log(TotalCorrectAns + " You are win.");
            }
            else
                Debug.Log(TotalCorrectAns + " You are fall. ");

            //ES3.Save<bool>("Pattern_5", true);
        }
        else
        {
            CurrentAnswerStatus = false;
            DeactiveNext.Raise();

            //ES3.Save<bool>("Pattern_5", false);
        }
            
    }


}

[SerializeField]
public class Data_5
{        
    public string title;
    public List<string> problem;
    public List<List<string>> solution;    
}



//void SetCanvasStretch()
//{
//    GetComponent<RectTransform>().anchorMin = new(0, 0);
//    GetComponent<RectTransform>().anchorMax = new(1, 1);
//    GetComponent<RectTransform>().offsetMin = new(0, 0);
//    GetComponent<RectTransform>().offsetMax = new(0, 0);
//}

//void Start()
//{
//    MainParent = gameObject.transform.parent.transform.parent.gameObject;
//    QuestionObj = MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject;    
//    ReadFromJson();
//    CreatePrefabs();
//}

//QuestionID = Random.Range(40, 50);
//Pattern_5Obj = jsonObj["chapters"][0]["questions"][QuestionID]["question"].ToObject<Data_5>();

//obj.transform.parent = ParentForPos.GetComponent<RectTransform>().transform;            
//obj.transform.SetParent(ParentForPos.transform); 
