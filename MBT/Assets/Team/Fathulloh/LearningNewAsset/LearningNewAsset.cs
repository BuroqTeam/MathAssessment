using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningNewAsset : MonoBehaviour
{
    public List<string> ProgramLanguages = new List<string>() { "Php", "C#", "C++" };



    void Start()
    {
        SaveSomething();
    }


    void SaveSomething()
    {
        int nulValue = 0;
        //ES3.Save("myIntF", 8000);
        int myInt = ES3.Load("myIntF", nulValue);
        Debug.Log("myIntF = " + myInt);

        ES3.Save("myIntF", 2022);

        Debug.Log("Yangi " + ES3.Load("myIntF"));

        if (ES3.KeyExists("ProgrammingLanguages"))
        {
            Debug.Log("Data bor.");
        }
        else
        {
            Debug.Log("Data yo'q.");
        }


    }





}
