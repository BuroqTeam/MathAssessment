using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionNumber : MonoBehaviour
{
    public bool IsDone;

    TMP_Text numberText;

    private void Awake()
    {
        numberText = transform.GetChild(0).GetComponent<TMP_Text>();



    }


    public void InitialCondition(int number)
    {
        number++;
        numberText.text = number.ToString();


    }
   
}
