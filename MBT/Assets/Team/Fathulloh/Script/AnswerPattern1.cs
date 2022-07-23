using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPattern1 : MonoBehaviour
{
    public Pattern1 PatternOne;
    public bool _IsTrue;
    public string CurrentAnswer;
    public List<GameObject> ABCD;

    void Start()
    {
        
    }

    public void WriteCurrentAnswer(string str)
    {
        gameObject.transform.GetChild(2).GetComponent<TEXDraw>().text = str;
        CurrentAnswer = str;
    }
    

    public void ClickAnswer()
    {
        //for (int i = 0; i < ABCD.Count; i++)
        //{
        //    //if (ABCD[i] == gameObject)
        //    //{

        //    //}
        //    //else 
        //    //{
        //    //    DisableObject();
        //    //    Debug.Log(" " + ABCD[i].transform.GetChild(0).gameObject.name);
        //    //}
        //    ABCD[i].transform.GetChild(0).GetComponent<AnswerPattern1>().DisableObject();
        //}

        PatternOne.UnClickedButtons();
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }


    public void DisableObject()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

}
