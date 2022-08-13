using Extension;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_3 : GeneralTest
{
    public GameEvent ActiveNext;
    public GameEvent DeactiveNext;
    private TextAsset _jsonText;
    public string sampleQuestion;
    public List<TEXDraw> NumbersText;
    public List<GameObject> Numbers;
    public List<GameObject> NumbersParent;
    public GameObject NumberPrefabs;
    public GameObject NumberAreaPrefabs;
    public List<GameObject> NumberArea;
    public TEXDraw NumberActions;
    public List<GameObject> NumberInstantiate;
    public List<GameObject> CheckList2;
    public List<GameObject> CheckList4;
    public List<GameObject> CheckList6;
    public List<GameObject> MainList = new();
    public int CorrectAnsNumbers;
    public List<string> Ansver;
    public List<List<string>> newSolution = new();
    public List<string> SmallList;
    Data_3 DataObj = new();

    public bool _istrue = true;
    int n;
    public void OnTrue()
    {
        n = 0;
        List<string> problem1 = DataObj.problem;
        for (int i = 0; i < problem1.Count; i++)
        {
            bool _onTrue = NumberInstantiate[i].GetComponent<NumberArea>()._IsEmpty;
            if (!_onTrue)
            {
                n++;
            }
        }
        if (n == problem1.Count)
        {
            ActiveNext.Raise();
        }
        else
        {
            DeactiveNext.Raise();
        }
    }
    private void OnEnable()
    {
        if (ES3.Load<bool>("Pattern_3_Check"))
        {
            ActiveNext.Raise();
        }
        else
        {
            DeactiveNext.Raise();
        }
        if (_istrue)
        {
            _istrue = false;
            _jsonText = GetComponent<Pattern>().Json;
            ReadFromJson();
            StartMetod();
        }          


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
            Numbers[i].GetComponent< Number>().Pattern3 = this;
            Numbers[i].GetComponent< Number>().Positions = NumberInstantiate;
        }

        for (int i = 0; i < problem1.Count; i++)
        {
            NumbersParent[i].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = problem1[i].ToString();
        }
    }


    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
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
                string mainString2 = CheckList2[i].transform.GetChild(0).GetComponent<NumberArea>().CurrentNumber;
                Ansver.Add(mainString2);
                for (int j = 0; j < Ansver.Count; j++)
                {
                    Debug.Log(Ansver[j]);
                }
            }
            else if (javoblarSoni == 4)
            {
                string mainString4 = CheckList4[i].transform.GetChild(0).GetComponent<NumberArea>().CurrentNumber;
                Ansver.Add(mainString4);                
                for (int j = 0; j < Ansver.Count; j++)
                {
                    Debug.Log(Ansver[j]);
                }
            }
            else if (javoblarSoni == 6)
            {                            
                string mainString6 = CheckList6[i].transform.GetChild(0).GetComponent<NumberArea>().CurrentNumber;
                Ansver.Add(mainString6);
                for (int j = 0; j < Ansver.Count; j++)
                {
                    Debug.Log(Ansver[j]);
                }
            }           
        }         
    }

    public void Check()
    {
        
        List<bool> currentList = new();

        currentList = ES3.Load<List<bool>>("ResultList");

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
                currentList[GetComponent<Pattern>().QuestionNumber] = true;
            }
            else
            {
                k++;
            }            
        }

        if (k.Equals(newSolution.Count))
        {
            Debug.Log("Wrong");
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
        }
        ES3.Save("myList", currentList);
        ES3.Save<bool>("Pattern_3_Check", true);
        
    }

}

[SerializeField]
public class Data_3
{
    public string title;    
    public List<string> problem = new();

    public List<List<string>> solution = new();
     
}

