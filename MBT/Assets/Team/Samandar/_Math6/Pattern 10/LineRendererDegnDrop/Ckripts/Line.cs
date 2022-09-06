using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider2D;
    public Rigidbody2D rigidBody;

    [HideInInspector] public List<Vector2> points = new List<Vector2>();
    [HideInInspector] public int pointsCount = 0;

    float pointsMinDistance = 0.1f;

    public void AddPoint(Vector2 newPoint)
    {
        if (points.Count >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
            return;
        points.Add(newPoint);
        pointsCount++;
        lineRenderer.positionCount = pointsCount;
        lineRenderer.SetPosition(pointsCount - 1, newPoint);

        if (pointsCount > 1)
            edgeCollider2D.points = points.ToArray();
    }
    public Vector2 GetLastPoint()
    {
        return (Vector2)lineRenderer.GetPosition(pointsCount - 1);
    }
    public void UsePhysics(bool usePhysics)
    {
        rigidBody.isKinematic = !usePhysics;
    }
    public void SetLineColor(Gradient colorGradient)
    {
        lineRenderer.colorGradient = colorGradient;
    }
    public void SetPointsMinDistanse(float distanse)
    {
        pointsMinDistance = distanse;
    }
    public void SetLineWidth(float width)
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;

        edgeCollider2D.edgeRadius = width / 2f;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
