using Extension;
using MBT.Extension;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Pattern_1 : TestManagerSample
{           // var PatternObj = jsonObj["chapters"][bob raqami]["questions"][savol raqami]["question"]    
    //public AssetReference ButtonA;
    //public DataBaseSO dataBase;
    //private AssetReference _jsonData;
    //public GameObject QuestionObj;      //---
    //public TextAsset JsonText;

    public DataBaseSO CurrentDataBase;
    public TextAsset CurrentJsonText;    
    
    public List<char> AlphabetList = new List<char>();
    public List<GameObject> ABCD;
    public GameObject PrefabA;   
        
    public GameObject MainParent;
    public GameObject CurrentClickedObj;

    Data_1 Pattern_1Obj = new Data_1();
    float yPos, yLength;

    
    private void FirstMethod()
    {
        for (char c = 'A'; c <= 'Z'; ++c)
        {
            AlphabetList.Add(c);
        }

        //Mbt.SaveJsonPath("Pattern_1", 0, 6);
        //ES3.Save<string>("LanguageKey", "Uzb");

        //ES3.Save<int>("ClassKey", 6);


        CurrentDataBase.DataBase.Clear();
        CurrentJsonText = Mbt.GetDesiredJSONData(CurrentDataBase);
        ReadFromJson();
    }
        

    public void ReadFromJson()
    {        
        var jsonObj = JObject.Parse(CurrentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_1");
        Pattern_1Obj = jo.ToObject<Data_1>();
        CreatePrefabs2();
    }


    private void OnEnable()
    {
        FirstMethod();

        DisplayQuestion(Pattern_1Obj.title);
    }


    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }


    public void CreatePrefabs2()
    {
        int n = Pattern_1Obj.options.Count;

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
            //Debug.Log( yPos - yLength * i);
            obj.transform.GetChild(1).GetComponent<TEXDraw>().text = AlphabetList[i].ToString();
            ABCD.Add(obj);
        }

        List<string> str = Pattern_1Obj.options;
        str = str.ShuffleList();
        Pattern_1Obj.options = str;

        for (int i = 0; i < ABCD.Count; i++)
        {
            var likeName = Pattern_1Obj.options[i];
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
        {
            CurrentClickedObj.GetComponent<AnswerPattern1>().WrongClickAction();
            Debug.Log("Answer is Wrong");
        }
        else
            Debug.Log("Answer is Correct. The best Answer :) ");           
    }


}

[SerializeField]
public class Data_1
{
    public string title;    
    public List<string> options;
}


//if (Pattern1Obj.title.Length > 150)       // Yozuv o'lchamini almashtirib beruvchi method.
//{
//    QuestionObj.GetComponent<TEXDraw>().size = 38;
//}
//else
//{
//    QuestionObj.GetComponent<TEXDraw>().size = 50;
//}

