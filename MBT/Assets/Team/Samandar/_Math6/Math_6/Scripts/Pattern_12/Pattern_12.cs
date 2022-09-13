using Extension;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_12 : GeneralTest
{
    public GameEvent FinishButton;
    private TextAsset _jsonText;
    public Data_12 DataObj;
    public GameObject Answers;
    public List<char> AlphabetList = new();
    public List<GameObject> ABCD;
    public GameObject ButtonPrefabs;
    public bool _Pattern;
    public bool _IsTrue;
    public ButtonAnswer buttonAnswer;
    public bool _istrue = true;
    public int WrongAns;
    int n;
    
    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_jsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_12");
        DataObj = jo.ToObject<Data_12>();
    }

    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
    }

    public void OnTrue()
    {
        n = 0;
        List<string> str = DataObj.options;
        for (int i = 0; i < str.Count; i++)
        {
            bool _onTrue = ABCD[i].GetComponent<ButtonAnswer>()._isTrue;
            if (_onTrue)
            {
                n++;
            }
        }
        if (n > 0)
        {                    
            ES3.Save<bool>("Pattern_12_Check", true);
            GetComponent<Pattern>().IsEdited = true;
            TestManager.Instance.CheckAllIsDone();
        }
        else if (n == 0)
        {
            ES3.Save<bool>("Pattern_12_Check", false);
            GetComponent<Pattern>().IsEdited = false;
            TestManager.Instance.CheckAllIsDone();
        }
    }

    private void OnEnable()
    {
        if (ES3.Load<bool>("Pattern_12_Check"))
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
            StartMetod();
        }
        DisplayQuestion(DataObj.title);
             
    }
    
    void StartMetod()
    {
        for (char ci = 'A'; ci <= 'Z'; ++ci)
        {
            AlphabetList.Add(ci);
        }
        List<string> str = DataObj.options;
        for (int i = 0; i < str.Count; i++)
        {
            GameObject obj = Instantiate(ButtonPrefabs, Answers.transform);
            obj.transform.GetChild(0).GetComponent<TEXDraw>().text = AlphabetList[i].ToString();
            ABCD.Add(obj);
        }


        str = str.ShuffleList();
        DataObj.options = str;

        for (int i = 0; i < ABCD.Count; i++)
        {
            var likeName = DataObj.options[i];
            ABCD[i].GetComponent<ButtonAnswer>().Pattern12 = this;

            if (likeName.Contains('*'))
            {
                ABCD[i].GetComponent<ButtonAnswer>()._pattern = true;
                likeName = likeName.Replace("[*]", "");
            }
            ABCD[i].GetComponent<ButtonAnswer>().WriteCurrentAnswer(likeName);
        }
    }
    
    public void Check()
    {
        WrongAns = 0;
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        for (int i = 0; i <ABCD.Count ; i++)
        {
            _IsTrue = ABCD[i].transform.GetComponent<ButtonAnswer>()._isTrue;
            _Pattern = ABCD[i].transform.GetComponent<ButtonAnswer>()._pattern;
            if (_IsTrue == true && _Pattern == true)
            {

            }
            else if(_IsTrue == true && _Pattern == false)
            {
                WrongAns++;
            }
            else if (_IsTrue == false && _Pattern == true)
            {
                WrongAns++;
            }
            else
            {
                
            }
        }

        if (WrongAns != 0)
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
            //Debug.Log("Wrong");
            
        }

        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
            //Debug.Log("Correct");
        }
        ES3.Save("ResultList", currentList);
        ES3.Save<bool>("Pattern_12_Check", true);
    }
      
}

[SerializeField]
public class Data_12
{
    public string title;
    public List<string> options;
}
