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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[SerializeField]
public class Pattern3Data
{
    public string title;
    public string[] options;
}