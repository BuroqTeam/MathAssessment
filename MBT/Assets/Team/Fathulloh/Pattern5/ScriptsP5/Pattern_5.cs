using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Pattern_5 : TestManager
{       
    public DataBaseSO CurrentDataBase;
    public TextAsset CurrentJsonText;

    public TextAsset JsonText;
    private GameObject MainParent;
    public GameObject QuestionObj;

    public int QuestionID;

    public List<GameObject> Numbers;
    public List<GameObject> Boxs;
    public List<GameObject> EmptyPositions;
    public List<GameObject> positionObjs;
    public GameObject NumPrefab;
    public GameObject NumberBoxPrefab;
    
    public GameObject ParentForPos;

    Data_5 Pattern_5Obj = new Data_5();
    private DataBaseSO JsonCollectionSONew;


    private void FirstMethod()
    {
        //Mbt.SaveJsonPath("Pattern_5", 1, 6);
        //ES3.Save<string>("LanguageKey", "Uzb");

        //ES3.Save<int>("ClassKey", 6);

        if (ES3.Load<string>("Subject").Equals("Algebra"))
        {
            PatternSO = PatternGroup[0];
            JsonCollectionSONew = Group[0];
        }
        else
        {
            PatternSO = PatternGroup[1];
            JsonCollectionSONew = Group[1];
        }

        JsonCollectionSO.DataBase.Clear();
        CurrentJsonText = Mbt.GetDesiredData(JsonCollectionSONew);
        ReadFromJson();
    }



    //void Start()
    //{
    //    MainParent = gameObject.transform.parent.transform.parent.gameObject;
    //    QuestionObj = MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject;    
        
    //    ReadFromJson();
    //    CreatePrefabs();
    //}


    private void OnEnable()
    {
        //GetData();
        FirstMethod();

        DisplayQuestion(Pattern_5Obj.title);
    }



    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);

        //QuestionObj.GetComponent<TEXDraw>().text = Pattern5Obj.question.title;

        //CreatePrefabs(); ++
    }


    public void ReadFromJson()  // Bu method orginal prefabda ishlamaydigan qilinadi. Chunki data boshqa joydan beriladi.
    {        
        var jsonObj = JObject.Parse(CurrentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_5");
        Pattern_5Obj = jo.ToObject<Data_5>();
        CreatePrefabs();

        //QuestionID = Random.Range(40, 50);
        //Pattern5Obj = jsonObj["chapters"][0]["questions"][QuestionID]["question"].ToObject<Data_5>();        
    }


    void CreatePrefabs()
    {
        QuestionObj.GetComponent<TEXDraw>().text = Pattern_5Obj.title;      // Keyinroq bu o'chiriladi.

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
            //obj.transform.parent = ParentForPos.GetComponent<RectTransform>().transform;            
            //obj.transform.SetParent(ParentForPos.transform);            
        }

        
    }


    public int TotalCorrectAns;
    public int FullPositions;

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
            {
                FullPositions++;
            }
        }
        //Debug.Log(fullPositions);
        if (FullPositions == EmptyPositions.Count)
        {
            if (TotalCorrectAns == numbers)
                Debug.Log(TotalCorrectAns + " You are win.");
            else
                Debug.Log(TotalCorrectAns + " You are fall. ");
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



