using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PenCanvas_20 : MonoBehaviour, IPointerClickHandler
{
    public PointsPattern_20 pointsPattern7;
    public GameObject linePrefabs;
    public GameObject Point;
    public GameObject lineParent;
    public GameObject dotParent;
    private LineControllerPattern_20 currentLine;
    public Action OnPenCanvasLeftClickEvent;
    public Vector3 HandPosition;
    Camera main;
    public Pattern_20 Pattern_20;
    private void Awake()
    {
        main = Camera.main;
    }
    private void Start()
    {
        dotParent = Pattern_20.DotParent;
        lineParent = Pattern_20.LineParent;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 point = main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 0));
        point = new Vector3(point.x, point.y, 0);
        if (currentLine == null)
        {
            currentLine = Instantiate(linePrefabs, Vector3.zero, Quaternion.identity, lineParent.transform).GetComponent<LineControllerPattern_20>();
            Pattern_20.False();
        }
        GameObject dot = Instantiate(Point, point, Quaternion.identity, dotParent.transform);
        Pattern_20.DotsList.Add(dot);
        dot.GetComponent<PointsPattern7>().LastPosition = dot.transform.position;
        pointsPattern7.PositionCheck();
        currentLine.AddPoint(dot.transform);
        if (Pattern_20.CanvasOut[0].transform.childCount == Pattern_20.Data20.options.Count)
        {
            Pattern_20.Buttons[1].GetComponent<Button>().interactable = true;
            Pattern_20.Buttons[0].GetComponent<Button>().interactable = false;
            gameObject.SetActive(false);
        }
        else if (Pattern_20.CanvasOut[0].transform.childCount == 1)
        {
            Pattern_20.Buttons[2].GetComponent<Button>().interactable = true;
        }
        for (int i = 0; i < Pattern_20.DotsList.Count; i++)
        {
            Pattern_20.DotsList[i].transform.GetComponent<PointsPattern_20>().GetData();
        }
        //Debug.Log(point);
        //GameObject circle =  Instantiate(circle, point);

        if (eventData.pointerId == -1)
        {
            OnPenCanvasLeftClickEvent?.Invoke();
        }
    }
}
