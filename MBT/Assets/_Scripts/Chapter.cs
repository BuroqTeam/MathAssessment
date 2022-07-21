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



}


public class ChapterRaw
{
    public string ChapterName;
    public string ChapterNumber;

}
