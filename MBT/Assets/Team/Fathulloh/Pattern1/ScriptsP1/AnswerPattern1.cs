using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerPattern1 : MonoBehaviour
{
    public Pattern_1 PatternOne;
    public bool _IsTrue;
    public string CurrentAnswer;
    public List<GameObject> ABCD;
    public Color InitialTextColor;

    public Sprite CorrectCircle, CorrectRectangle;
    public Sprite WrongCircle, WrongRectangle;


    /// <summary>
    /// A B C D larga yozishni taminlovchi method.
    /// </summary>
    /// <param name="str"></param>
    public void WriteCurrentAnswer(string str)
    {
        InitialTextColor = gameObject.transform.GetChild(2).GetComponent<TEXDraw>().color;

        gameObject.transform.GetChild(2).GetComponent<TEXDraw>().text = str;
        CurrentAnswer = str;
    }
    

    /// <summary>
    /// Button bosilganda ishlovchi method.
    /// </summary>
    public void ClickAnswer()
    {
        PatternOne.UnClickedButtons();
        PatternOne.CurrentClickedObj = gameObject;

        gameObject.transform.GetChild(2).GetComponent<TEXDraw>().color = Color.white;

        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        int childsCount = gameObject.transform.childCount;
        gameObject.transform.GetChild(childsCount - 1).gameObject.SetActive(true);

        if (_IsTrue)        {
            //Debug.Log("Correct Answer.");
            PatternOne.CurrentAnswerStatus = true;
        }
        else        {
            //Debug.Log("Wrong Answer.");
            PatternOne.CurrentAnswerStatus = false;
        }
        PatternOne.ActeveteButton();
    }


    /// <summary>
    /// Bosilgan variyantlarni o'chirish uchun ishlatiladi.
    /// </summary>
    public void DisableObject()
    {
        int childsCount = gameObject.transform.childCount;
        gameObject.transform.GetChild(childsCount - 1).gameObject.SetActive(false);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).GetComponent<TEXDraw>().color = InitialTextColor;
    }

    
    /// <summary>
    /// Test tugashida xatolarni ko'rsatish uchun ishlatiladi.
    /// </summary>
    public void WrongClickAction()
    {
        int childsCount = gameObject.transform.childCount; // circleni yoqish va o'chirish
        gameObject.transform.GetChild(childsCount - 1).gameObject.GetComponent<Image>().sprite = WrongCircle;
        gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = WrongRectangle;
    }


}
