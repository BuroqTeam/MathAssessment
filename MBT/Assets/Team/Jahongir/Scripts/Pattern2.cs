using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Pattern2 : MonoBehaviour
{
    public TextAsset jsonText;
    public GameObject Buttons;
    public GameObject QuestionObj;
    private GameObject MainParent;
    Pattern2Data Pattern2Obj = new Pattern2Data();

    void Start()
    {
        MainParent = gameObject.transform.parent.transform.parent.gameObject;
        QuestionObj = MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject;
        //var jsonObj = JObject.Parse(jsonText.text);
        //JArray list = (JArray)jsonObj["chapters"][0]["questions"][10]["question"]["options"];
        //var jsonQuestion = (JArray)jsonObj["chapters"][0]["questions"][10]["question"]["title"].Value<string>();
        //Question.GetComponent<TEXDraw>().text = Pattern2Obj.title;
        //Debug.Log(list.Count);
        ReadFromJson();
    }
    public void ReadFromJson()
    {
        int QuestionID = Random.Range(10, 19);
        Debug.Log(" QuestionID = " + QuestionID);
        var jsonObj = JObject.Parse(jsonText.text);
        //var likeName = jsonObj["chapters"][0]["questions"][0]["question"]["options"][1].Value<string>();        
        //var test1 = jsonObj["chapters"][0]["questions"][40]["id"].Value<string>();
        //Debug.Log("likeName = " + likeName + " test1 = " + test1);
        //var Pattern5Obj = jsonObj["chapters"][0]["questions"][40].ToObject<Pattern5Data>();
        Pattern2Obj = jsonObj["chapters"][0]["questions"][QuestionID]["question"].ToObject<Pattern2Data>();

        //for (int i = 0; i < Pattern2Obj.solution.Count; i++)
        //{
        //    List<string> NewList = Pattern2Obj.solution[i];
        //    Debug.Log(NewList[0] + " " + NewList[1] + " " + NewList[2] + " " + NewList[3] + " " + NewList[4]);

        //}

        QuestionObj.GetComponent<TEXDraw>().text = Pattern2Obj.title;
        CreatePrefabs();

        if (Pattern2Obj.title == null)
        {
            Debug.Log("Title is null." );
        }
        else
        {
            Debug.Log("Title is full." + Pattern2Obj.title);
        }
    }


    public void CreatePrefabs()
    {
        for (int i = 0; i < Pattern2Obj.options.Count; i++)
        {
            GameObject button = Instantiate(Buttons, transform);
            button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern2Obj.options[i];
        }
    }
}

[SerializeField]
public class Pattern2Data
{
    public string title;
    public List<string> options;
    
}


