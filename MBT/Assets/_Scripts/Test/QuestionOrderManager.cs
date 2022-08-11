using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionOrderManager : MonoBehaviour
{
    [HideInInspector]
    public List<Button> CircleButtons = new();


    public void LoadNextQuestion()
    {
        int k = 0;
        int index = 0;
        foreach (Button item in CircleButtons)
        {
            if (item.GetComponent<CircleButton>().isActive)
            {
                item.GetComponent<CircleButton>().DeActive();
                index = k;
            }
            k++;
        }
        TestManager.Instance.ActiveDesiredPattern(index);
    }


   
    
}
