using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using DG.Tweening;

public class Pattern_6 : TestManager
{
    public TextAsset jsonText;
    public GameObject QuestionObj;
    private GameObject MainParent;
    Data_6 Pattern_6Obj = new Data_6();
    private void Start()
    {
        MainParent = gameObject.transform.parent.transform.parent.gameObject;
        QuestionObj = MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject;
        ReadFromJson();
    }
    public void ReadFromJson()
    {
        int QuestionID = 50;
        var jsonObj = JObject.Parse(jsonText.text);
        Pattern_6Obj = jsonObj["chapters"][0]["questions"][QuestionID]["question"].ToObject<Data_6>();
        QuestionObj.GetComponent<TEXDraw>().text = Pattern_6Obj.title;
        transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_6Obj.problem[0];
    }
}

[SerializeField]
public class Data_6
{
    public string title;
    public List<string> problem;
    public List<string> solution;
}

