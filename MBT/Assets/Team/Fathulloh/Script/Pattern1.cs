using Extension;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1 : MonoBehaviour
{           // var PatternObj = jsonObj["chapters"][bob raqami]["questions"][savol raqami]["question"]
    public List<GameObject> ABCD;
    public GameObject QuestionObject;
    public TextAsset JsonText;

    public GameObject MainParent;

    public GameObject CurrentClickedObj;
    

    void Start()
    {
        MainParent = gameObject.transform.parent.transform.parent.gameObject;

        QuestionObject = gameObject.transform.parent.transform.parent.GetChild(8).gameObject;
        Debug.Log(gameObject.transform.parent.transform.parent.GetChild(8).gameObject.name);
        //Debug.Log(MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject.name);

        WriteTest();
    }


    public void WriteTest()
    {
        var jsonObj = JObject.Parse(JsonText.text);
        int ranNum = Random.Range(0, 10);       

        // var PatternObj = jsonObj["chapters"][bob raqami]["questions"][savol raqami]["question"]
        var Pattern1Obj = jsonObj["chapters"][0]["questions"][ranNum]["question"].ToObject<Pattern1Data>();     // Jsondan o'qilgan malumotni Classga kirituvchi kod.  
        Debug.Log("Current Question Number = " + ranNum + " " + " Type of variable : " + Pattern1Obj.options.GetType());

        QuestionObject.GetComponent<TEXDraw>().text = Pattern1Obj.title;

        List<string> str = Pattern1Obj.options;
        str = str.ShuffleList();
        Pattern1Obj.options = str;

        for (int i = 0; i < ABCD.Count; i++)
        {
            var likeName = Pattern1Obj.options[i];
            ABCD[i].GetComponent<AnswerPattern1>().PatternOne = this;

            if (likeName.Contains('*'))
            {
                ABCD[i].GetComponent<AnswerPattern1>()._IsTrue = true;
                likeName = likeName.Replace("[*]", "");
            }
            ABCD[i].GetComponent<AnswerPattern1>().WriteCurrentAnswer(likeName);
        }        
    }


    public void UnClickedButtons()
    {
        for (int i = 0; i < ABCD.Count; i++)
        {
            ABCD[i].GetComponent<AnswerPattern1>().DisableObject();                        
        }


        StartCoroutine(Waiting());
    }


    public IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2);
        ShowWrongClick();
    }


    /// <summary>
    /// Xato javob belgilangan bo'lsa qizilga bo'yab beruvchi method. 
    /// Ushbu methodni Tugatish tugmasi bosilgandan keyin chaqirishimiz zarur.
    /// Buyerda tekshirish uchun Waiting methodini ichida chaqirilgan.
    /// </summary>
    public void ShowWrongClick()
    {
        bool isTrue = CurrentClickedObj.GetComponent<AnswerPattern1>()._IsTrue;
        if (!isTrue)
            CurrentClickedObj.GetComponent<AnswerPattern1>().WrongClickAction();
        else
            Debug.Log("The best Answer :) ");        
        
    }



}

[SerializeField]
public class Pattern1Data
{
    public string title;
    //public string[] options;
    public List<string> options;
}
