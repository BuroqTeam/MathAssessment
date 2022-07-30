using Extension;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_1 : TestManagerSample
{           // var PatternObj = jsonObj["chapters"][bob raqami]["questions"][savol raqami]["question"]    
    public GameObject QuestionObj;
    public TextAsset JsonText;

    public List<GameObject> ABCD;
    public GameObject PrefabA;

    public List<char> AlphabetList = new List<char>();
    float yPos, yLength;

    public GameObject MainParent;
    public GameObject CurrentClickedObj;


    public Data_1 Pattern1Obj = new Data_1();
    //public RawCsharp Rsharp = new RawCsharp();

    void Start()
    {
        MainParent = gameObject.transform.parent.transform.parent.gameObject;

        QuestionObj = gameObject.transform.parent.transform.parent.GetChild(8).gameObject;
        Debug.Log(gameObject.transform.parent.transform.parent.GetChild(8).gameObject.name);
        //Debug.Log(MainParent.transform.GetChild(MainParent.transform.childCount - 2).gameObject.name);

        for (char c = 'A'; c <= 'Z'; ++c)
        {
            AlphabetList.Add(c);
        }

        WriteTest();             
    }


    //private void OnEnable()
    //{
    //    DisplayQuestion(Pattern1Obj.title);
    //}


    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
        //QuestionObj.GetComponent<TEXDraw>().text = Pattern1Obj.question.title;

        //CreatePrefabs();
    }

    

    public void CreatePrefabs()
    {
        int n = Pattern1Obj.options.Count;
        //float yPos, yLength;

        if (n == 4) 
        {
            yPos = 250;
            yLength = 125;
        }

        for (int i = 0; i < n; i++)
        {
            GameObject obj = Instantiate(PrefabA, this.transform);
            Vector3 oldPos = obj.transform.localPosition;
            obj.transform.localPosition = new Vector3(oldPos.x, yPos - yLength * i, 0);
            obj.transform.GetChild(1).GetComponent<TEXDraw>().text = AlphabetList[i].ToString();
            ABCD.Add(obj);
        }
    }


    public void WriteTest()
    {
        var jsonObj = JObject.Parse(JsonText.text);
        int ranNum = Random.Range(0, 10);

        //JArray jsonObj2 = (JArray)jsonObj["chapters"];
        //Rsharp = jsonObj2.ToObject<RawCsharp>();
        //Debug.Log(Rsharp.chapters[0].number);

        // var PatternObj = jsonObj["chapters"][bob raqami]["questions"][savol raqami]["question"]
        Pattern1Obj = jsonObj["chapters"][2]["questions"][0]["question"].ToObject<Data_1>();     // Jsondan o'qilgan malumotni Classga kirituvchi kod.         
        Debug.Log(" Count of characters = " + Pattern1Obj.title.Length);

        if (Pattern1Obj.title.Length > 150)
        {
            QuestionObj.GetComponent<TEXDraw>().size = 38;
        }
        else
        {
            QuestionObj.GetComponent<TEXDraw>().size = 50;
        }

        QuestionObj.GetComponent<TEXDraw>().text = Pattern1Obj.title;

        CreatePrefabs();

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
public class Data_1
{
    public string title;
    //public string[] options;
    public List<string> options;
}



//[SerializeField]
//public class RawCsharp
//{
//    public List<RRRR> chapters = new List<RRRR>();
//}

//[SerializeField]
//public class RRRR
//{
//    public int number;
//    public string name;
//    public string question;
//}
