using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2_ButtonControl : MonoBehaviour
{
    public bool CorrectAnswer;
    public bool Select;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.GetChild(0).GetComponent<TEXDraw>().text.Contains('*'))
        {
            CorrectAnswer = true;
            transform.GetChild(0).GetComponent<TEXDraw>().text = transform.GetChild(0).GetComponent<TEXDraw>().text.Replace("[*]", "");
        }
    }
    public void OnClick()
    {

        if (Select)
        {
            transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            transform.GetChild(0).GetComponent<TEXDraw>().color = new Color32(0, 72, 124, 255);
            Select = false;
        }
        else
        {
            transform.GetComponent<Image>().color = new Color32(0, 148, 255, 255);
            transform.GetChild(0).GetComponent<TEXDraw>().color = new Color32(255, 255, 255, 255);
            Select = true;
        }
    }
}
