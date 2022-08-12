using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftNumber : MonoBehaviour
{


    public void UpdateNumber()
    {
        if (GameManager.Instance != null)
        {
            int number = GameManager.Instance.CurrentQuestionNumber;
            number++;
           
            GetComponent<TEXDraw>().text = number.ToString();

        }
        

    }

}
