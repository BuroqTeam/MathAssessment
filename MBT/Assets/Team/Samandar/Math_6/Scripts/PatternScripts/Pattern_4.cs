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
    public TEXDraw PictureText_1;
    public TEXDraw PictureText_2;
    public GameObject PicturePrefab;
    public GameObject PictureName_1;
    public GameObject PictureName_2;
    public GameObject SignsPrefab;
    public List<GameObject> Signs;
    void Start()
    {
       
        CreatePrefabs();
        JsonData();
    }
    void JsonData()
    {
        var jsonObj = JObject.Parse(jsonText.text);

        JArray jo = (JArray)jsonObj["chapters"][1]["questions"][30]["problem"];


        var question = jsonObj["chapters"][1]["questions"][30]["question"]["title"].Value<string>();
        var picturesName_1 = jsonObj["chapters"][1]["questions"][30]["statements"][0]["statement"].Value<string>();
        var picturesName_2 = jsonObj["chapters"][1]["questions"][30]["statements"][0]["statement"].Value<string>();

        PictureText_1.GetComponent<TEXDraw>().text = picturesName_1;
        PictureText_2.GetComponent<TEXDraw>().text = picturesName_2;
        Questions.GetComponent<TEXDraw>().text = question;
        PictureName_1.transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = picturesName_1;
    }
    public void CreatePrefabs() 
    {
        GameObject objName_1 = Instantiate(PicturePrefab, PictureName_1.transform);
        GameObject objName_2 = Instantiate(PicturePrefab, PictureName_2.transform);

        for (int i = 0; i < Signs.Count; i++)
        {
            GameObject objSigns = Instantiate(SignsPrefab, Signs[i].transform);

        }
    }
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