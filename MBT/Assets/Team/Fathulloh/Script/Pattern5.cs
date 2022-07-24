using Newtonsoft.Json.Linq;
using System;
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

        //ReadFromJson();

        //CreatePrefabs();
    }


    public void ReadFromJson()
    {
        //BobID = Random.Range(0, 10);
        //QuestionID = Random.Range(40, 50);
        var jsonObj = JObject.Parse(JsonText.text);
        //// var Pattern1Obj = jsonObj["chapters"][9]["questions"][ranNum]["question"].ToObject<Pattern1Data>();
        ////var likeName = jsonObj["chapters"][0]["questions"][0]["question"]["options"][0].Value<string>();
        //var ObjPattern5 = jsonObj["chapter"][0]["questions"][40].ToObject<Pattern5Data>();
        //Debug.Log(ObjPattern5.title);
        Debug.Log(jsonObj["chapter"][0]["questions"][0]["id"].Value<String>());
    }


    public void CreatePrefabs()
    {
        for (int i = 0; i < positionObjs.Count; i++)
        {
            Vector3 locPos = positionObjs[i].GetComponent<RectTransform>().localPosition;
            Debug.Log(positionObjs[i].GetComponent<RectTransform>().position + " " + positionObjs[i].GetComponent<RectTransform>().localPosition);
            GameObject obj = Instantiate(NumPosPrefab, locPos/*new Vector3(locPos.x, locPos.y, locPos.z)*/, Quaternion.identity);
            //obj.transform.parent = ParentForPos.GetComponent<RectTransform>().transform;
            //obj.GetComponent<RectTransform>().transform.DOScale(1, 1);
            obj.transform.SetParent(ParentForPos.transform);


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
