using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class P16_ButtonController : MonoBehaviour, IPointerClickHandler
{
    public Pattern_16 Pattern16;
    public bool Select;
    public bool Selected;

    Camera Cam;
    Canvas canvas;
    private void Start()
    {
        Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        Pattern16 = transform.parent.parent.parent.parent.GetComponent<Pattern_16>();
        if (Selected)
        {
            transform.GetComponent<Image>().color = new Color32(0, 148, 255, 255);
        }
        
    }

    //public void OnClick()
    //{

    //    if (Select)
    //    {
    //        transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    //        Select = false;
    //    }
    //    else
    //    {
    //        transform.GetComponent<Image>().color = new Color32(0, 148, 255, 255);
    //        Select = true;
    //    }
    //    Pattern16.CheckButton();
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        var viewportPosition = Cam.WorldToViewportPoint(eventData.position);
        Vector3 pos = ScreenToCanvasPosition(canvas, viewportPosition);
        Debug.Log(pos);


        if (Select)
        {
            transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Select = false;
        }
        else
        {
            transform.GetComponent<Image>().color = new Color32(0, 148, 255, 255);
            Select = true;
        }
        Pattern16.CheckButton();
    }

    public Vector3 ViewportToCanvasPosition(Canvas canvas, Vector3 viewportPosition)
    {
        var centerBasedViewPortPosition = viewportPosition - new Vector3(0.5f, 0.5f, 0);
        var canvasRect = canvas.GetComponent<RectTransform>();
        var scale = canvasRect.sizeDelta;
        return Vector3.Scale(centerBasedViewPortPosition, scale);
    }

    public Vector3 ScreenToCanvasPosition(Canvas canvas, Vector3 screenPosition)
    {
        var viewportPosition = new Vector3(screenPosition.x / Screen.width,
                                           screenPosition.y / Screen.height,
                                           0);
        return ViewportToCanvasPosition(canvas, viewportPosition);
    }

}
