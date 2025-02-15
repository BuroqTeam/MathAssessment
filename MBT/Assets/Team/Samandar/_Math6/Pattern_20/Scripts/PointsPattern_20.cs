using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointsPattern_20 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Pattern_20 Pattern_20;
    private GameObject Pos_1;
    private GameObject Pos_2;
    public string NumberY;
    public string NumberX;
    public string Point;
    public Vector3 LastPosition;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Pos_1 = Pattern_20.CellObj[0];
        Pos_2 = Pattern_20.CellObj[99];
    }
    
    private void Start()
    {
        PositionCheck();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Numbers();
        PositionCheck();
        BackToLastPosition();
        Numbers();
        Pattern_20.Check();
    }
    public void Numbers()
    {
        GetData();
        Pattern_20.NumbersList.Clear();
        for (int i = 0; i < Pattern_20.PointList.Count; i++)
        {
            string str = Pattern_20.PointList[i].transform.GetComponent<PointsPattern_20>().Point;
            Pattern_20.NumbersList.Add(str);
        }     
    }
    
    public void GetData()
    {
        NumberX = null;
        NumberY = null;
        Point = null;
        for (int i = 0; i < Pattern_20.PositionOut[0].transform.childCount; i++)
        {
            if (Mathf.Approximately(Pattern_20.PositionOut[0].transform.GetChild(i).position.x, gameObject.transform.position.x))
            {
                if (i == 0)
                {
                    NumberX = ("-5");
                }
                if (i == 1)
                {
                    NumberX = ("-4");
                }
                if (i == 2)
                {
                    NumberX = ("-3");
                }
                if (i == 3)
                {
                    NumberX = ("-2");
                }
                if (i == 4)
                {
                    NumberX = ("-1");
                }
                if (i == 5)
                {
                    NumberX = ("0");
                }
                if (i == 6)
                {
                    NumberX = ("1");
                }
                if (i == 7)
                {
                    NumberX = ("2");
                }
                if (i == 8)
                {
                    NumberX = ("3");
                }
                if (i == 9)
                {
                    NumberX = ("4");
                }
                if (i == 10)
                {
                    NumberX = ("5");
                }
            }
        }
        for (int i = 0; i < Pattern_20.PositionOY.Count; i++)
        {
            if (Mathf.Approximately(Pattern_20.PositionOY[i], gameObject.transform.position.y))
            {
                if (i == 0)
                {                    
                    NumberY = ("5");
                }
                if (i == 1)
                {
                    NumberY = ("4");
                }
                if (i == 2)
                {
                    NumberY = ("3");
                }
                if (i == 3)
                {
                    NumberY = ("2");
                }
                if (i == 4)
                {
                    NumberY = ("1");
                }
                if (i == 5)
                {
                    NumberY = ("0");
                }
                if (i == 6)
                {
                    NumberY = ("-1");
                }
                if (i == 7)
                {
                    NumberY = ("-2");
                }
                if (i == 8)
                {
                    NumberY = ("-3");
                }
                if (i == 9)
                {
                    NumberY = ("-4");
                }
                if (i == 10)
                {
                    NumberY = ("-5");
                }
            }
        }
        Point = NumberX + ", " + NumberY;        
    }
    
    void BackToLastPosition()
    {
        if (gameObject.transform.position.x < Pos_1.transform.GetComponent<CellPattern_20>().points[3].x)
        {
            transform.DOMove(LastPosition, 0);
        }
        else if (gameObject.transform.position.x > Pos_2.transform.GetComponent<CellPattern_20>().points[0].x)
        {
            transform.DOMove(LastPosition, 0);
        }
        else if (gameObject.transform.position.y < Pos_1.transform.GetComponent<CellPattern_20>().points[3].y)
        {
            transform.DOMove(LastPosition, 0);
        }
        else if (gameObject.transform.position.y > Pos_2.transform.GetComponent<CellPattern_20>().points[0].y)
        {
            transform.DOMove(LastPosition, 0);
        }
    }

    public void PositionCheck()
    {
        foreach (CellPattern_20 cell in Pattern_20.Instance.CellGroup)
        {
            foreach (Vector3 aPoint in cell.points)
            {
                if (Vector3.Distance(transform.position, aPoint) <= 0.4f)
                {
                    transform.position = aPoint;
                    LastPosition = aPoint;
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
}
