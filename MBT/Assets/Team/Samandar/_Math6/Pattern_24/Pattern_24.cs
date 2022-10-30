using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_24 : GeneralTest
{
    public GameEvent FinishButton;
    private TextAsset _jsonText;
    public GameObject Problem;
    public Data_24 DataObj;
    public GameObject Solution;
    public GameObject ConsiderationsPrefabs;
    public List<Button> buttonGroup = new();
    public ColorCollectionSO colorCollection;
    public AnswerPattern_24 AnswerPattern_24;
    public bool _click;

    public bool _pattenBool;
    public bool _istrue = true;

    public void Check()
    {
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");

        if (_pattenBool == true && _click == true)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
            //Debug.Log("Corrent");
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
            //Debug.Log("Wrong");
        }
        ES3.Save("ResultList", currentList);
        ES3.Save<bool>("Pattern_24_Check", true);

    }

    private void OnEnable()
    {
        if (ES3.Load<bool>("Pattern_24_Check"))
        {

        }
        else
        {

        }
        if (_istrue)
        {
            _istrue = false;
            _jsonText = GetComponent<Pattern>().Json;
            ReadFromJson();
            PrefabsInstantiate();
            StartMetod();
        }

        //_jsonText = Mbt.GetDesiredData(_jsCollection);
        DisplayQuestion(DataObj.title);

    }

    public void Active()
    {
        if (_click)
        {
            ES3.Save<bool>("Pattern_24_Check", true);
            GetComponent<Pattern>().IsEdited = true;
            TestManager.Instance.CheckAllIsDone();
        }
    }
    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_jsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_24");
        DataObj = jo.ToObject<Data_24>();
    }
    string str;
    void StartMetod()
    {
        //string str;
        List<string> problem1 = DataObj.problem;
        for (int i = 0; i < problem1.Count; i++)
        {
            if (i == 0)
            {
                str += problem1[i];
            }
            else
            {
                str += "," + " " + problem1[i];
            }
            Problem.transform.GetChild(0).GetComponent<TEXDraw>().text = str;
        }

    }

    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }

    void PrefabsInstantiate()
    {
        List<string> solution1 = DataObj.solution;
        for (int i = 0; i < solution1.Count; i++)
        {
            GameObject obj = Instantiate(ConsiderationsPrefabs, Solution.transform);
            buttonGroup.Add(obj.GetComponent<Button>());
            var likeName = DataObj.solution[i];
            Solution.transform.GetChild(i).transform.GetComponent<AnswerPattern_24>().Pattern24 = this;

            if (likeName.Contains('*'))
            {
                Solution.transform.GetChild(i).transform.GetComponent<AnswerPattern_24>()._PattenBool = true;
                likeName = likeName.Replace("[*]", "");
            }
            DataObj.solution[i] = likeName;


            Solution.transform.GetChild(i).transform.GetChild(0).transform.GetComponent<TEXDraw>().text = solution1[i];
            if (Solution.transform.childCount == 2)
            {
                Solution.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<TEXDraw>().color = colorCollection.Green;
                Solution.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<TEXDraw>().color = colorCollection.Red;
            }
            else if (Solution.transform.childCount == 3)
            {
                Solution.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<TEXDraw>().color = colorCollection.Green;
                Solution.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<TEXDraw>().color = colorCollection.Green;
                Solution.transform.GetChild(2).transform.GetChild(0).transform.GetComponent<TEXDraw>().color = colorCollection.Green;
            }
        }
    }
}

[SerializeField]
public class Data_24
{
    public string title;
    public List<string> problem = new();
    public List<string> solution = new();
}