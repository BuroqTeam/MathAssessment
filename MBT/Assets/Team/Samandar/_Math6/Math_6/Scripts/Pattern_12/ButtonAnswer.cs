using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnswer : MonoBehaviour
{
    public Sprite SelectedButton;
    public Sprite DefaultButton;
    public string CurrentAnswer;
    public bool _isTrue = false;
    public bool _pattern;
    public Pattern_12 Pattern12;
    public ColorCollectionSO ColorCollectionSO;
    
    public void ClickAnswer()
    {
        if (!_isTrue)
        {
            _isTrue = true;
            GetComponent<Image>().sprite = SelectedButton;
            gameObject.transform.GetChild(1).GetComponent<TEXDraw>().color = ColorCollectionSO.White;
        }
        else
        {
            _isTrue = false;
            GetComponent<Image>().sprite = DefaultButton;
            gameObject.transform.GetChild(1).GetComponent<TEXDraw>().color = ColorCollectionSO.DarkBlue;
        }
        Pattern12.OnTrue();
        Pattern12.Check();
    }

    public void WriteCurrentAnswer(string str)
    {
        gameObject.transform.GetChild(1).GetComponent<TEXDraw>().color = ColorCollectionSO.DarkBlue;
        gameObject.transform.GetChild(1).GetComponent<TEXDraw>().text = str;
        CurrentAnswer = str;
    }
    
}
