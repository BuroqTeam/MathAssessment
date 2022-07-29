using System;
using System.Collections;
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


    public ChapterRaw chapterRaw = new ChapterRaw();


    public void UpdateInfo()
    {       
        ChapterNumberTxt.text = chapterRaw.number;
        ChapterNameTxt.text = chapterRaw.name;
    }

}


[SerializeField]
public class ChapterRaw
{
    public string number;
    public string name;
   
    
}


