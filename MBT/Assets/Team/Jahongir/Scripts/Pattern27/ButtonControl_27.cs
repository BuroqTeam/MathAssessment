using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonControl_27 : MonoBehaviour, IPointerClickHandler
{
    public Pattern_27 Pattern27;
    public bool Answer;
    public bool Select;

    public void OnPointerClick(PointerEventData eventData)
    {
        Pattern27.BeforeSelect();
        gameObject.GetComponent<Image>().color = new Color32(213, 238, 255, 255);
        Select = true;
        Pattern27.Check();
    }
}
