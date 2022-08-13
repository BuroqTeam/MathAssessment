using Extension;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_1 : GeneralTest
{
    public GameEvent ActiveNext;
    public GameEvent DeactiveNext;
    //public TextAsset CurrentJsonText;
    private TextAsset _currentJsonText;

    public List<char> AlphabetList = new();
    public List<GameObject> ABCD;
    public GameObject PrefabA;

    public GameObject MainParent;
    public GameObject CurrentClickedObj;

    public bool CurrentAnswerStatus;

    Data_1 Pattern_1Obj = new();
    float yPos, yLength;
    bool _isTrue = true;

    private void OnEnable()
    {
        if (ES3.Load<bool>("Pattern_1_Check"))
        {
            ActiveNext.Raise();
        }
        else
        {
            DeactiveNext.Raise();
        }

        if (_isTrue)
        {
            _isTrue = false;
            _currentJsonText = GetComponent<Pattern>().Json;
                        
            ReadFromJson();
        }
        DisplayQuestion(Pattern_1Obj.title);
    }


    //private void Awake()
    //{
    //    //TestManager.Instance.PassToNextClicked += Check;

    //    //Mbt.SaveJsonPath("Pattern_1", 7, 7);
    //    //ES3.Save<string>("LanguageKey", "Uzb");
    //    //ES3.Save<int>("ClassKey", 6);
    //    ////JsonCollectionSO.DataBase.Clear();
    //    ////CurrentJsonText = Mbt.GetDesiredData(JsonCollectionSONew);

    //    //ReadFromJson();
    //}


    public void ReadFromJson()
    {
        //var jsonObj = JObject.Parse(CurrentJsonText.text);
        for (char c = 'A'; c <= 'Z'; ++c)
        {
            AlphabetList.Add(c);
        }

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


    
    public void Check()
    {        
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");

        if (CurrentAnswerStatus)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
        }
        ES3.Save("myList", currentList);

        ES3.Save<bool>("Pattern_1_Check", true);

        //ActivateNext();
    }


    //void ActivateNext()
    //{
    //    int index = TestManager.Instance.ActivePatterns.FindIndex(o => o == gameObject);
    //    index++;
    //    TestManager.Instance.ActivePatterns[index].SetActive(true);
    //    gameObject.SetActive(false);
    //}



    public void UnClickedButtons()
    {
        for (int i = 0; i < ABCD.Count; i++)
        {
            ABCD[i].GetComponent<AnswerPattern1>().DisableObject();
        }

        //StartCoroutine(ShowWrongClick());
    }


    /// <summary>
    /// Xato javob belgilangan bo'lsa qizilga bo'yab beruvchi method. 
    /// Ushbu methodni Tugatish tugmasi bosilgandan keyin chaqirishimiz zarur.
    /// </summary>
    public IEnumerator ShowWrongClick()
    {
        yield return new WaitForSeconds(2);
        //ShowWrongClick();
        bool isTrue = CurrentClickedObj.GetComponent<AnswerPattern1>()._IsTrue;
        if (!isTrue)
        {
            //CurrentClickedObj.GetComponent<AnswerPattern1>().WrongClickAction();
            Debug.Log("Answer is Wrong");
        }
        else
            Debug.Log("Answer is Correct. The best Answer :) ");
    }



    bool _IsActiveButton = true;
    

    public void ActeveteButton()
    {
        if (_IsActiveButton)
        {
            ActiveNext.Raise();
            _IsActiveButton = false;
            ES3.Save<bool>("Pattern_1_Check", true);
        }
       
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

