using MBT.Extension;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Chapter : MonoBehaviour
{
    public Flower FlowerObj;   
    public Image SliderFill;
    public TMP_Text ChapterNumberTxt;
    public TMP_Text ChapterNameTxt;
    public IList<Question> questionGroup;

    public ChapterRaw chapterRaw = new();
    JObject jo;


    public GameObject MainObject;   //F++


    public void UpdateInfo(JObject jsonObj)
    {       
        ChapterNumberTxt.text = chapterRaw.number;
        ChapterNameTxt.text = chapterRaw.name;
        jo = jsonObj;
        
        JArray questions = (JArray)jo["chapters"][chapterRaw.index]["questions"];
        questionGroup = questions.ToObject<IList<Question>>();
        
        // questionGroup.Count  100
        // TestGroup.questions o'ziga tegishli savollar ni oladi       
    }

    public void SetPath()
    {
        string sample = questionGroup[0].pattern;       
        int k = 0;
        for (int i = 0; i < questionGroup.Count; i++)
        {            
            if (sample.Equals(questionGroup[i].pattern))
            {
                k++;
            }
        }
        JArray questions = (JArray)jo["chapters"][chapterRaw.index]["questions"];
        ES3.Save<int>("Chapter", chapterRaw.index);        
        ES3.Save<int>("NumberOfTestGroup", k);
        ES3.Save<string>("ChapterName", chapterRaw.name);
        ES3.Save<string>("ChapterDescription", chapterRaw.description);        
        GetComponent<SceneManager>().LoadLocalScene();
        MainObject.GetComponent<ChapterManager>().UnEnableButtons();    //F++
    }

}


[SerializeField]
public class ChapterRaw
{
    public string number;
    public string name;
    public string description;
    public int index;
    
}

[SerializeField]
public class Question
{
    public string pattern;
    

}


