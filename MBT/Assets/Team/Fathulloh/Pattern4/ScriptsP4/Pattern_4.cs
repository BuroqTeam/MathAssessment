using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_4 : TestManagerSample
{
    public TextAsset JsonText;
    private GameObject MainParent;
    public GameObject QuestionObj;

    public List<GameObject> MainObjs;
    public GameObject ParentComparisonPrefab;

    public List<GameObject> ComparisonObjects;
    Data_4 Pattern_4Obj = new Data_4();
    float yPos;

    private void Awake()
    {
        
    }


    void Start()
    {
        MainParent = gameObject.transform.parent.transform.parent.gameObject;
        QuestionObj = MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject;
        ReadFromJson();
    }

    void ReadFromJson()
    {
        var jsonObj = JObject.Parse(JsonText.text);

        Pattern_4Obj = jsonObj["chapters"][0]["questions"][32]["question"].ToObject<Data_4>();
        CreatePrefabs();
    }

    void CreatePrefabs()
    {
        QuestionObj.GetComponent<TEXDraw>().text = Pattern_4Obj.title;
        
        int n = Pattern_4Obj.options.Count;
        
        
        for (int i = 0; i < Pattern_4Obj.statements.Count; i++)
        {
            if (i == 0)            {
                MainObjs[0].transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_4Obj.statements[i].statement;
            }
            else if (i == 1)    {
                MainObjs[2].transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_4Obj.statements[i].statement;
            }
            //Debug.Log(Pattern_4Obj.statements[i].statement);
        }

        //MainObjs[2].transform.localPosition


        for (int i = 0; i < Pattern_4Obj.options.Count; i++)
        {            
            GameObject obj = Instantiate(ParentComparisonPrefab, this.transform);
            ComparisonObjects.Add(obj);
        }



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