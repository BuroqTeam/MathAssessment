using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P6_Button : MonoBehaviour
{
    public TEXDraw Answer;
    public Pattern_6 Pattern6;
    public void InputAnswer()
    {
        if (Answer.text.Length <17)
        {
            Answer.text = Answer.text.Insert(Answer.text.Length, transform.GetChild(0).GetComponent<TEXDraw>().text);
            Pattern6.Check();
            Pattern6.AnswerDone();
        }
        //if (Answer.text != null)
        //{
        //    ES3.Save<bool>("Pattern_6_Check", true);
        //}
        //else
        //{
        //    ES3.Save<bool>("Pattern_6_Check", false);
        //}
    }
    public void DeleteAnswer()
    {
        if (Answer.text.Length>1)
        {
            Answer.text = Answer.text.Remove(Answer.text.Length - 1, 1);
            Pattern6.Check();
        }
        else if(Answer.text.Length == 1)
        {
            Answer.text = Answer.text.Remove(Answer.text.Length - 1, 1);
            Pattern6.Check();
            Pattern6.AnswerDone();
        }
        else
        {
            Pattern6.AnswerDone();
        }
    }
}
