using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropPattern5 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Pattern_5 Pattern5;
    public bool _NumIsCorrectPosition;
    public List<GameObject> EmptyPositions;
    public string CurrentAns;

    private RectTransform _rectTransform;
    private Vector3 InitialPos;
    private int siblingIndexObj;
    public GameObject LastPos;


    void Start()
    {
        InitialPos = transform.position;
        
        _rectTransform = GetComponent<RectTransform>();
    }

    
    public void WriteCurrentAns(string str)
    {
        gameObject.transform.GetChild(0).GetComponent<TEXDraw>().text = str;
        CurrentAns = str;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (LastPos != null)        {
            //LastPos.GetComponent<NumBoxP_5>()._IsEmpty = true;            
            _NumIsCorrectPosition = LastPos.GetComponent<NumBoxP_5>().CheckAns(false, CurrentAns);            
            LastPos = null;
            //Debug.Log("Ishladi." + _NumIsCorrectPosition);
        }
        siblingIndexObj = transform.GetSiblingIndex();
        //Debug.Log("indexObject = " + siblingIndexObj);
        transform.SetSiblingIndex(Pattern5.Numbers.Count - 1);
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, 0);
        _rectTransform.anchoredPosition3D = new Vector3(_rectTransform.anchoredPosition3D.x, _rectTransform.anchoredPosition3D.y, 0);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetSiblingIndex(siblingIndexObj);
        Check();
    }


    void Check()
    {
        int k = 0;
        for (int i = 0; i < EmptyPositions.Count; i++)
        {
            bool _isEmpty = EmptyPositions[i].GetComponent<NumBoxP_5>()._IsEmpty;
            if ((Vector3.Distance(transform.position, EmptyPositions[i].transform.position) <= 1) && (_isEmpty))
            {
                LastPos = EmptyPositions[i];
                //EmptyPositions[i].GetComponent<NumBoxP_5>()._IsEmpty = false;
                _NumIsCorrectPosition = LastPos.GetComponent<NumBoxP_5>().CheckAns(true, CurrentAns);
                transform.position = new Vector3(EmptyPositions[i].transform.position.x, EmptyPositions[i].transform.position.y, 0);
                _rectTransform.anchoredPosition3D = new Vector3(_rectTransform.anchoredPosition3D.x, _rectTransform.anchoredPosition3D.y, 0);

                break;
            }
            else
                k++;
            
        }

        if (k.Equals(EmptyPositions.Count))
        {
            transform.position = InitialPos;            
        }

        Pattern5.GetComponent<Pattern_5>().CheckIsFinishing();
    }



}
