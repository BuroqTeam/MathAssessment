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
            Debug.Log(Answer.text);
        }
        if (Answer.text != null)
        {
            Pattern6.ActNext.Raise();
        }
        else
        {
            Pattern6.DeactNext.Raise();
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
            Debug.Log("O‘chdi");
        }
        else
        {
            Pattern6.ActNext.Raise();
            Debug.Log("O‘chmaadi");
        }
    }
}
