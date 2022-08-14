using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{

    ChapterManager chapterManager;

   
    private void Start()
    {
        chapterManager = GetComponent<ChapterManager>();
        //CheckSaveCondition();
    }

    void CheckSaveCondition()
    {
        Dictionary<int, List<float>> dict = new();
        if (ES3.KeyExists("Save" + ES3.Load<string>("Subject") + ES3.Load<int>("ClassKey").ToString()))
        {
            UpdateProgressView();
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

        // List ni sonini bilish uchun avval JSON ni bittalab o'qib chiqish kerak ertaga shu yerdan davom ettiraman
        for (int i = 0; i < chapterManager.NumberOfChapter; i++)
        {
            dict.Add(i, list);
        }
        ES3.Save<Dictionary<int, List<float>>>("Save" + ES3.Load<string>("Subject") + ES3.Load<int>("ClassKey").ToString(), dict);

    }

    void UpdateProgressView()
    {
        int indexOfChapter = 0; 
        Dictionary<int, List<float>> dict = ES3.Load<Dictionary<int, List<float>>>("Save" + ES3.Load<string>("Subject") + ES3.Load<int>("ClassKey").ToString());
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
            int numberOfLeaf = leafByPercentage * 10 / maximumTestGroup; 
            chapter.FlowerObj.UpdateFlower(numberOfLeaf);
            indexOfChapter++;
            // do something with entry.Value or entry.Key
        }
    }


   



}
