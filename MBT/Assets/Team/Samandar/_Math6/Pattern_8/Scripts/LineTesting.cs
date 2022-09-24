using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTesting : MonoBehaviour
{
    public Pattern_8 Pattern_8;
    public List<Transform> Points;
    public LineControllarPattern_8 Line;
    void Start()
    {
        
    }
    public void PointTransform()
    {
        if (Pattern_8.Figure == 2)
        {
            Transform Points0 = Pattern_8.PointList[0].transform;
            Transform Points1 = Pattern_8.PointList[1].transform;
            Transform Points2 = Pattern_8.PointList[2].transform;
            Transform Points3 = Pattern_8.PointList[0].transform;
            Points.Add(Points0);
            Points.Add(Points1);
            Points.Add(Points2);
            Points.Add(Points3);
        }
        else if (Pattern_8.Figure == 3)
        {
            Transform Points0 = Pattern_8.PointList[0].transform;
            Transform Points1 = Pattern_8.PointList[1].transform;
            Transform Points2 = Pattern_8.PointList[2].transform;
            Transform Points3 = Pattern_8.PointList[0].transform;
            Points.Add(Points0);
            Points.Add(Points1);
            Points.Add(Points2);
            Points.Add(Points3);
        }
        else if (Pattern_8.Figure == 4)
        {
            Transform Points0 = Pattern_8.PointList[0].transform;
            Transform Points1 = Pattern_8.PointList[1].transform;
            Transform Points2 = Pattern_8.PointList[2].transform;
            Transform Points3 = Pattern_8.PointList[3].transform;
            Transform Points4 = Pattern_8.PointList[0].transform;
            Points.Add(Points0);
            Points.Add(Points1);
            Points.Add(Points2);
            Points.Add(Points3);
            Points.Add(Points4);
        }
    }
    public void LinePoint()
    {
        Line.SetUpLine(Points);
    }
    void Update()
    {

    }
}
