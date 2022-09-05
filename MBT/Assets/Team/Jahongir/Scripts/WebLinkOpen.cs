using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WebLinkOpen : MonoBehaviour, IPointerDownHandler
{
    public string WebLink;
    public void OnPointerDown(PointerEventData eventData)
    {
        Application.OpenURL(WebLink);
    }
}
