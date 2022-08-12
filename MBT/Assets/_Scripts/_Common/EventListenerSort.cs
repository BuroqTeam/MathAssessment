using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventListenerSort : MonoBehaviour
{
    [HideInInspector]
    public List<GameEvent> GameEvents = new();

    public Button NextButton;

    private void Awake()
    {
        NextButton.onClick.AddListener(TaskOnClick);
    }

    
    private void Start()
    {
        foreach (GameObject obj in TestManager.Instance.ActivePatterns)
        {
            GameEvents.Add(obj.GetComponent<Pattern>().Event);            
        }
    }

    private void TaskOnClick()
    {
        int k = 0;
        foreach (GameObject obj in TestManager.Instance.ActivePatterns)
        {
            if (obj.activeSelf)
            {
                GameEvents[k].Raise();
                break;
            }
            k++;
        }
        
    }







}
