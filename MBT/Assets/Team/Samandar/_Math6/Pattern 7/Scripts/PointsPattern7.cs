using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointsPattern7 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{


    public void OnBeginDrag(PointerEventData eventData)
    {
        //transform.DOScale(new Vector3(2, 2, 2), 1);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.DOScale(new Vector3(3, 3, 3), 2);
        Check();

    }

    private void Awake()
    {
        Check();
    }

    public void Check()
    {
        foreach (CellPattern7 cell in GameManagerPattern7.Instance.CellGroup)
        {
            foreach (Vector3 aPoint in cell.points)
            {
                if (Vector3.Distance(transform.position, aPoint) <= 0.7f)
                {
                    transform.position = aPoint;
                    break;
                }
            }
        }       
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, 0);
    }
    void Start()
    {

    }

    void Update()
    {

    }

    
}
