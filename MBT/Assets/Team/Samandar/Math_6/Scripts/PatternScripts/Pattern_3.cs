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

    Pattern3Data objaa;

    void Start()
    {
       
        var jsonObj = JObject.Parse(jsonText.text);

        JArray jo = (JArray)jsonObj["chapters"][1]["questions"][20]["problem"];


        var likeName = jsonObj["chapters"][1]["questions"][20]["question"]["title"].Value<string>();

        for (int i = 0; i < Numbers.Count; i++)
        {
            Numbers[i].transform.GetComponent<TEXDraw>().text = jo[i].ToString();
        }

        Questions.GetComponent<TEXDraw>().text = likeName;
        objaa = new Pattern3Data();

        //List<string> solution1 = objaa.solution[0];

        //for (int i = 0; i < solution1.Count - 1; i++)
        //{
            
        //}

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
    
    


}

