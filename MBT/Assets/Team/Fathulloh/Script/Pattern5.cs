using Newtonsoft.Json.Linq;
//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class Pattern5 : MonoBehaviour
{
    public TextAsset JsonText;
    private GameObject MainParent;
    public GameObject QuestionObj;

    public int BobID, QuestionID;


    public List<GameObject> positionObjs;
    public GameObject NumPosPrefab;
    public GameObject Number;
    public GameObject ParentForPos;


    void Start()
    {
        MainParent = gameObject.transform.parent.transform.parent.gameObject;
        QuestionObj = MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject;

        ReadFromJson();

        CreatePrefabs();
    }


    public void ReadFromJson()
    {
        BobID = Random.Range(0, 10);
        QuestionID = Random.Range(40, 50);
        Debug.Log("BobID = " + BobID + " QuestionID = " + QuestionID);
        var jsonObj = JObject.Parse(JsonText.text);

        //var likeName = jsonObj["chapters"][0]["questions"][0]["question"]["options"][1].Value<string>();
        //Debug.Log(likeName);
        var test1 = jsonObj["chapters"][0]["questions"][40]["id"].Value<string>();
        Debug.Log(test1);

        //var Pattern5Obj = jsonObj["chapters"][0]["questions"][40].ToObject<Pattern5Data>();
        var Pattern5Obj = jsonObj["chapters"][0]["questions"][QuestionID].ToObject<Pattern5Data>();
        Debug.Log("ID = "+ Pattern5Obj.Id + " Problems count = " + Pattern5Obj.problem.Count);
        //for (int i = 0; i < Pattern5Obj.problem.Count; i++)        {
        //    Debug.Log("    " + Pattern5Obj.problem[i]);
        //}

        //QuestionObj.GetComponent<TEXDraw>().text = Pattern5Obj.title;
    }


    public void CreatePrefabs()
    {
        for (int i = 0; i < positionObjs.Count; i++)
        {
            Vector3 locPos = positionObjs[i].GetComponent<RectTransform>().localPosition;
            Debug.Log(positionObjs[i].GetComponent<RectTransform>().position + " " + positionObjs[i].GetComponent<RectTransform>().localPosition);
            //GameObject obj = Instantiate(NumPosPrefab, locPos/*new Vector3(locPos.x, locPos.y, locPos.z)*/, Quaternion.identity);
            GameObject obj = Instantiate(NumPosPrefab, ParentForPos.transform);
            obj.transform.localPosition = locPos;
            ////obj.transform.parent = ParentForPos.GetComponent<RectTransform>().transform;
            ////obj.GetComponent<RectTransform>().transform.DOScale(1, 1);
            ////obj.transform.SetParent(ParentForPos.transform);
            //obj.transform.SetParent(GameObject.FindGameObjectWithTag("ParentPattern5").transform, false);

            //Debug.Log(positionObjs[i].GetComponent<RectTransform>().localPosition);
            //Debug.Log(positionObjs[i].GetComponent<RectTransform>().rect.position);
            //Debug.Log(positionObjs[i].GetComponent<RectTransform>().position);
        }
    }


}

[SerializeField]
public class Pattern5Data
{
    public string Id;
    public int PatternID;
    public string title;    
    public List<string> problem;
    public List<List<string>> solution;
}
