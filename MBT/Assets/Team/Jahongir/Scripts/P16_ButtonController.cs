using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P16_ButtonController : MonoBehaviour
{
    public Pattern_16 Pattern16;
    public bool Select;
    public bool Selected;
    private void Start()
    {
        Pattern16 = transform.parent.parent.parent.parent.GetComponent<Pattern_16>();
        if (Selected)
        {
            transform.GetComponent<Image>().color = new Color32(0, 148, 255, 255);
        }
        
    }

    public void OnClick()
    {

        if (Select)
        {
            transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Select = false;
        }
        else
        {
            transform.GetComponent<Image>().color = new Color32(0, 148, 255, 255);
            Select = true;
        }
        Pattern16.CheckButton();
    }

}
