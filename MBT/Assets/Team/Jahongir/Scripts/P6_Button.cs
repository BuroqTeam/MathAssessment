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
        }
        if (Answer.text != null)
        {
            Pattern6.ActNext.Raise();
            ES3.Save<bool>("Pattern_6_Check", true);
        }
        else
        {
            Pattern6.DeactNext.Raise();
            ES3.Save<bool>("Pattern_6_Check", false);
            GameManager.Instance.CurrentCircleObj.IsDone = false;
            GetComponent<Pattern>().IsStatus = false;
        }
    }
    public void DeleteAnswer()
    {
        if (Answer.text.Length>0)
        {
            Answer.text = Answer.text.Remove(Answer.text.Length - 1, 1);
        }
        if (Answer.text.Length == 0)
        {
            Pattern6.DeactNext.Raise();
            ES3.Save<bool>("Pattern_6_Check", false);
            GameManager.Instance.CurrentCircleObj.IsDone = false;
        }
        else
        {
            Pattern6.ActNext.Raise();
            ES3.Save<bool>("Pattern_6_Check", true);
        }
    }
}
