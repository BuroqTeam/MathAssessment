using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_8 : MonoBehaviour
{
    public static Pattern_8 Instance;
    public GameObject CellPosition;
    public GameObject CellParent;
    public GameObject PointParent;
    public List<GameObject> CanvasOut;
    public List<GameObject> CellObj;
    public List<GameObject> PointList;
    public float width;
    public float height;
    public GameObject Cell;
    public float percentage;
    public List<Cell> CellGroup = new();
    public float Pivot;
    public Data_8 Data8 = new();
    private void Awake()
    {
        Instance = this;
        percentage = Cell.transform.localScale.x;
        InstantiateObj();
    }

    void Start()
    {
        DegnDrop();
    }
    void DegnDrop()
    {
        for (int i = 0; i < CellObj.Count; i++)
        {
            CellObj[i].transform.GetComponent<Cell>().Pattern_8 = this;
        }
    }
    void InstantiateObj()
    {
        GameObject cellParent = Instantiate(CellParent);       
        CanvasOut.Add(cellParent);        
        CanvasOut[0].transform.GetComponent<CellParent8>().Pattern_8 = this;        
        GameObject pointsParent = Instantiate(PointParent);
        CanvasOut.Add(pointsParent);
        CanvasOut[1].transform.GetComponent<PointsParent>().Pattern_8 = this;
    }
    
    public void SquareLocation()
    {
        for (float i = 0; i < width; i+=percentage)
        {
            for (float j = 0; j < height; j+=percentage)
            {
                GameObject SpawnedCell = Instantiate(Cell, new Vector3(i, j), Quaternion.identity);
                //SpawnedCell.name = $"Cell {i}, {j}";                
                CellGroup.Add(SpawnedCell.GetComponent<Cell>());                
            }
        }        
    }

    void Update()
    {
        
    }
}
[SerializeField]
public class Data_8
{
    public string title;
    public string proportion;
}
