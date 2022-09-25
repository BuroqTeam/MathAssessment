using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DegnDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Pattern_8 Pattern_8;
    private GameObject Pos_1;
    private GameObject Pos_2;
    public Vector3 LastPosition;
    void Start()
    {
        PointPosition();
    }
    public void PointPosition()
    {
        if (Pattern_8.Figure == 2)
        {
            Pattern_8.PointList[0].transform.position = Pattern_8.CellObj[35].transform.GetComponent<Cell>().points[1];
            Pattern_8.PointList[1].transform.position = Pattern_8.CellObj[55].transform.GetComponent<Cell>().points[1];
            Pattern_8.PointList[2].transform.position = Pattern_8.CellObj[58].transform.GetComponent<Cell>().points[1];
        }
        else if (Pattern_8.Figure == 3)
        {
            Pattern_8.PointList[0].transform.position = Pattern_8.CellObj[34].transform.GetComponent<Cell>().points[1];
            Pattern_8.PointList[1].transform.position = Pattern_8.CellObj[53].transform.GetComponent<Cell>().points[1];
            Pattern_8.PointList[2].transform.position = Pattern_8.CellObj[77].transform.GetComponent<Cell>().points[1];
        }
        else if (Pattern_8.Figure == 4)
        {
            Pattern_8.PointList[0].transform.position = Pattern_8.CellObj[33].transform.GetComponent<Cell>().points[1];
            Pattern_8.PointList[1].transform.position = Pattern_8.CellObj[63].transform.GetComponent<Cell>().points[1];
            Pattern_8.PointList[2].transform.position = Pattern_8.CellObj[68].transform.GetComponent<Cell>().points[1];
            Pattern_8.PointList[3].transform.position = Pattern_8.CellObj[38].transform.GetComponent<Cell>().points[1];
        }
        Checking();
    }
    void BackToLastPosition()
    {
        
        if (gameObject.transform.position.x < Pos_1.transform.GetComponent<Cell>().points[3].x)
        {
            transform.DOMove(LastPosition, 0);
            Logging.Log("1");
        }
        else if (gameObject.transform.position.x > Pos_2.transform.GetComponent<Cell>().points[0].x)
        {
            transform.DOMove(LastPosition, 0);
            Logging.Log("2");
        }
        else if (gameObject.transform.position.y < Pos_1.transform.GetComponent<Cell>().points[3].y)
        {
            transform.DOMove(LastPosition, 0);
            Logging.Log("3");
        }
        else if (gameObject.transform.position.y > Pos_2.transform.GetComponent<Cell>().points[0].y)
        {
            transform.DOMove(LastPosition, 0);
            Logging.Log("4");
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Pos_1 = Pattern_8.CellObj[0];
        Pos_2 = Pattern_8.CellObj[99];
        LastPosition = gameObject.transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.DOScale(new Vector3(3, 3, 3), 2);
        Checking();
        Pattern_8.ActeveteButton();
        
    }
    
    void Checking()
    {
        bool isGoToLast = false;
        foreach (Cell cell in Pattern_8.Instance.CellGroup)
        {
            foreach (Vector3 aPoint in cell.points)
            {
                if (Vector3.Distance(transform.position, aPoint) <= 0.45f)
                {
                    transform.position = aPoint;                    
                    isGoToLast = true;
                    break;
                }              
            }            
        }

        if (!isGoToLast)
        {
            BackToLastPosition();
        }
        else
        {
            Pattern_8.Check();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, 0);
    }   
  
}
