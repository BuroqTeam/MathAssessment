using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    public string PatternID;
    public bool IsAvailable;
    public delegate void PassToNextQuestion();
    
    

    

    [HideInInspector]
    public int QuestionNumber;
    [HideInInspector]
    public TextAsset Json;

   


   
}
