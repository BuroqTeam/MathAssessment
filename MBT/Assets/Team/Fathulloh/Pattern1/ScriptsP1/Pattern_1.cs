using Extension;
using MBT.Extension;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Pattern_1 : TestManager
{   
    private TextAsset _currentJsonText;    
    
    public List<char> AlphabetList = new List<char>();
    public List<GameObject> ABCD;
    public GameObject PrefabA;   
        
    public GameObject MainParent;
    public GameObject CurrentClickedObj;

    Data_1 Pattern_1Obj = new Data_1();
    float yPos, yLength;
    bool _isTrue = true;

    private void OnEnable()
    {
        if (_isTrue)
        {
            _isTrue = false;
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
        }        

        DisplayQuestion(Pattern_1Obj.title);
    }


    private void FirstMethod()
    {
        for (char c = 'A'; c <= 'Z'; ++c)
        {
            AlphabetList.Add(c);
        }

        //Mbt.SaveJsonPath("Pattern_1", 0, 6);
        //ES3.Save<string>("LanguageKey", "Uzb");
        //ES3.Save<int>("ClassKey", 6);
        //JsonCollectionSO.DataBase.Clear();
        //CurrentJsonText = Mbt.GetDesiredData(JsonCollectionSONew);

        ReadFromJson();
    }
        

    public void ReadFromJson()
    {        
        var jsonObj = JObject.Parse(_currentJsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_1");
        Pattern_1Obj = jo.ToObject<Data_1>();
        CreatePrefabs2();
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

