using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralTest : MonoBehaviour
{

    [HideInInspector]
    public TEXDraw QuestionText;


    public virtual void DisplayQuestion(string questionStr)
    {

        TestManager.Instance.QuestionText.text = questionStr;
        
    }


    //public void UpdateTestView(string questionNumber, )
    //{
        
    //}


    public void TurnOn()
    {
        //TestManager testManager = GetComponent<TestManager>();
        
        
    }

}
