using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DegnDropPattern_3 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public List<RectTransform> NumberAreas;
    private RectTransform _rectTransform;
    private Vector3 _initialPosition;

    private void Awake()
    {
        _initialPosition = transform.position;
        _rectTransform = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

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
        for (int i = 0; i < NumberAreas.Count; i++)
        {
            if (Vector3.Distance(transform.position, NumberAreas[i].transform.position) <= 1)
            {
                transform.position = new Vector3(NumberAreas[i].transform.position.x, NumberAreas[i].transform.position.y, 0);
                _rectTransform.anchoredPosition3D = new Vector3(_rectTransform.anchoredPosition3D.x, _rectTransform.anchoredPosition3D.y, 0);
                _rectTransform.DOScale(1.2f, 0.2f).OnComplete(Minimize);
                break;
            }
            else
            {
                k++;
            }
        }
        if (k.Equals(NumberAreas.Count))
        {
            //transform.position = _initialPosition;
            _rectTransform.anchoredPosition3D = new Vector3(0, 0, 0);
        }
    }

    void Minimize()
    {
        _rectTransform.DOScale(1, 0.2f);
    }

}
