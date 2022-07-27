using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TexDrawLib;


public class Pattern_3 : MonoBehaviour 
{
    public TextAsset jsonText;
    //public TEXDraw Questions;
    public List<TEXDraw> Numbers;
    public GameObject NumberAreaPrefabs;
    public List<GameObject> NumberArea;
    private GameObject MainParent;
    public GameObject QuestionObj;
    public Data_3 objaa;
    public TEXDraw NumberActions;
    void Start()
    {
        MainParent = gameObject.transform.parent.transform.parent.gameObject;
        QuestionObj = MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject;
        var jsonObj = JObject.Parse(jsonText.text);

        JArray Num = (JArray)jsonObj["chapters"][0]["questions"][29]["problem"];
        //JArray Mum_1 = (JArray)jsonObj["chapters"][0]["questions"][29]["solution"];
        var likeName = jsonObj["chapters"][0]["questions"][29]["question"]["title"].Value<string>();

        
        //var Action_1 = jsonObj["chapters"][0]["questions"][20]["solution"][1].Value<string>();
        //Debug.Log(LName);

        for (int i = 0; i < Numbers.Count; i++)
        {
            Numbers[i].transform.GetComponent<TEXDraw>().text = Num[i].ToString();
        }
        objaa = jsonObj["chapters"][0]["questions"][29].ToObject<Data_3>();
        Debug.Log(objaa.id);
        //Questions.GetComponent<TEXDraw>().text = likeName;
        ////objaa = new Pattern3Data();
        //objPrefab();
        //List<string> solution1 = objaa.solution[0];

        //for (int i = 0; i < solution1.Count - 1; i++)
        //{
        //    GameObject obj = Instantiate(NumberAreaPrefabs, NumberArea[i].transform);
        //}
        List<string> solution1 = objaa.solution[0];

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

        }

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
    public string id;
    public int pattern;
    public string title;    
    public List<string> probem = new List<string>();

    //public Dictionary<int, List<string>> solution = new Dictionary<int, List<string>>();

    public List<List<string>> solution = new List<List<string>>();

    //public string id;
    //public string pattern;
    //public List<string> question;
    ////public List<string> problem;



}

