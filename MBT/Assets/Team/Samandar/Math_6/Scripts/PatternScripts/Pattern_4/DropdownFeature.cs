using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static TMPro.TMP_Dropdown;
using UnityEngine.UIElements;

public class DropdownFeature : MonoBehaviour
{
    public int Numbers;
    public GameObject Label;
    public GameObject Arrow;

    private void Awake()
    {
        
    }
    void Start()
    {
       
    }
    public void TurnOn()
    {
        Label.GetComponent<TMP_Text>().enabled = true;
        Label.GetComponent<TMP_Text>().color = new Color(1, 1, 1, 1);
        //Arrow.GetComponent<TMP_Text>().color = new Color(1, 1, 1, 1);
        //Debug.Log(Label.GetComponent<TMP_Text>().color);
        Debug.Log("DropDown");
    }
    public void ColorUpdate()
    {
        
    }


    public void CheckIsWorking()
    {
        Debug.Log("Item");
        //Label.GetComponent<TMP_Text>().enabled = true;
    }

    public void CheckOnScrollBar()
    {
        Debug.Log("Scrollbar");
    }

    public void CheckTemplate()
    {
        Debug.Log("Tamplate");
    }


}
