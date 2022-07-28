using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TexDrawLib;

public class Pattern_4 : TestManager
{
    public TextAsset jsonText;
    //public TEXDraw Questions;
    public TEXDraw PictureText_1;
    public TEXDraw PictureText_2;
    public GameObject PicturePrefab;
    public GameObject PictureName_1;
    public GameObject PictureName_2;
    public GameObject SignsPrefab;
    public List<GameObject> Signs;
    public GameObject ChoosePrefab;
    public List<GameObject> Choose;
    private GameObject MainParent;
    public GameObject QuestionObj;
    public Data_4 Data4 = new Data_4();
    void Start()
    {
       
        CreatePrefabs();
        JsonData();
    }
    void JsonData()
    {
        MainParent = gameObject.transform.parent.transform.parent.gameObject;
        QuestionObj = MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject;
        var jsonObj = JObject.Parse(jsonText.text);

        //JArray jo = (JArray)jsonObj["chapters"][1]["questions"][30]["problem"];
        Data4 = jsonObj["chapters"][0]["questions"][32]["question"].ToObject<Data_4>();
        string d4Title = Data4.title;
        Debug.Log(Data4.title + " " + d4Title + "444");
        //var question = jsonObj["chapters"][0]["questions"][30]["question"]["title"].Value<string>();
        //var picturesName_1 = jsonObj["chapters"][0]["questions"][30]["statements"][0]["statement"].Value<string>();
        //var picturesName_2 = jsonObj["chapters"][0]["questions"][30]["statements"][0]["statement"].Value<string>();
        //var Signs_1 = jsonObj["chapters"][0]["questions"][30]["options"][0]["left"].Value<string>();
        //var Signs_2 = jsonObj["chapters"][0]["questions"][30]["options"][1]["left"].Value<string>();
        //var Signs_3 = jsonObj["chapters"][0]["questions"][30]["options"][2]["left"].Value<string>();
        //PictureText_1.GetComponent<TEXDraw>().text = picturesName_1;
        //PictureText_2.GetComponent<TEXDraw>().text = picturesName_2;
        //QuestionObj.GetComponent<TEXDraw>().text = question;
        //PictureName_1.transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = picturesName_1;
        //PictureName_2.transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = picturesName_2;

        //for (int i = 0; i < 2; i++)
        //{
        //    Signs[i].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = Signs_1;
        //}
        //for (int i = 2; i < 4; i++)
        //{
        //    Signs[i].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = Signs_2;
        //}
        //for (int i = 4; i < 6; i++)
        //{
        //    Signs[i].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = Signs_3;
        //}

    }
    public void CreatePrefabs() 
    {
        GameObject objName_1 = Instantiate(PicturePrefab, PictureName_1.transform);
        GameObject objName_2 = Instantiate(PicturePrefab, PictureName_2.transform);
       
        for (int i = 0; i < Signs.Count; i++)
        {
            GameObject objSigns = Instantiate(SignsPrefab, Signs[i].transform);

        }
        for (int i = 0; i < Choose.Count; i++)
        {
            GameObject objChoose = Instantiate(ChoosePrefab, Choose[i].transform);
        }
    }
    void Update()
    {

    }
}

[SerializeField]
public class Data_4
{
    public string title;
    public List<Statement_4> statements = new List<Statement_4>();
    public List<Option_4> options= new List<Option_4>();
}

[SerializeField]
public class Statement_4
{
    public string statement;
    public string image;
}

[SerializeField]
public class Option_4
{
    public string left;
    public char sign;
    public string right;

}