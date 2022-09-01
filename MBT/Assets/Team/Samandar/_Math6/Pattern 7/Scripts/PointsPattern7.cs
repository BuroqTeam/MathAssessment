using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointsPattern7 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Pattern_7 Pattern_7;
    private Transform _initial;
    private Transform _initialPosition;
    private GameObject Pos_1;
    private GameObject Pos_2;
    public void OnBeginDrag(PointerEventData eventData)
    {
        _initial = GetComponent<Transform>();
        Debug.Log(_initial.position.x);
        Debug.Log(_initial.position.y);
        Pos_1 = Pattern_7.CellObj[0];
        Pos_2 = Pattern_7.CellObj[99];
    }
    private void Awake()
    {
        _initialPosition = GetComponent<Transform>();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
       
        Check();
        CheckPosition();
    }

    private void Start()
    {
        Check();
    }

    void CheckPosition()
    {
        if (gameObject.transform.position.x < Pos_1.transform.GetComponent<CellPattern7>().points[3].x)
        {
            Debug.Log("1");
            _initialPosition.position = new Vector3(_initial.position.x, _initial.position.y, 0);
            Debug.Log(_initialPosition.position);
        }
        else if(gameObject.transform.position.x > Pos_2.transform.GetComponent<CellPattern7>().points[0].x)
        {
            Debug.Log("2");
            _initialPosition.position = new Vector2(_initial.position.x, _initial.position.y);
        }
        else if (gameObject.transform.position.y < Pos_1.transform.GetComponent<CellPattern7>().points[3].y)
        {
            Debug.Log("3");
            _initialPosition.position = new Vector2(_initial.position.x, _initial.position.y);
        }
        else if (gameObject.transform.position.y > Pos_2.transform.GetComponent<CellPattern7>().points[0].y)
        {
            Debug.Log("4");
            _initialPosition.position = new Vector2(_initial.position.x, _initial.position.y);
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
   

    void Update()
    {

    }

    
}
