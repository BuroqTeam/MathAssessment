using Extension;
using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pattern_11 : GeneralTest
{
    public GameEvent FinishButton;
    public GameObject PushableShadow;
    public GameObject PushableRectangle;
    public GameObject PanelLeft;
    public GameObject PanelRight;
    public List<GameObject> LeftList;
    public List<GameObject> RightList;
    private TextAsset _jsonText;
    public Data_11 DataObj;
    public List<GameObject> NumberInstantiate;
    public List<string> Answer;
    public List<char> AlphabetList = new();
    public List<string> Correct;
    public List<string> ReverseCorrect;
    public bool _istrue = true;
    int n;

    private void OnEnable()
    {
        if (ES3.Load<bool>("Pattern_11_Check"))
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
    public void ReadFromJson()
    {
        var jsonObj = JObject.Parse(_jsonText.text);
        JObject jo = Mbt.LoadJsonPath(jsonObj, "Pattern_11");
        DataObj = jo.ToObject<Data_11>();        
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
            bool _onTrue = LeftList[i].GetComponent<PushableShadow>()._IsEmpty;
            if (!_onTrue)
            {
                n++;
            }
        }

        if (n == str.Count)
        {
            if (TestManager.Instance.CheckIsLast())
            {
                FinishButton.Raise();
            }
            else
            {
                
            }
            ES3.Save<bool>("Pattern_11_Check", true);
        }
        else
        {
            
            ES3.Save<bool>("Pattern_11_Check", false);
            GameManager.Instance.CurrentCircleObj.IsDone = false;
            GetComponent<Pattern>().IsStatus = false;
        }
    }

    void StartMetod()
    {
        for (char ci = 'a'; ci <= 'z'; ++ci)
        {
            AlphabetList.Add(ci);
        }

        List<string> str = DataObj.options;
        for (int i = 0; i < str.Count; i++)
        {
            string strAlphabet = "[" + AlphabetList[i] + "]";
            for (int j = 0; j < str.Count; j++)
            {
                var likeName = DataObj.options[j];
                if (likeName.Contains(strAlphabet))
                {
                    Correct.Add(DataObj.options[j]);
                    break;
                }
            }

        }

        str = str.ShuffleList();
        DataObj.options = str;
        
        for (int i = 0; i < str.Count; i++)
        {
            
            var likeName = DataObj.options[i];
                 

            if (likeName.Contains('['))
            {
                likeName = likeName.Replace("[a]", "");
                likeName = likeName.Replace("[b]", "");
                likeName = likeName.Replace("[c]", "");
                likeName = likeName.Replace("[d]", "");
                likeName = likeName.Replace("[e]", "");
                likeName = likeName.Replace("[f]", "");
            }
            DataObj.options[i] = likeName;


            GameObject right = Instantiate(PushableRectangle, PanelRight.transform);
            RightList.Add(right);
            PanelRight.transform.GetChild(i).transform.GetChild(0).transform.GetChild(0).GetComponent<TEXDraw>().text = str[i].ToString();
            GameObject left = Instantiate(PushableShadow, PanelLeft.transform);           
            LeftList.Add(left);
           
        }
        for (int i = 0; i < RightList.Count; i++)
        {
            RightList[i].transform.GetChild(0).GetComponent<PushableRectangle>().Pattern11 = this;
            RightList[i].transform.GetChild(0).GetComponent<PushableRectangle>().Positions = LeftList;
        }
        
    }
    public void Checking()
    {
        List<string> str = DataObj.options;
        Answer.Clear();
        for (int i = 0; i < str.Count; i++)
        {
            string mainString = LeftList[i].GetComponent<PushableShadow>().CurrentNumber;
            Answer.Add(mainString);
            
        }
    }


    //Correct = Rever
    public void Check()
    {
        List<bool> currentList = new();
        currentList = ES3.Load<List<bool>>("ResultList");
        for (int i = 0; i < Correct.Count; i++)
        {

            var likeName = Correct[i];


            if (likeName.Contains('['))
            {
                likeName = likeName.Replace("[a]", "");
                likeName = likeName.Replace("[b]", "");
                likeName = likeName.Replace("[c]", "");
                likeName = likeName.Replace("[d]", "");
                likeName = likeName.Replace("[e]", "");
                likeName = likeName.Replace("[f]", "");
            }
           Correct[i] = likeName;
        }
       
        ReverseCorrect = new List<string>(Correct);
        ReverseCorrect.Reverse();

        if (Correct.SequenceEqual(Answer))
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
            Debug.Log("Correct");
        }
        else if (ReverseCorrect.SequenceEqual(Answer))
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = true;
            Debug.Log("Correct");
        }
        else
        {
            currentList[GetComponent<Pattern>().QuestionNumber] = false;
            Debug.Log("Wrong");
        }
        ES3.Save("ResultList", currentList);
        ES3.Save<bool>("Pattern_11_Check", true);
       
    }
    
}

[SerializeField]
public class Data_11
{
    public string title;
    public List<string> options = new();
}