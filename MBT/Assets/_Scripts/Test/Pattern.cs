using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    public bool IsEdited;
    public string PatternID;
    public bool IsAvailable;    
    public GameEvent Event;
    

    

    [HideInInspector]
    public int QuestionNumber;
    [HideInInspector]
    public TextAsset Json;

   


   
}
