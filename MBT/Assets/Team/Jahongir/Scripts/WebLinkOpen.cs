using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WebLinkOpen : MonoBehaviour, IPointerDownHandler
{
    public string WebLink;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (WebLink.Length>2)
        {
            Application.OpenURL(WebLink);
        }
        else 
        {
           
        }
    }
}
