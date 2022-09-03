using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class Number : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public List<GameObject> Positions;
    private RectTransform _rectTransform;
    private GameObject LastPos;
    public Pattern_3 Pattern3;
    public int siblingIndexObj;
    public List<string> Answer;

    

    private void Awake()
    {                
        _rectTransform = GetComponent<RectTransform>();        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {        
        Order();
        if (LastPos != null)
        {
            
            LastPos.GetComponent<NumberArea>().CurrentNumber = null;
            LastPos.GetComponent<NumberArea>()._IsEmpty = true;
            LastPos = null;            
        }
        //Pattern3.ClearData();
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {        
        Check();
        Pattern3.CheckingAnswer();
        Pattern3.OnTrue();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, 0);
        _rectTransform.anchoredPosition3D = new Vector3(_rectTransform.anchoredPosition3D.x, _rectTransform.anchoredPosition3D.y, 0);
    }

    public void Order()
    {
        siblingIndexObj = transform.GetSiblingIndex();
        GameObject parentObj = gameObject.transform.parent.gameObject;
        siblingIndexObj = parentObj.transform.GetSiblingIndex();
        parentObj.transform.SetSiblingIndex(Pattern3.NumbersParent.Count - 1);
    }
       
    void Check()
    {
        int k = 0;
        for (int i = 0; i < Positions.Count; i++)
        {
            bool _isEmpty = Positions[i].GetComponent<NumberArea>()._IsEmpty;
            if (Vector3.Distance(transform.position, Positions[i].transform.position) <= 1 && (_isEmpty))
            {
                LastPos = Positions[i];
                transform.position = new Vector3(Positions[i].transform.position.x, Positions[i].transform.position.y, 0);
                _rectTransform.anchoredPosition3D = new Vector3(_rectTransform.anchoredPosition3D.x, _rectTransform.anchoredPosition3D.y, 0);
                Positions[i].GetComponent<NumberArea>()._IsEmpty = false;
                Positions[i].GetComponent<NumberArea>().CurrentNumber = gameObject.transform.GetChild(0).GetComponent<TEXDraw>().text;
                _rectTransform.DOScale(1.25f, 0.2f);                
               
                break;
            }
            else
            {
                k++;
            }
        }
        if (k.Equals(Positions.Count))
        {
            _rectTransform.anchoredPosition3D = new Vector3(0, 0, 0);
            _rectTransform.DOScale(1, 0.2f);
        }
    }        
}
