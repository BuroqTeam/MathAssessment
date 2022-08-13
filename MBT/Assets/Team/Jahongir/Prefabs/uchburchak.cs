using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class uchburchak : MonoBehaviour, IPointerClickHandler
{
    public bool Select = false;
    public bool Selected;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Run");
        if (Select)
        {
            transform.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            Select = false;
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().color = new Color32(0, 148, 255, 255);
            Select = true;
        }
    }
}
