using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TexDrawLib;
using System.Linq;
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
    public GameObject QuestionObj;
    public Data_3 objaa;
    public TEXDraw NumberActions;
    public List<GameObject> NumberInstantiate;
    void Start()
    {
        MainParent = gameObject.transform.parent.transform.parent.gameObject;
        QuestionObj = MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject;
        var jsonObj = JObject.Parse(jsonText.text);
               
        var likeName = jsonObj["chapters"][1]["questions"][27]["question"]["title"].Value<string>();
        objaa = jsonObj["chapters"][0]["questions"][21]["question"].ToObject<Data_3>();
        List<string> problem1 = objaa.problem;

        

        List<string> solution1 = objaa.solution[0];
        //string _problem = objaa.problem[0];

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
        ////objaa = new Pattern3Data();
        //objPrefab();
        //List<string> solution1 = objaa.solution[0];

        //for (int i = 0; i < solution1.Count - 1; i++)
        //{
        //    GameObject obj = Instantiate(NumberAreaPrefabs, NumberArea[i].transform);
        //}

    }

    private void OnEnable()
    {
        DisplayQuestion(sampleQuestion);
    }

    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);  

    }

    void objPrefab()
    {
        for (int i = 0; i < NumberArea.Count; i++)
        {
            GameObject obj = Instantiate(NumberAreaPrefabs, NumberArea[i].transform);
        }
        
    }
    public void DisplayQuestion()
    {
        //Questions.text = objaa.title;



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

