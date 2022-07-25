using Newtonsoft.Json.Linq;
//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern5 : MonoBehaviour
{
    public TextAsset JsonText;
    private GameObject MainParent;
    public GameObject QuestionObj;

    public int BobID, QuestionID;


    public List<GameObject> positionObjs;
    public GameObject NumPrefab;
    //public GameObject Number;
    public GameObject ParentForPos;
    public Pattern5Data Pattern5Obj = new Pattern5Data();

    void Start()
    {
        //QuestionObject = gameObject.transform.parent.transform.parent.GetChild(8).gameObject;
        MainParent = gameObject.transform.parent.transform.parent.gameObject;
        //QuestionObj = MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject;
        QuestionObj = gameObject.transform.parent.transform.parent.GetChild(8).gameObject;
        

        ReadFromJson();

        CreatePrefabs();
    }


    public void DisplayQuestion()
    {
        //QuestionObj.GetComponent<TEXDraw>().text = Pattern5Obj.title[0];
    }


    public void ReadFromJson()
    {
        QuestionID = Random.Range(40, 50);
        Debug.Log(" QuestionID = " + QuestionID);
        var jsonObj = JObject.Parse(JsonText.text);

        //var likeName = jsonObj["chapters"][0]["questions"][0]["question"]["options"][1].Value<string>();        
        //var test1 = jsonObj["chapters"][0]["questions"][40]["id"].Value<string>();
        //Debug.Log("likeName = " + likeName + " test1 = " + test1);

        //var Pattern5Obj = jsonObj["chapters"][0]["questions"][40].ToObject<Pattern5Data>();
        Pattern5Obj = jsonObj["chapters"][0]["questions"][QuestionID].ToObject<Pattern5Data>();
        //Debug.Log("ID = "+ Pattern5Obj.id + " Problems count = " + Pattern5Obj.problem.Count);

        for (int i = 0; i < Pattern5Obj.solution.Count; i++)        {
            List<string> NewList = Pattern5Obj.solution[i];
            Debug.Log(NewList[0] + " " + NewList[1] + " " + NewList[2] + " " + NewList[3] + " " + NewList[4]);
            
        }

        QuestionObj.GetComponent<TEXDraw>().text = Pattern5Obj.question.title;


        if (Pattern5Obj.question == null)
        {
            Debug.Log("Title is null." + Pattern5Obj.id + "   "+ Pattern5Obj.pattern+ " " + Pattern5Obj.problem[1] + "  " + Pattern5Obj.solution[1]);
        }
        else        {
            Debug.Log("Title is full." + Pattern5Obj.question.title);
        }
    }


    public void CreatePrefabs()
    {
        for (int i = 0; i < Pattern5Obj.problem.Count; i++)
        {
            Vector3 locPos = positionObjs[i].GetComponent<RectTransform>().localPosition;
            
            GameObject obj = Instantiate(NumPrefab, ParentForPos.transform);
            obj.transform.localPosition = locPos;

            //obj.transform.parent = ParentForPos.GetComponent<RectTransform>().transform;            
            //obj.transform.SetParent(ParentForPos.transform);            
        }
    }


}

[SerializeField]
public class Pattern5Data
{
    public string id;
    public string pattern;
    public Pattern5Title question;    
    public List<string> problem;
    public List<List<string>> solution;
}

[SerializeField]
public class Pattern5Title
{
    public string title;
}

