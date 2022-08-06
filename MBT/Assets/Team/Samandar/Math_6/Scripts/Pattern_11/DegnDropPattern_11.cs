using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class DegnDropPattern_11 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public List<GameObject> Positions;
    private RectTransform _rectTransform;
    private Vector3 _initialPosition;
    private GameObject LastPos;
    public Pattern_11 Pattern11;
    public int siblingIndexObj;
    public List<string> Answer;



    private void Awake()
    {
        _initialPosition = transform.position;
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        Positions = Pattern11.LeftList;
        Debug.Log(Positions[0].name);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        if (LastPos != null)
        {
            LastPos.GetComponent<NumBoxP_11>().CurrentNumber = null;
            LastPos.GetComponent<NumBoxP_11>()._IsEmpty = true;
            LastPos = null;
        }

    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, 0);
        _rectTransform.anchoredPosition3D = new Vector3(_rectTransform.anchoredPosition3D.x, _rectTransform.anchoredPosition3D.y, 0);
    }
       
    
}
