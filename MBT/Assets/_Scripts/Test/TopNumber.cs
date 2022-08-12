using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopNumber : MonoBehaviour
{
    public void UpdateNumber()
    {
        if (GameManager.Instance != null)
        {
            int number = GameManager.Instance.CurrentQuestionNumber;
            number++;
            
            GetComponent<TEXDraw>().text = number.ToString() + "/" + GameManager.Instance.MaximumQuestionNumber.ToString();

        }
       

    }
}
