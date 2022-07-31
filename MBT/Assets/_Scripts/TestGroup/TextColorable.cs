using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextColorable : MonoBehaviour
{
    public Color blue;
    public Color grey;
    TMP_Text percentageTxt;

    private void Awake()
    {
        percentageTxt = GetComponent<TMP_Text>();
        if (percentageTxt.text != "0%")
        {
            percentageTxt.color = blue;
        }
        else
        {
            percentageTxt.color = grey;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
