using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class P10_ReturnControl : MonoBehaviour, IPointerClickHandler
{
    public Pattern_10 Pattern10;
    public void OnPointerClick(PointerEventData eventData)
    {
        Pattern10.ReturnBUttonControl();
        Pattern10.Result();
        Pattern10.Check();
    }
}
