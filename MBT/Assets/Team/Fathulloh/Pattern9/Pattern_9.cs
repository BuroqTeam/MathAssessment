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

        Pattern_9Obj = jsonObj["chapters"][1]["questions"][50]["question"].ToObject<Data_9>();
        CreatePrefabs();
    }


    void CreatePrefabs()
    {
        QuestionObj.GetComponent<TEXDraw>().text = Pattern_9Obj.title;  //
        //int statementCount = Pattern_9Obj.options.Count;

        for (int i = 0; i < Pattern_9Obj.options.Count; i++)
        {
            GameObject obj = Instantiate(ParentComparisonPrefab, this.transform);
            Vector3 oldPos = obj.transform.localPosition;
            obj.transform.GetChild(1).GetComponent<DropDownP9>().TextForTranslating = TextForTranslating.text;
            obj.transform.localPosition = new Vector3(oldPos.x, oldPos.y * (i + 1) - 30 * i, oldPos.z) ;
            Debug.Log(new Vector3(oldPos.x, oldPos.y * (-i - 1) - 30 * i, oldPos.z));
            ComparisonObjects.Add(obj);
        }

        Debug.Log(" TextForTranslating = " + TextForTranslating.text);
    }


    



}


public class Data_9
{
    public string title;
    public List<Options_9> options = new List<Options_9>();
}

public class Options_9
{
    public string left;
    public char sign;
    public string right;
}

