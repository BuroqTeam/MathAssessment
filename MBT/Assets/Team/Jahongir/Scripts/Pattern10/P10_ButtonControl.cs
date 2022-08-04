using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class P10_ButtonControl : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.DOScale(1.2f, 0);

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
}
