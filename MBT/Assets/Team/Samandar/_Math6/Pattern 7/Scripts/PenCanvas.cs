using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PenCanvas : MonoBehaviour, IPointerClickHandler
{
    public PointsPattern7 pointsPattern7;
    public GameObject linePrefabs;
    public GameObject Point;
    public GameObject lineParent;
    public GameObject dotParent;
    private LineControllerPattern7 currentLine;
    public Action OnPenCanvasLeftClickEvent;
    public Vector3 HandPosition;
    Camera main;
    public Pattern_7 Pattern7;
    private void Awake()
    {
        main = Camera.main;
    }
    private void Start()
    {
        dotParent = Pattern7.DotParent;
        lineParent = Pattern7.LineParent;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 point = main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 0));
        point = new Vector3(point.x, point.y, 0);
        if (currentLine == null)
        {
            currentLine = Instantiate(linePrefabs, Vector3.zero, Quaternion.identity, lineParent.transform).GetComponent<LineControllerPattern7>();
            Pattern7.False();
        }
        GameObject dot = Instantiate(Point, point, Quaternion.identity, dotParent.transform);
        Pattern7.DotsList.Add(dot);
        dot.GetComponent<PointsPattern7>().LastPosition = dot.transform.position;
        pointsPattern7.PositionCheck();
        currentLine.AddPoint(dot.transform);
        if (Pattern7.CanvasOut[0].transform.childCount == Pattern7.Data7.options.Count)
        {
            Pattern7.Buttons[1].GetComponent<Button>().interactable = true;
            Pattern7.Buttons[0].GetComponent<Button>().interactable = false;
            gameObject.SetActive(false);
        }
        else if (Pattern7.CanvasOut[0].transform.childCount == 1)
        {
            Pattern7.Buttons[2].GetComponent<Button>().interactable = true;
        }
        for (int i = 0; i < Pattern7.DotsList.Count; i++)
        {
            Pattern7.DotsList[i].transform.GetComponent<PointsPattern7>().GetData();
        }
        //Debug.Log(point);
        //GameObject circle =  Instantiate(circle, point);

        if (eventData.pointerId == -1)
        {
            OnPenCanvasLeftClickEvent?.Invoke();
        }
    }
}
