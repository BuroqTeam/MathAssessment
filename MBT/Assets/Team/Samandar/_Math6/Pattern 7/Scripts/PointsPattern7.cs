using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointsPattern7 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Pattern_7 Pattern_7;
  
    private GameObject Pos_1;
    private GameObject Pos_2;
    public List<string> NumberY;
    public List<string> NumberX;
    public Vector3 LastPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
      
        Pos_1 = Pattern_7.CellObj[0];
        Pos_2 = Pattern_7.CellObj[99];
    }

    private void Start()
    {
        PositionCheck();
    }



    public void OnEndDrag(PointerEventData eventData)
    {       
        PositionCheck();
        BackToLastPosition();
        Check();
    }

    public void Check()
    {
        NumberX.Clear();
        NumberY.Clear();
        for (int i = 0; i < Pattern_7.PositionOut[0].transform.childCount; i++)
        {
            if (Pattern_7.PositionOut[0].transform.GetChild(i).position.x == gameObject.transform.position.x)
            {
                if (i == 0)
                {
                    Debug.Log("x-5");
                    NumberX.Add("-5");
                }
                if (i == 1)
                {
                    Debug.Log("x-4");
                    NumberX.Add("-4");
                }
                if (i == 2)
                {
                    Debug.Log("x-3");
                    NumberX.Add("-3");
                }
                if (i == 3)
                {
                    Debug.Log("x-2");
                    NumberX.Add("-2");
                }
                if (i == 4)
                {
                    Debug.Log("x-1");
                    NumberX.Add("-1");
                }
                if (i == 5)
                {
                    Debug.Log("x");
                    NumberX.Add("0");
                }
                if (i == 6)
                {
                    Debug.Log("x+1");
                    NumberX.Add("1");
                }
                if (i == 7)
                {
                    Debug.Log("x+2");
                    NumberX.Add("2");
                }
                if (i == 8)
                {
                    Debug.Log("x+3");
                    NumberX.Add("3");
                }
                if (i == 9)
                {
                    Debug.Log("x+4");
                    NumberX.Add("4");
                }
                if (i == 10)
                {
                    Debug.Log("x+5");
                    NumberX.Add("5");
                }              
            }
        }
        for (int i = 0; i < Pattern_7.PositionOut[1].transform.childCount; i++)
        {
            if (Pattern_7.PositionOut[1].transform.GetChild(i).position.y == gameObject.transform.position.y)
            {
                if (i == 0)
                {
                    Debug.Log("x-5");
                    NumberY.Add("-5");
                }
                if (i == 1)
                {
                    Debug.Log("x-4");
                    NumberY.Add("-4");
                }
                if (i == 2)
                {
                    Debug.Log("x-3");
                    NumberY.Add("-3");
                }
                if (i == 3)
                {
                    Debug.Log("x-2");
                    NumberY.Add("-2");
                }
                if (i == 4)
                {
                    Debug.Log("x-1");
                    NumberY.Add("-1");
                }
                if (i == 5)
                {
                    Debug.Log("x");
                    NumberY.Add("0");
                }
                if (i == 6)
                {
                    Debug.Log("x+1");
                    NumberY.Add("1");
                }
                if (i == 7)
                {
                    Debug.Log("x+2");
                    NumberY.Add("2");
                }
                if (i == 8)
                {
                    Debug.Log("x+3");
                    NumberY.Add("3");
                }
                if (i == 9)
                {
                    Debug.Log("x+4");
                    NumberY.Add("4");
                }
                if (i == 10)
                {
                    Debug.Log("x+5");
                    NumberY.Add("5");
                }                
            }
            else
            {
                NumberY.Add("-111");
            }
        }
    }

    void BackToLastPosition()
    {
        
        if (gameObject.transform.position.x < Pos_1.transform.GetComponent<CellPattern7>().points[3].x)
        {
            transform.DOMove(LastPosition, 0);
        }
        else if (gameObject.transform.position.x > Pos_2.transform.GetComponent<CellPattern7>().points[0].x)
        {
            transform.DOMove(LastPosition, 0);
        }
        else if (gameObject.transform.position.y < Pos_1.transform.GetComponent<CellPattern7>().points[3].y)
        {
            transform.DOMove(LastPosition, 0);
        }
        else if (gameObject.transform.position.y > Pos_2.transform.GetComponent<CellPattern7>().points[0].y)
        {
            transform.DOMove(LastPosition, 0);
        }
    }

    public void PositionCheck()
    {        
        foreach (CellPattern7 cell in Pattern_7.Instance.CellGroup)
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
