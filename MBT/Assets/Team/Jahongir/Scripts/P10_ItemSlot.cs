using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class P10_ItemSlot : MonoBehaviour
{
    public int Index;
    public Pattern_10 Pattern10;
    private int k;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.transform.SetParent(Pattern10.Tile1[Index - 1].transform);
            k = transform.childCount;
            Pattern10.InvitePrefEvent.Raise();
        }
    }
    public void Check()
    {
        //if (eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition != GetComponent<RectTransform>().anchoredPosition)
        //{
        //    Pattern10.NotLocatedEvent.Raise();
        //    Debug.Log("NotLocated");
        //}
    }
}
