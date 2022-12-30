using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PenCanvas_25 : MonoBehaviour, IPointerClickHandler
{
    public PointsPattern_25 pointsPattern_25;
    public GameObject linePrefabs;
    public GameObject Point;
    public GameObject lineParent;
    public GameObject dotParent;
    public Action OnPenCanvasLeftClickEvent;
    public Vector3 HandPosition;
    Camera main;
    public Pattern_25 Pattern25;

    private void Awake()
    {
        main = Camera.main;
    }


    private void Start()
    {
        dotParent = Pattern25.DotParent;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 point = main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 0));
        point = new Vector3(point.x, point.y, 0);
        GameObject dot = Instantiate(Point, point, Quaternion.identity, dotParent.transform);
        Pattern25.DotsList.Add(dot);
        dot.GetComponent<PointsPattern_25>().LastPosition = dot.transform.position;
        pointsPattern_25.PositionCheck();
        if (Pattern25.CanvasOut[0].transform.childCount == Pattern25.Data25.options.Count)
        {
            Pattern25.Buttons[1].GetComponent<Button>().interactable = true;
            Pattern25.Buttons[0].GetComponent<Button>().interactable = false;
            gameObject.SetActive(false);
        }
        if (eventData.pointerId == -1)        
            OnPenCanvasLeftClickEvent?.Invoke();
                
    }


}
