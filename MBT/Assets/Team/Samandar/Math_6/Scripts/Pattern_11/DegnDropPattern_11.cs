using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class DegnDropPattern_11 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public List<GameObject> Positions;
    public List<GameObject> InitialList;
    private RectTransform _rectTransform;
    public Vector3 _initialPosition;
    private GameObject LastPos;
    public Pattern_11 Pattern11;
    public int siblingIndexObj;
    public List<string> Answer;



    private void Awake()
    {
        _initialPosition = GetComponent<RectTransform>().position;
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        Positions = Pattern11.LeftList;
        InitialList = Pattern11.RightList;
        Debug.Log(Positions[0].name);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _rectTransform.DOScale(1.2f, 0.1f);
        if (LastPos != null)
        {
            LastPos.GetComponent<NumBoxP_11>().CurrentNumber = null;
            LastPos.GetComponent<NumBoxP_11>()._IsEmpty = true;
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

    void Check()
    {
        int k = 0;
        for (int i = 0; i < Positions.Count; i++)
        {
            bool _isEmpty = Positions[i].GetComponent<NumBoxP_11>()._IsEmpty;
            if (Vector3.Distance(transform.position, Positions[i].transform.position) <= 1 && (_isEmpty))
            {
                LastPos = Positions[i];
                transform.position = new Vector3(Positions[i].transform.position.x, Positions[i].transform.position.y, 0);
                _rectTransform.anchoredPosition3D = new Vector3(_rectTransform.anchoredPosition3D.x, _rectTransform.anchoredPosition3D.y, 0);
                Positions[i].GetComponent<NumBoxP_11>()._IsEmpty = false;
                Positions[i].GetComponent<NumBoxP_11>().CurrentNumber = gameObject.transform.GetChild(0).GetComponent<TEXDraw>().text;
                _rectTransform.DOScale(1, 0.2f);
                //Pattern11.CheckingAnswer();
                break;
            }
            else
            {
                k++;
            }
        }
        if (k.Equals(Positions.Count))
        {
            _rectTransform.anchoredPosition3D = InitialList[0].transform.position;
            _rectTransform.DOScale(1, 0.2f);
        }
    }
}
