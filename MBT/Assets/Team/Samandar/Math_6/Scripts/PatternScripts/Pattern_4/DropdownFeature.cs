using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static TMPro.TMP_Dropdown;
using UnityEngine.UIElements;

public class DropdownFeature : MonoBehaviour
{
    public int Numbers;
    public TMP_Dropdown NewDD;
    public Sprite P4;
    void Start()
    {
        OptionData NNNN;
        //transform.GetComponent<TMP_Dropdown>().options.Count = Numbers;
        //Debug.Log(transform.GetComponent<TMP_Dropdown>().options.GetType());
        //Debug.Log(transform.GetComponent<TMP_Dropdown>().options.Count);
        //transform.GetComponent<TMP_Dropdown>().options.AddRange(NewDD, NNNN);
    }
    public void ImageUpdate()
    {
        //gameObject.GetComponent<Image>().sprite = P4;
        //gameObject.GetComponent<Image>().tintColor = Color.blue;
    }
    void Update()
    {
        
    }
}
