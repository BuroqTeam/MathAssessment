using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControllarPattern_8 : MonoBehaviour
{
    public Pattern_8 Pattern_8;
    private LineRenderer lineRenderer;
    private List<Transform> points;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Start()
    {
        Pattern_8.LinePosition.GetComponent<LineTesting>().Line = this;
        Pattern_8.LinePosition.GetComponent<LineTesting>().PointTransform();
        Pattern_8.LinePosition.GetComponent<LineTesting>().LinePoint();        
    }

    public void SetUpLine(List<Transform> points)
    {
        lineRenderer.positionCount = points.Count;
        this.points = points;
    }

    void Update()
    {
        for (int i = 0; i < points.Count; i++)
        {
            lineRenderer.SetPosition(i, points[i].position);
        }
    }
}
