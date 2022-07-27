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
    public TEXDraw Questions;
    public List<TEXDraw> Numbers;
    public GameObject NumberAreaPrefabs;
    public List<GameObject> NumberArea;
    Pattern3Data objaa;

    void Start()
    {
        
        var jsonObj = JObject.Parse(jsonText.text);

        JArray jo = (JArray)jsonObj["chapters"][1]["questions"][20]["problem"];


        var likeName = jsonObj["chapters"][1]["questions"][20]["question"]["title"].Value<string>();

        //var LName = jsonObj["chapters"][0]["questions"][20]["solution"].Value<string>();

        //Debug.Log(LName);

        for (int i = 0; i < Numbers.Count; i++)
        {
            Numbers[i].transform.GetComponent<TEXDraw>().text = jo[i].ToString();
        }
        //objaa = jsonObj["chapters"][0]["questions"]/*[20]["solution"][0]*/.ToObject<Pattern3Data>();
        //Questions.GetComponent<TEXDraw>().text = likeName;
        ////objaa = new Pattern3Data();
        objPrefab();
        //List<string> solution1 = objaa.solution[0];

        //for (int i = 0; i < solution1.Count - 1; i++)
        //{
        //    GameObject obj = Instantiate(NumberAreaPrefabs, NumberArea[i].transform);
        //}

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
        Questions.text = objaa.title;



    }
   

}

[SerializeField]
public class Pattern3Data
{
    public string title;    
    public List<string> probem = new List<string>();

    public Dictionary<int, List<string>> solution = new Dictionary<int, List<string>>();

    public List<List<string>> sdasdsa = new List<List<string>>();

    public string id;
    public string pattern;
    public List<string> question;
    //public List<string> problem;
   


}

