using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{


   
    private void Start()
    {
        CreateSaveVariables();
    }

    void CreateSaveVariables()
    {
        Dictionary<int, List<float>> dict = new();
        if (ES3.KeyExists("SaveTestGroup"))
        {
            dict = ES3.Load<Dictionary<int, List<float>>>("SaveTestGroup");


        }
        else
        {
            List<float> list = new();
            for (int i = 0; i < GetComponent<ChapterManager>().NumberOfChapter; i++)
            {
                dict.Add(i, list);
            }
            ES3.Save<Dictionary<int, List<float>>>("SaveTestGroup", dict);
        }
    }



}
