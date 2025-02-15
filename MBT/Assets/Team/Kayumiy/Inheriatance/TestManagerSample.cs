using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestManagerSample : MonoBehaviour
{
    
    protected TMP_Text QuestionText;

    Canvas canvas;

    void Awake()
    {
        Display();
        //Find the object you're looking for
        GameObject tempObject = GameObject.FindGameObjectWithTag("Canvas");
        if (tempObject != null)
        {
            //If we found the object , get the Canvas component from it.
            canvas = tempObject.GetComponent<Canvas>();
            if (canvas == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
            else
            {
                QuestionText = canvas.transform.GetChild(0).GetComponent<TMP_Text>();
            }
        }
    }

    public void Display()
    {
        Debug.Log("Salam");
    }


    public virtual void DisplayQuestion(string questionStr)
    {
        //QuestionText.text = questionStr;

       
    }
}