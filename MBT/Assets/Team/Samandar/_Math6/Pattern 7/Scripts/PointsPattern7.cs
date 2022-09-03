using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointsPattern7 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Pattern_7 Pattern_7;
  
    private GameObject Pos_1;
    private GameObject Pos_2;

    public Vector3 LastPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
      
        Pos_1 = Pattern_7.CellObj[0];
        Pos_2 = Pattern_7.CellObj[99];
    }

    private void Start()
    {
        Check();
    }



    public void OnEndDrag(PointerEventData eventData)
    {
       
        Check();
        BackToLastPosition();
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

    public void Check()
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
