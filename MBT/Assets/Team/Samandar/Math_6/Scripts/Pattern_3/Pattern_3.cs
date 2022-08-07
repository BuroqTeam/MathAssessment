using Extension;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_3 : TestManager
{
    private TextAsset _jsonText;
    public string sampleQuestion;
    public List<TEXDraw> NumbersText;
    public List<GameObject> Numbers;
    public List<GameObject> NumbersParent;
    public GameObject NumberPrefabs;
    public GameObject NumberAreaPrefabs;
    public List<GameObject> NumberArea;
    private GameObject MainParent;
    public TEXDraw NumberActions;
    public List<GameObject> NumberInstantiate;
    public List<GameObject> CheckList2;
    public List<GameObject> CheckList4;
    public List<GameObject> CheckList6;
    public List<GameObject> MainList = new List<GameObject>();
    public int CorrectAnsNumbers;
    public List<string> Ansver;
    public List<List<string>> newSolution = new List<List<string>>();
    public List<string> SmallList;
    Data_3 DataObj = new Data_3();

    public bool _istrue = true;

    private void OnEnable()
    {
        if (_istrue)
        {
            _istrue = false;
            _jsonText = GetComponent<Pattern>().Json;
            if (_jsonText != null)
            {
                Debug.Log(_jsonText.text);
            }
            else
            {
                Debug.Log("Not Found Data");
            }
            ReadFromJson();
            StartMetod();
        }

        //Mbt.SaveJsonPath("Pattern_3", 0, 25);
        //ES3.Save<string>("LanguageKey", "Uzb");
        //ES3.Save<int>("ClassKey", 6);

        //_jsonText = Mbt.GetDesiredData(_jsCollection);


        DisplayQuestion(DataObj.title);

    }
    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_jsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_3");
        DataObj = jo.ToObject<Data_3>();
    }


    void StartMetod()
    {
        List<string> str = DataObj.problem;
        str = str.ShuffleList();
        DataObj.problem = str;

        List<string> problem1 = DataObj.problem;

        

        List<string> solution1 = DataObj.solution[0];
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
    }
    

    //public override void DisplayQuestion(string questionStr)
    //{
    //    base.DisplayQuestion(questionStr);  

    //}
        
   
    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);        
    }

    void Check()
    {
        List<bool> myList = new List<bool>();

        ES3.Save("ResultList", myList);
        bool ca = true;

        List<bool> currentList = new List<bool>();
        currentList = ES3.Load<List<bool>>("ResultList");

        if (ca)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
        }
        ES3.Save("myList", currentList);


    }


    public void CheckingAnswer()
    {
        CorrectAnsNumbers = 0;
        List<string> solution1 = DataObj.solution[0];
        int javoblarSoni = solution1.Count-1;
        Ansver.Clear();
        for (int i = 0; i < javoblarSoni; i++)
        {
            if (javoblarSoni == 2)
            {
                string mainString2 = CheckList2[i].transform.GetChild(0).GetComponent<NumBoxP_3>().CurrentNumber;
                Ansver.Add(mainString2);
                for (int j = 0; j < Ansver.Count; j++)
                {
                    Debug.Log(Ansver[j]);
                }
            }
            else if (javoblarSoni == 4)
            {
                string mainString4 = CheckList4[i].transform.GetChild(0).GetComponent<NumBoxP_3>().CurrentNumber;
                Ansver.Add(mainString4);                
                for (int j = 0; j < Ansver.Count; j++)
                {
                    Debug.Log(Ansver[j]);
                }
            }
            else if (javoblarSoni == 6)
            {                            
                string mainString6 = CheckList6[i].transform.GetChild(0).GetComponent<NumBoxP_3>().CurrentNumber;
                Ansver.Add(mainString6);
                for (int j = 0; j < Ansver.Count; j++)
                {
                    Debug.Log(Ansver[j]);
                }
            }
           
        }
        

        
    }

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

    public List<List<string>> solution = new List<List<string>>();
     
}

