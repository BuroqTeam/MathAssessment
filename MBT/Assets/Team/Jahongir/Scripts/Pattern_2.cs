using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using DG.Tweening;

public class Pattern_2 : TestManager
{
    public string SampleQuestion;
    public TextAsset jsonText;
    public GameObject Buttons;
    //public GameObject QuestionObj;
    private GameObject MainParent;
    Data_2 Pattern_2Obj = new Data_2();
    void Start()
    {
        //MainParent = gameObject.transform.parent.transform.parent.gameObject;
        //QuestionObj = MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject;
    }
    private void OnEnable()
    {
        DisplayQuestion(SampleQuestion);
    }
    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
        ReadFromJson();
    }
    public void ReadFromJson()
    {
        int QuestionID = 10;
        var jsonObj = JObject.Parse(jsonText.text);
        Pattern_2Obj = jsonObj["chapters"][0]["questions"][QuestionID]["question"].ToObject<Data_2>();
        SampleQuestion = Pattern_2Obj.title;
        CreatePrefabs();
    }
    public void CreatePrefabs()
    {
        if (Pattern_2Obj.options.Count % 4 == 0)
        {
            int x = -100, y = 100, w=0;
            for (int i = 0; i < Pattern_2Obj.options.Count; i++)
            {
                if (i< Pattern_2Obj.options.Count/2)
                {
                    GameObject button = Instantiate(Buttons, transform);
                    button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(x - ((Pattern_2Obj.options.Count / 4 - 1)-i) * 200, y, 0);
                    button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_2Obj.options[i];
                }
                else
                {
                    GameObject button = Instantiate(Buttons, transform);
                    button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(x - ((Pattern_2Obj.options.Count / 4 - 1) - w) * 200, -y, 0);
                    button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_2Obj.options[i];
                    w++;
                }
            }
        }
        else
        {
            int x = 0, y = 100, q = 0;
            for (int i = 0; i < Pattern_2Obj.options.Count; i++)
            {
                if (i < Pattern_2Obj.options.Count / 2)
                {
                    GameObject button = Instantiate(Buttons, transform);
                    button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3((-(Pattern_2Obj.options.Count / 4) + i) * 200, y, 0);
                    button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_2Obj.options[i];
                }
                else
                {
                    GameObject button = Instantiate(Buttons, transform);
                    button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3((-(Pattern_2Obj.options.Count / 4) + q) * 200, -y, 0);
                    button.transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_2Obj.options[i];
                    q++;
                }
            }
        }
    }
}

[SerializeField]
public class Data_2
{
    public string title;
    public List<string> options;
}


