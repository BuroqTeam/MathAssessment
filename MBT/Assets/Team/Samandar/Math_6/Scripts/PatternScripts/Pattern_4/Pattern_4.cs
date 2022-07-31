using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TexDrawLib;
using UnityEngine.UI;
using TMPro;

public class Pattern_4 : TestManager
{
    public TMP_Dropdown dropdownPrefab;
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
    public Data_4 Data4;
    void Start()
    {
        PopulateList();
        JsonData();
        CreatePrefabs();
        
    }

    public void Populate()
    {
        dropdownPrefab.transform.GetComponent<Image>().color = new Color(0, 0.5803922f, 1, 1);
    }
    void PopulateList()
    {
        List<string> names = new List<string>() { "Tanlang", ">", "<", "=" };
        dropdownPrefab.AddOptions(names);
        Debug.Log("PopulateList");
    }
    void JsonData()
    {
        MainParent = gameObject.transform.parent.transform.parent.gameObject;
        QuestionObj = MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject;
        var jsonObj = JObject.Parse(jsonText.text);

       
        Data4 = jsonObj["chapters"][0]["questions"][32]["question"].ToObject<Data_4>();
        
    }
    public void CreatePrefabs() 
    {
        int Number = Data4.options.Count;
        Debug.Log(Number);
        for (int i = 0; i < Number; i++)
        {
            GameObject objChoose = Instantiate(ChoosePrefab, Choose[i].transform);
            objChoose.transform.GetComponent<DropdownFeature>().P4 = this;
        }
        for (int i = 0; i < 2 * Number; i++)
        {
            GameObject objSigns = Instantiate(SignsPrefab, Signs[i].transform);
        }

        
        GameObject objName_1 = Instantiate(PicturePrefab, PictureName_1.transform);
        GameObject objName_2 = Instantiate(PicturePrefab, PictureName_2.transform);

        string Picture_1 = Data4.statements[0].statement;
        string Picture_2 = Data4.statements[1].statement;

        PictureName_1.transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = Picture_1;
        PictureName_2.transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = Picture_2;

        PictureText_1.GetComponent<TEXDraw>().text = Picture_1;
        PictureText_2.GetComponent<TEXDraw>().text = Picture_2;

        for (int i = 0; i < Number; i++)
        {
            string Left = Data4.options[i].left;
            //int Sign = Data4.options[i].sign;
            string Right = Data4.options[i].right;

            if (i == 0)
            {
                Signs[0].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = Left;
                Signs[1].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = Right;
            }
            if (i == 1)
            {
                Signs[2].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = Left;
                Signs[3].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = Right;
            }
            if (i == 2)
            {
                Signs[4].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = Left;
                Signs[5].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = Right;
            }
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
    public List<Option_4> options = new List<Option_4>();
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