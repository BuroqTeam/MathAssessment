using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class PushableRectangle : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public List<GameObject> Positions;
    public List<GameObject> InitialList;
    private RectTransform _rectTransform;
    public Vector3 InitialPosition;
    private GameObject _lastPos;
    public Pattern_11 Pattern11;
    public int siblingIndexObj;
    public List<string> Answer;

    private void Awake()
    {        
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        Positions = Pattern11.LeftList;
        InitialList = Pattern11.RightList;
        Debug.Log(Positions[0].name);
    }
    public void Order()
    {
        siblingIndexObj = transform.GetSiblingIndex();
        GameObject parentObj = gameObject.transform.parent.gameObject;
        siblingIndexObj = parentObj.transform.GetSiblingIndex();
        parentObj.transform.SetSiblingIndex(Pattern11.RightList.Count - 1);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.GetComponent<VerticalLayoutGroup>().enabled = false;
        Order();
        _rectTransform.DOScale(1.2f, 0.1f);
        if (_lastPos != null)
        {
            _lastPos.GetComponent<PushableShadow>().CurrentNumber = null;
            _lastPos.GetComponent<PushableShadow>()._IsEmpty = true;
            _lastPos = null;
        }
       

    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        Checking();
        Pattern11.OnTrue();
        Pattern11.Check();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, 0);
        _rectTransform.anchoredPosition3D = new Vector3(_rectTransform.anchoredPosition3D.x, _rectTransform.anchoredPosition3D.y, 0);
    }

    void Checking()
    {
        int k = 0;
        for (int i = 0; i < Positions.Count; i++)
        {
            bool _isEmpty = Positions[i].GetComponent<PushableShadow>()._IsEmpty;
            if (Vector3.Distance(transform.position, Positions[i].transform.position) <= 1 && (_isEmpty))
            {
                _lastPos = Positions[i];
                transform.position = new Vector3(Positions[i].transform.position.x, Positions[i].transform.position.y, 0);
                _rectTransform.anchoredPosition3D = new Vector3(_rectTransform.anchoredPosition3D.x, _rectTransform.anchoredPosition3D.y, 0);
                Positions[i].GetComponent<PushableShadow>()._IsEmpty = false;
                Positions[i].GetComponent<PushableShadow>().CurrentNumber = gameObject.transform.GetChild(0).GetComponent<TEXDraw>().text;
                _rectTransform.DOScale(1, 0.2f);
                Pattern11.Checking();
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
