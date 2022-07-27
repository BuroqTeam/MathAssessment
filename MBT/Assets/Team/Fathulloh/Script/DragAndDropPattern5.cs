using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropPattern5 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public string CurrentAns;
    private RectTransform _rectTransform;
    private Vector3 InitialPos;


    void Start()
    {
        //Debug.Log(gameObject.GetComponent<RectTransform>().position.GetType() + " InitialPos = " + InitialPos);
        InitialPos = transform.position /*gameObject.GetComponent<RectTransform>().position*/;
        
        _rectTransform = GetComponent<RectTransform>();
    }

    
    public void WriteCurrentAns(string str)
    {
        gameObject.transform.GetChild(0).GetComponent<TEXDraw>().text = str;
        CurrentAns = str;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, 0);
        _rectTransform.anchoredPosition3D = new Vector3(_rectTransform.anchoredPosition3D.x, _rectTransform.anchoredPosition3D.y, 0);

    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Check();
    }


    void Check()
    {

    }



}
