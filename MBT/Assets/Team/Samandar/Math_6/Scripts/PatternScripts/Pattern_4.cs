using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TexDrawLib;

public class Pattern_4 : MonoBehaviour
{
    public TextAsset jsonText;
    public TEXDraw Questions;
    public List<TEXDraw> Numbers;
    public TEXDraw PictureName_1;
    public TEXDraw PictureName_2;

    void Start()
    {
        var jsonObj = JObject.Parse(jsonText.text);

        JArray jo = (JArray)jsonObj["chapters"][1]["questions"][30]["problem"];


        var question = jsonObj["chapters"][1]["questions"][30]["question"]["title"].Value<string>();
        var picturesName_1 = jsonObj["chapters"][1]["questions"][30]["statements"][0]["statement"].Value<string>();
        var picturesName_2 = jsonObj["chapters"][1]["questions"][30]["statements"][0]["statement"].Value<string>();
        for (int i = 0; i < Numbers.Count; i++)
        {
            //Numbers[i].transform.GetComponent<TEXDraw>().text = jo[i].ToString();
        }
        PictureName_1.GetComponent<TEXDraw>().text = picturesName_1;
        PictureName_2.GetComponent<TEXDraw>().text = picturesName_2;
        Questions.GetComponent<TEXDraw>().text = question;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

[SerializeField]
public class Pattern4Data
{
    public string title;
    public string[] options;
}