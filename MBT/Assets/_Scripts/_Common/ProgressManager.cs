using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{

    public ChapterManager chapterManager;
    public ProgressKeySO ProgressSave;

    private void Awake()
    {
        chapterManager = GetComponent<ChapterManager>();
    }

    public void CheckSaveCondition()
    {        
        if (ES3.KeyExists(ProgressSave.Key + ES3.Load<string>("Subject") + ES3.Load<int>("ClassKey").ToString()))
        {
            UpdateChapterProgressView();
        }
        else
        {
            CreateVariables();
        }
    }

    void CreateVariables()
    {
        Dictionary<int, List<float>> dict = new();
        List<float> list = new();
        for (int i = 0; i < chapterManager.SetProgressValues(); i++)
        {
            list.Add(0);
        }        
        for (int i = 0; i < chapterManager.NumberOfChapter; i++)
        {
            dict.Add(i, list);
        }
        ES3.Save<Dictionary<int, List<float>>>(ProgressSave.Key + ES3.Load<string>("Subject") + ES3.Load<int>("ClassKey").ToString(), dict);
    }

    void UpdateChapterProgressView()
    {
        int indexOfChapter = 0; 
        Dictionary<int, List<float>> dict = ES3.Load<Dictionary<int, List<float>>>(ProgressSave.Key + ES3.Load<string>("Subject") + ES3.Load<int>("ClassKey").ToString());
        foreach (KeyValuePair<int, List<float>> item in dict)
        {
            int leafByPercentage = 0; int maximumTestGroup = 0; float overAllPercentage = 0;
            maximumTestGroup = item.Value.Count;
            
            for (int i = 0; i < item.Value.Count; i++)
            {
                
                if (item.Value[i] > 0)
                {
                    overAllPercentage += item.Value[i];
                    leafByPercentage++;                    
                }
            }
            // General Sliderni update qilish
            var sliderVal = overAllPercentage * 100 / (leafByPercentage * 100);

            // Gulni barglarini update qilish           
            Chapter chapter = chapterManager.ChapterGorup[indexOfChapter];
            chapter.SliderFill.fillAmount = sliderVal / 100;

            if (leafByPercentage > 0)
            {
                leafByPercentage--;
                int numberOfLeaf = leafByPercentage * 10 / maximumTestGroup;
                for (int i = 0; i <= numberOfLeaf; i++)
                {
                    chapter.FlowerObj.UpdateFlower(i);
                }
                
            }
            
            indexOfChapter++;
            // do something with entry.Value or entry.Key
        }
    }


}
