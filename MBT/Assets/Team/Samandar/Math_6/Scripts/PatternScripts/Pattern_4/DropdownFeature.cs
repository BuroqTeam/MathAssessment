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
    public Pattern_4 P4;
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
        P4.Populate();
    }
    public void ColorUpdate()
    {
        
    }

}
