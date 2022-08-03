using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pattern_9 : MonoBehaviour
{
    public TextAsset JsonText;
    private GameObject MainParent;
    public GameObject QuestionObj;

    public GameObject ParentComparisonPrefab;

    Data_9 Pattern_9Obj = new Data_9();


    public List<GameObject> ComparisonObjects;

    public TMP_Text TextForTranslating;

    float yPos, xPos, yDistance, xDistance;
    int totalFullAns, totalCorrectAns;

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

        Pattern_9Obj = jsonObj["chapters"][1]["questions"][59]["question"].ToObject<Data_9>();
        CreatePrefabs();
    }


    void CreatePrefabs()
    {
        QuestionObj.GetComponent<TEXDraw>().text = Pattern_9Obj.title;  //
        int optionsCount = Pattern_9Obj.options.Count;

        xDistance = ParentComparisonPrefab.transform.GetChild(1).position.x - ParentComparisonPrefab.transform.GetChild(0).position.x ;
        xPos = xDistance - ParentComparisonPrefab.transform.GetChild(0).GetComponent<RectTransform>().rect.width;
        yDistance = xPos + ParentComparisonPrefab.transform.GetChild(0).GetComponent<RectTransform>().rect.height;
        Debug.Log("xDistance = " + xDistance + " yDistance = " + yDistance);

        for (int i = 0; i < optionsCount; i++)
        {
            GameObject obj = Instantiate(ParentComparisonPrefab, this.transform);
            Vector3 oldPos = obj.transform.localPosition;
            obj.transform.GetChild(1).GetComponent<DropDownP9>().TextForTranslating = TextForTranslating.text;

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
            //ComparisonObjects[i].transform.GetChild(1).GetComponent<DropDownP9>().CorrectAnswer = Pattern_9Obj.options[i].sign.ToString();
            ComparisonObjects[i].transform.GetChild(2).transform.GetChild(0).GetComponent<TEXDraw>().text = Pattern_9Obj.options[i].right;
        }

    }

    
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

