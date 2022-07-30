using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using Unity.VisualScripting;
using System.Linq;

public class Chapter : MonoBehaviour
{
    public Flower FlowerObj;   
    public Image SliderFill;
    public TMP_Text ChapterNumberTxt;
    public TMP_Text ChapterNameTxt;
    public IList<Question> questionGroup;

    public ChapterRaw chapterRaw = new ChapterRaw();
    JObject jo;
    public TestGroupSO TestGroup;




    public void UpdateInfo(JObject jsonObj)
    {       
        ChapterNumberTxt.text = chapterRaw.number;
        ChapterNameTxt.text = chapterRaw.name;
        jo = jsonObj;
        JArray questions = (JArray)jo["chapters"][int.Parse(chapterRaw.number)]["questions"];
        questionGroup = questions.ToObject<IList<Question>>();
        TestGroup.questions = questions;
        
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
        TestGroup.NumberOfTestGroup = k;
        TestGroup.Name = chapterRaw.name;
        TestGroup.Description = chapterRaw.description;
    }

}


[SerializeField]
public class ChapterRaw
{
    public string number;
    public string name;
    public string description;
    
}

[SerializeField]
public class Question
{
    public string pattern;
    

}


