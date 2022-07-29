using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DegnDropPattern_3 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public List<RectTransform> NumberAreas;
    public List<GameObject> Positions;
    private RectTransform _rectTransform;
    private Vector3 _initialPosition;
    private GameObject LastPos;
    private void Awake()
    {
        _initialPosition = transform.position;
        _rectTransform = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (LastPos != null)
        {
            LastPos.GetComponent<NumBoxP_3>()._IsEmpty = true;
            LastPos = null;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Check();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, 0);
        _rectTransform.anchoredPosition3D = new Vector3(_rectTransform.anchoredPosition3D.x, _rectTransform.anchoredPosition3D.y, 0);       

    }


    // Start is called before the first frame update
    void Check()
    {
        int k = 0;
        for (int i = 0; i < Positions.Count; i++)
        {
            bool _isEmpty = Positions[i].GetComponent<NumBoxP_3>()._IsEmpty;
            if (Vector3.Distance(transform.position, Positions[i].transform.position) <= 1 && (_isEmpty))
            {
                LastPos = Positions[i];
                transform.position = new Vector3(Positions[i].transform.position.x, Positions[i].transform.position.y, 0);
                _rectTransform.anchoredPosition3D = new Vector3(_rectTransform.anchoredPosition3D.x, _rectTransform.anchoredPosition3D.y, 0);
                Positions[i].GetComponent<NumBoxP_3>()._IsEmpty = false;
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
            //transform.position = _initialPosition;
            _rectTransform.anchoredPosition3D = new Vector3(0, 0, 0);
            _rectTransform.DOScale(1, 0.2f);
        }
    }

    //void Minimize()
    //{
    //    _rectTransform.DOScale(1, 0.2f);
    //}

}
