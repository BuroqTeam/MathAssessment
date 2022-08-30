using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pattern_7 : MonoBehaviour
{
    public static Pattern_7 Instance;    
    public float width;
    public float height;
    public GameObject PenTool;
    public List<GameObject> Button;
    public GameObject LineParent;
    public GameObject DotParent;
    public GameObject CellParent;
    public GameObject Cell;
    public GameObject Koordinata;
    GameObject CellInstanse;
    public Transform Camera;
    public float percentage;
    public List<CellPattern7> CellGroup = new List<CellPattern7>();
    bool Yoqish = false;
    bool _isTrueOneTime = true;
    public PointsPattern7 Point;
    public CellPattern7 cellPattern7;
    private void Awake()
    {
        GameObject obj = Instantiate(CellParent);
        CellParent.GetComponent<CellParent>().Pattern_7 = this;
        Instance = this;
        percentage = Cell.transform.localScale.x;
    }

    void Start()
    {         
        CellPosition();
        //cellPattern7.CollectPoints();
    }
    public void TurnOnTurnOf()
    {
        if (Yoqish == false)
        {
            Yoqish = true;
            PenTool.SetActive(false);
        }
        else
        {
            Yoqish = false;
            PenTool.SetActive(true);
        }
    }
    void CellPosition()
    {
        GameObject obj = Instantiate(Koordinata);
        Koordinata.transform.position = PenTool.transform.position;
    }
    public void LineParentTurnOn()
    {
        LineParent.transform.GetChild(0).gameObject.SetActive(true);
        LineParent.transform.GetChild(0).transform.GetComponent<LineRenderer>().loop = true;
    }

    public void False()
    {
        if (LineParent.transform.childCount == 1)
        {
            _isTrueOneTime = false;
            LineParent.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void OnDestroy()
    {
        Destroy(LineParent.transform.GetChild(0).gameObject);
        for (int i = 0; i < DotParent.transform.childCount; i++)
        {
            Destroy(DotParent.transform.GetChild(i).gameObject);
        }         
    }
    //public void SquareLocation()
    //{
        
    //    for (float i = 0; i < width; i += percentage)
    //    {
    //        for (float j = 0; j < height; j += percentage)
    //        {
    //            GameObject SpawnedCell = Instantiate(Cell, new Vector3(i, j), Quaternion.identity, CellParent.transform);
    //            CellGroup.Add(SpawnedCell.GetComponent<CellPattern7>());
    //            CellInstanse = SpawnedCell;
    //        }
    //    }
    //    Camera.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, transform.position.z);
    //} 

    void Update()
    {
        if (_isTrueOneTime)
        {
           
        }
    }

  
}

