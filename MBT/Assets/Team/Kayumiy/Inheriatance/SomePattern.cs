using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomePattern : TestManager
{

    public string sampleQuestion;

    private void OnEnable()
    {
        
        DisplayQuestion(sampleQuestion);
    }




    public override void DisplayQuestion(string questionStr)
    {
        base.DisplayQuestion(questionStr);
        // Do other things related to your pattern
        // a b c d ni instantiate 
        // 1 dan 12 gacha button create qilisj

    }


}
