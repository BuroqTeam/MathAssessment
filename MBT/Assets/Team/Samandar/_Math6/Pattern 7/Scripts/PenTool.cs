using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PenTool : MonoBehaviour
{
    public PointsPattern7 pointsPattern7;
    public GameObject linePrefabs;
    public GameObject Point;
    public Transform lineParent;
    public Transform dotParent; 
    private LineControllerPattern7 currentLine;
    public Pattern_7 Pattern7;
    public PenCanvas penCanvas;
    
    void Start()
    {
        penCanvas.OnPenCanvasLeftClickEvent += AddDot;
        dotParent = Pattern7.DotParent;
        lineParent = Pattern7.LineParent;
    }

    public void AddDot()
    {
        
         if (currentLine == null)
         {
            currentLine = Instantiate(linePrefabs, Vector3.zero, Quaternion.identity, lineParent).GetComponent<LineControllerPattern7>();
            Pattern7.False();
         }
         GameObject dot = Instantiate(Point, GetMousePosition(), Quaternion.identity, dotParent);
         pointsPattern7.Check();
         currentLine.AddPoint(dot.transform);
    }

  

    public Vector3 GetMousePosition()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePosition.z = 0;
        pointsPattern7.Check();
        return worldMousePosition;
    }
   
    // Update is called once per frame
    
}
