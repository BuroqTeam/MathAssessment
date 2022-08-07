using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pattern_9 : MonoBehaviour
{
    private TextAsset _currentJsonText;

    public GameObject ParentComparisonPrefab;
    public List<GameObject> ComparisonObjects;

    Data_9 Pattern_9Obj = new Data_9();    

    public TMP_Text TextForTranslating;
    float xPos, yDistance, xDistance;
    int totalFullAns, totalCorrectAns;


    private void OnEnable()
    {
        _currentJsonText = GetComponent<Pattern>().Json;
        if (_currentJsonText != null)
        {
            Debug.Log(_currentJsonText.text);
        }
        else
        {
            Debug.Log("Not Found Data");
        }

        FirstMethod();

        //DisplayQuestion(Pattern_9Obj.title);
    }


    private void FirstMethod()
    {   // 4-bob 40-49    7-bob 50-59(49, 58),      8-bob 50-59
        //Mbt.SaveJsonPath("Pattern_9",8, 55);

        //ES3.Save<string>("LanguageKey", "Uzb");

        //ES3.Save<int>("ClassKey", 6);

        //JsonCollectionSO.DataBase.Clear();
        //CurrentJsonText = Mbt.GetDesiredData(JsonCollectionSONew);
        ReadFromJson();
    }



    //public override void DisplayQuestion(string questionStr)
    //{
    //    base.DisplayQuestion(questionStr); // null        
    //}


    void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_9");
        Pattern_9Obj = jo.ToObject<Data_9>();
        CreatePrefabs();
    }


    void CreatePrefabs()
    {
        //QuestionObj.GetComponent<TEXDraw>().text = Pattern_9Obj.title;  //-
        int optionsCount = Pattern_9Obj.options.Count;

        xDistance = ParentComparisonPrefab.transform.GetChild(1).position.x - ParentComparisonPrefab.transform.GetChild(0).position.x ;
        xPos = xDistance - ParentComparisonPrefab.transform.GetChild(0).GetComponent<RectTransform>().rect.width;
        yDistance = xPos + ParentComparisonPrefab.transform.GetChild(0).GetComponent<RectTransform>().rect.height;
        //Debug.Log("xDistance = " + xDistance + " yDistance = " + yDistance);

        for (int i = 0; i < optionsCount; i++)
        {
            GameObject obj = Instantiate(ParentComparisonPrefab, this.transform);
            Vector3 oldPos = obj.transform.localPosition;
            //obj.transform.GetChild(1).GetComponent<DropDownP9>().TextForTranslating = TextForTranslating.text;

            if (i != 0)             {
                obj.transform.localPosition = new Vector3(oldPos.x, oldPos.y - yDistance * i, oldPos.z);
            }              
            ComparisonObjects.Add(obj);
        }

        WriteToPrefab();
    }


    void WriteToPrefab()
    {
        for (int i = 0; i < ComparisonObjects.Count; i++)
        {
            ComparisonObjects[i].transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_9Obj.options[i].left;
            ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP9>().CorrectAnswer = Pattern_9Obj.options[i].sign.ToString();
            ComparisonObjects[i].transform.GetChild(2).transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_9Obj.options[i].right;
        }
    }


    //void Check()
    //{
    //    List<bool> myList = new List<bool>();

    //    ES3.Save("ResultList", myList);
    //    bool ca = true;

    //    List<bool> currentList = new List<bool>();
    //    currentList = ES3.Load<List<bool>>("ResultList");

    //    if (ca)
    //    {
    //        currentList[GetComponent<Pattern>().QuestionNumber] = true;
    //    }
    //    else
    //    {
    //        currentList[GetComponent<Pattern>().QuestionNumber] = false;
    //    }
    //    ES3.Save("myList", currentList);


    //}



    public void CheckAllAnswers()
    {
        int n = Pattern_9Obj.options.Count;

        for (int i = 0; i < n; i++)
        {
            totalFullAns = 0;
            totalCorrectAns = 0;
            string currentAnswer = ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP9>().CurrentAnswer;
            string correctAnswer = ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP9>().CorrectAnswer;
            if (currentAnswer != null)
                totalFullAns++;
            if (correctAnswer == currentAnswer)
                totalCorrectAns++;
        }

        if (totalCorrectAns == n)        {
            Debug.Log("Everything is true.");
        }
        else if (totalFullAns == n)        {
            Debug.Log("Some thing is wrong.");
        }

    }


}


[SerializeField]
public class Data_9
{
    public string title;
    public List<Options_9> options = new List<Options_9>();
}

[SerializeField]
public class Options_9
{
    public string left;
    public char sign;
    public string right;
}


