using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenToolP8 : MonoBehaviour
{
    [Header("Pen Canvas")]
    [SerializeField] private PenCanvasP8 penCanvas;

    [Header("Dots")]
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] Transform dotParent;
    

    [Header("Lines")]
    [SerializeField] private GameObject linePrefab;
    [SerializeField] Transform lineParent;

    private LineControllerP8 currentLine;

    
    void Start()
    {
        penCanvas.onPenCanvasLeftClickEvent += AddDot;
    }


    private void AddDot()
    {
        if (currentLine == null)
        {
            currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent).GetComponent<LineControllerP8>();

        }

        DotControllerP8 dot = Instantiate(dotPrefab, GetMousePosition(), Quaternion.identity, dotParent).GetComponent<DotControllerP8>();
        dot.OnDragEvent += MoveDot;
        currentLine.AddPoint(dot.transform);
    }

    
    private void MoveDot(DotControllerP8 dot)
    {
        dot.transform.position = GetMousePosition();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }


    private Vector3 GetMousePosition()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePosition.z = 0;

        return worldMousePosition;
    }


}
