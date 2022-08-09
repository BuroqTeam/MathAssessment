using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnswer : MonoBehaviour
{
    public Sprite SelectedButton;
    public Sprite DefaultButton;
    public bool _isTrue = false;
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


    void Update()
    {
        
    }
}
