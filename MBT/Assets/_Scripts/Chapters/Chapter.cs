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

    public ChapterRaw chapterRaw = new ChapterRaw();
    JObject jo;
  




    public void UpdateInfo(JObject jsonObj)
    {       
        ChapterNumberTxt.text = chapterRaw.number;
        ChapterNameTxt.text = chapterRaw.name;
        jo = jsonObj;
        JArray questions = (JArray)jo["chapters"][int.Parse(chapterRaw.number)]["questions"];
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
        ES3.Save<int>("NumberOfTestGroup", k);
        ES3.Save<string>("ChapterName", chapterRaw.name);
        ES3.Save<string>("ChapterDescription", chapterRaw.description);        
        GetComponent<SceneManager>().LoadLocalScene();
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


