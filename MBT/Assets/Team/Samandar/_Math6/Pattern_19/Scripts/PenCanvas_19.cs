using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PenCanvas_19 : MonoBehaviour, IPointerClickHandler
{
    public PointsPattern_19 pointsPattern_19;
    public GameObject linePrefabs;
    public GameObject Point;
    public GameObject lineParent;
    public GameObject dotParent;
    public Action OnPenCanvasLeftClickEvent;
    public Vector3 HandPosition;
    Camera main;
    public Pattern_19 Pattern_19;
    private void Awake()
    {
        main = Camera.main;
    }
    private void Start()
    {
        dotParent = Pattern_19.DotParent;
        //lineParent = Pattern_19.LineParent;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 point = main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 0));
        point = new Vector3(point.x, point.y, 0);
        GameObject dot = Instantiate(Point, point, Quaternion.identity, dotParent.transform);
        Pattern_19.DotsList.Add(dot);
        dot.GetComponent<PointsPattern_19>().LastPosition = dot.transform.position;
        pointsPattern_19.PositionCheck();
        if (Pattern_19.CanvasOut[0].transform.childCount == Pattern_19.Data19.options.Count)
        {
            Pattern_19.Buttons[1].GetComponent<Button>().interactable = true;
            Pattern_19.Buttons[0].GetComponent<Button>().interactable = false;
            gameObject.SetActive(false);
        }
        //else if (Pattern_19.CanvasOut[0].transform.childCount == 1)
        //{
        //    Pattern_19.Buttons[2].GetComponent<Button>().interactable = true;
        //}
        for (int i = 0; i < Pattern_19.DotsList.Count; i++)
        {
            Pattern_19.DotsList[i].transform.GetComponent<PointsPattern_19>().GetData();
        }
        //Debug.Log(point);
        //GameObject circle =  Instantiate(circle, point);

        if (eventData.pointerId == -1)
        {
            OnPenCanvasLeftClickEvent?.Invoke();
        }
    }
}
