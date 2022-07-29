using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P6_Button : MonoBehaviour
{
    public TEXDraw Answer;
    public void InputAnswer()
    {
        if (Answer.text.Length <17)
        {
            Answer.text = Answer.text.Insert(Answer.text.Length, transform.GetChild(0).GetComponent<TEXDraw>().text);
            Debug.Log(Answer.text);
        }
    }
    public void DeleteAnswer()
    {
        Answer.text = Answer.text.Remove(Answer.text.Length - 1, 1);
    }
}
