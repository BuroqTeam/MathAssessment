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
    

    /// <summary>
    /// Button bosilganda ishlovchi method.
    /// </summary>
    public void ClickAnswer()
    {
        PatternOne.UnClickedButtons();
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        if (_IsTrue)
        {
            Debug.Log("Correct Answer.");
        }
        else
        {
            Debug.Log("Wrong Answer.");
        }
    }


    /// <summary>
    /// Bosilgan variyantlarni o'chirish uchun ishlatiladi.
    /// </summary>
    public void DisableObject()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

}
