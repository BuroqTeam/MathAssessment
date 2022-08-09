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
    void Start()
    {
        
    }
    public void ClickAnswer()
    {
        if (!_isTrue)
        {
            _isTrue = true;
            GetComponent<Image>().sprite = SelectedButton;
        }
        else
        {
            _isTrue = false;
            GetComponent<Image>().sprite = DefaultButton;
        }
    }

    public void WriteCurrentAnswer(string str)
    {
        //InitialTextColor = gameObject.transform.GetChild(1).GetComponent<TEXDraw>().color;

        gameObject.transform.GetChild(1).GetComponent<TEXDraw>().text = str;
        CurrentAnswer = str;
    }
    void Update()
    {
        
    }
}
