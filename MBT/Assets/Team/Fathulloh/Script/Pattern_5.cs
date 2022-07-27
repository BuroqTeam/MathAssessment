using Newtonsoft.Json.Linq;
//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_5 : MonoBehaviour
{
    public TextAsset JsonText;
    private GameObject MainParent;
    public GameObject QuestionObj;

    public int BobID, QuestionID;


    public List<GameObject> positionObjs;
    public GameObject NumPrefab;
    //public GameObject Number;
    public GameObject ParentForPos;
    public Data_5 Pattern5Obj = new Data_5();

    void Start()
    {
        MainParent = gameObject.transform.parent.transform.parent.gameObject;
        QuestionObj = MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject;
        //QuestionObj = gameObject.transform.parent.transform.parent.GetChild(8).gameObject;
        

        ReadFromJson();

        CreatePrefabs();
    }


    public void DisplayQuestion()
    {
        QuestionObj.GetComponent<TEXDraw>().text = Pattern5Obj.question.title;
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
        Pattern5Obj = jsonObj["chapters"][1]["questions"][QuestionID].ToObject<Data_5>();

        //for (int i = 0; i < Pattern5Obj.solution.Count; i++)
        //{
        //    List<string> NewList = Pattern5Obj.solution[i];
        //    //Debug.Log(NewList[0] + "   " + NewList[1] + " " + NewList[2] + " " + NewList[3] + " " + NewList[4]);

        //}

        //if (Pattern5Obj.question == null)
        //{
        //    Debug.Log("Title is null." + Pattern5Obj.id + "   "+ Pattern5Obj.pattern+ " " + Pattern5Obj.problem[1] + "  " + Pattern5Obj.solution[1]);
        //}
        //else        {
        //    Debug.Log("Title is full." + Pattern5Obj.question.title);
        //}
    }


    public void CreatePrefabs()
    {
        QuestionObj.GetComponent<TEXDraw>().text = Pattern5Obj.question.title;

        for (int i = 0; i < Pattern5Obj.problem.Count; i++)
        {
            Vector3 locPos = positionObjs[i].GetComponent<RectTransform>().localPosition;
            
            GameObject obj = Instantiate(NumPrefab, ParentForPos.transform);
            obj.transform.localPosition = locPos;
            obj.GetComponent<DragAndDropPattern5>().WriteCurrentAns(Pattern5Obj.problem[i]);

            //obj.transform.parent = ParentForPos.GetComponent<RectTransform>().transform;            
            //obj.transform.SetParent(ParentForPos.transform);            
        }

        //for (int i = 0; i < Pattern5Obj.solution.Count; i++)        {
        //    List<string> newList = Pattern5Obj.solution[i];
        //    Debug.Log(newList[0]);
        //}


    }


}

[SerializeField]
public class Data_5
{
    public string id;
    public string pattern;
    public Pattern5Title question;    
    public List<string> problem;
    public List<List<string>> solution;
    //public Dictionary<int, List<string>> solution /*= new Dictionary<int, List<string>>()*/;
}

[SerializeField]
public class Pattern5Title
{
    public string title;
}

