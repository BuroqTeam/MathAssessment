using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaLine : MonoBehaviour
{
    public Transform SittingBoy;
    private LineRenderer lineRenderer;
    private Vector3 distanceVec;

    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        distanceVec = SittingBoy.position - lineRenderer.GetPosition(1);
    }

    public void DrawLine(Vector3 pos)
    {
        Vector3 newPos = pos - distanceVec;
        lineRenderer.SetPosition(1, newPos);
    }
    
}
