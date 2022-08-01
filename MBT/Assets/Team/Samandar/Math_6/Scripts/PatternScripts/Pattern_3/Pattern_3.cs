using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class Pattern_3 : TestManager
{
    public TextAsset jsonText;
    public string sampleQuestion;
    public List<TEXDraw> NumbersText;
    public List<GameObject> Numbers;
    public List<GameObject> NumbersParent;
    public GameObject NumberPrefabs;
    public GameObject NumberAreaPrefabs;
    public List<GameObject> NumberArea;
    private GameObject MainParent;
    //public GameObject QuestionObj;
    public Data_3 DataObj;
    public TEXDraw NumberActions;
    public List<GameObject> NumberInstantiate;
    public AssetReference PrefabPattern;
    public AssetReference PrefabPattern1;
    public List<GameObject> CheckList2;
    public List<GameObject> CheckList4;
    public List<GameObject> CheckList6;

    void Start()
    {

       

        //MainParent = gameObject.transform.parent.transform.parent.gameObject;
        //QuestionObj = MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject;
        var jsonObj = JObject.Parse(jsonText.text);
               
       
        DataObj = jsonObj["chapters"][0]["questions"][24]["question"].ToObject<Data_3>();
        List<string> problem1 = DataObj.problem;

        

        List<string> solution1 = DataObj.solution[0];
        //string _problem = objaa.problem[0];

        for (int i = 0; i < DataObj.solution.Count; i++)
        {

        }
        for (int i = 0; i < problem1.Count; i++)
        {
            NumbersParent[i].transform.parent.gameObject.transform.GetComponent<HorizontalLayoutGroup>().enabled = false;
            NumbersParent[i].SetActive(true);
            GameObject Obj1 = Instantiate(NumberPrefabs, NumbersParent[i].transform);
            Numbers.Add(Obj1);
        }


        for (int i = 0; i < solution1.Count - 1; i++)
        {
            GameObject obj = Instantiate(NumberAreaPrefabs, NumberArea[i].transform);
            if (solution1.Count - 1 == 2)
            {
                NumberActions.transform.GetComponent<TEXDraw>().text = solution1[1].ToString();
            }
            if (solution1.Count - 1 == 4)
            {
                NumberActions.transform.GetComponent<TEXDraw>().text = solution1[2].ToString();
            }
            if (solution1.Count - 1 ==  6)
            {
                NumberActions.transform.GetComponent<TEXDraw>().text = solution1[3].ToString();
            }
            NumberInstantiate.Add(obj);
        }
        for (int i = 0; i < Numbers.Count; i++)
        {
            Numbers[i].GetComponent<DegnDropPattern_3>().Pattern3 = this;
            Numbers[i].GetComponent<DegnDropPattern_3>().Positions = NumberInstantiate;
        }

        for (int i = 0; i < problem1.Count; i++)
        {
            NumbersParent[i].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = problem1[i].ToString();
        }

        //CheckingAnswer();
        //RemakeJsonSolution();
        
    }

    void PrefabPatternObjLoaded(AsyncOperationHandle<GameObject> obj)
    {
        NumberPrefabs = obj.Result;        
    }

    

    private void OnEnable()
    {
        DisplayQuestion(sampleQuestion);
    }

    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);  

    }
        
    public void DisplayQuestion()
    {
        //Questions.text = objaa.title;

    }


    public List<GameObject> MainList = new List<GameObject>();
    public int CorrectAnsNumbers;
    public List<string> Ansver;

    public void CheckingAnswer()
    {
        CorrectAnsNumbers = 0;
        List<string> solution1 = /*newSolution[0]*/ DataObj.solution[0];
        int javoblarSoni = solution1.Count-1;
        Debug.Log("javoblarSoni  = " + javoblarSoni + " " + newSolution.Count);
        Ansver.Clear();
        for (int i = 0; i < javoblarSoni; i++)
        {
            //Debug.Log("For");
            if (javoblarSoni == 2)
            {
                //MainList = CheckList2;
                string mainString2 = CheckList2[i].transform.GetChild(0).GetComponent<NumBoxP_3>().CurrentNumber;
                Ansver.Add(mainString2);
                for (int j = 0; j < Ansver.Count; j++)
                {
                    Debug.Log(Ansver[j]);
                }
            }
            else if (javoblarSoni == 4)
            {
                //MainList = CheckList4;
                string mainString4 = CheckList4[i].transform.GetChild(0).GetComponent<NumBoxP_3>().CurrentNumber;
                Ansver.Add(mainString4);                
                for (int j = 0; j < Ansver.Count; j++)
                {
                    Debug.Log(Ansver[j]);
                }
            }
            else if (javoblarSoni == 6)
            {
                //MainList = CheckList6;                
                string mainString6 = CheckList6[i].transform.GetChild(0).GetComponent<NumBoxP_3>().CurrentNumber;
                Ansver.Add(mainString6);
                for (int j = 0; j < Ansver.Count; j++)
                {
                    Debug.Log(Ansver[j]);
                }
            }
            //if (CorrectAnsNumbers == javoblarSoni)
            //{
            //    break;
            //}
        }
        

        
    }

    public List<List<string>> newSolution = new List<List<string>>();
    public List<string> SmallList;
    public void RemakeJsonSolution()
    {
        newSolution = new List<List<string>>(DataObj.solution);       

        foreach (List<string> list in newSolution)
        {
            var middleValue = list[list.Count / 2];
            list.Remove(middleValue);
        }
        SmallList.Add("3");  

        int k = 0;
        foreach (List<string> list in newSolution)
        
        {
            if (list.SequenceEqual(Ansver))
            {
                Debug.Log("Correct");
            }
            else
            {
                k++;
            }            
        }

        if (k.Equals(newSolution.Count))
        {
            Debug.Log("Wrong");
        }

        
    }    
}

[SerializeField]
public class Data_3
{
    public string title;    
    public List<string> problem = new List<string>();

    //public Dictionary<int, List<string>> solution = new Dictionary<int, List<string>>();

    public List<List<string>> solution = new List<List<string>>();
     
}

