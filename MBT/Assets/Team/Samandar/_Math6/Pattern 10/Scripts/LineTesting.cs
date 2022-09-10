using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTesting : MonoBehaviour
{
    public Pattern_8 Pattern_8;
    public Transform[] points;
    public LineControllarPattern10 Line;
    void Start()
    {
        //PointTransform();
        
    }
    public void PointTransform()
    {
        points[0] = Pattern_8.PointList[0].transform;
        points[1] = Pattern_8.PointList[1].transform;
        points[2] = Pattern_8.PointList[2].transform;
        points[3] = Pattern_8.PointList[0].transform;
    }
    public void LinePoint()
    {
        Line.SetUpLine(points);
    }
    void Update()
    {

    }
}
