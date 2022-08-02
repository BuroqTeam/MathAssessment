using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControllerPattern_7 : MonoBehaviour
{
    private LineRenderer lr;
    private List<Transform> points;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 0;
        points = new List<Transform>();
    }
    void Start()
    {

    }

    public void AddPoint(Transform point)
    {
        lr.positionCount++;
        points.Add(point);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (points.Count >= 2)
        {
            for (int i = 0; i < points.Count; i++)
            {
                lr.SetPosition(i, points[i].position);
            }
        }

    }
}
