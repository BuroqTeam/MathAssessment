using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PenCanvasP8 : MonoBehaviour, IPointerClickHandler
{
    public Action onPenCanvasLeftClickEvent;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            onPenCanvasLeftClickEvent?.Invoke();
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
