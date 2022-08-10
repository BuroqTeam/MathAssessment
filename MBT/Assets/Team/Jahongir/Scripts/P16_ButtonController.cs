using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P16_ButtonController : MonoBehaviour
{
    public bool Select;
    public bool Selected;
    private void Start()
    {
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
    }

}
