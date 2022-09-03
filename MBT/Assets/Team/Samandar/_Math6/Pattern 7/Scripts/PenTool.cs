using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
;

public class PenTool : MonoBehaviour
{
    public PointsPattern7 pointsPattern7;
    public GameObject linePrefabs;
    public GameObject Point;
    public GameObject lineParent;
    public GameObject dotParent; 
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
            currentLine = Instantiate(linePrefabs, Vector3.zero, Quaternion.identity, lineParent.transform).GetComponent<LineControllerPattern7>();
            Pattern7.False();
         }
         GameObject dot = Instantiate(Point, GetMousePosition(), Quaternion.identity, dotParent.transform);
         pointsPattern7.Check();
         currentLine.AddPoint(dot.transform);
         if (Pattern7.CanvasOut[0].transform.childCount == Pattern7.Data7.options.Count)
         {
            Pattern7.Buttons[0].GetComponent<Button>().interactable = false;
         }
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
