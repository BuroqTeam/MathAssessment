using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_9 : MonoBehaviour
{
    public TextAsset JsonText;
    private GameObject MainParent;
    public GameObject QuestionObj;

    public GameObject ParentComparisonPrefab;

    Data_9 Pattern_9Obj = new Data_9();



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

        Pattern_9Obj = jsonObj["chapters"][1]["questions"][50]["question"].ToObject<Data_9>();
        CreatePrefabs();
    }


    void CreatePrefabs()
    {
        QuestionObj.GetComponent<TEXDraw>().text = Pattern_9Obj.title;

        int statementCount = Pattern_9Obj.options.Count;


    }


    



}


public class Data_9
{
    public string title;
    public List<Options_9> options = new List<Options_9>();
}

public class Options_9
{
    public string left;
    public char sign;
    public string right;
}

