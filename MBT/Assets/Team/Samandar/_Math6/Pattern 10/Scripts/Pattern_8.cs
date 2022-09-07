using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_8 : MonoBehaviour
{
    public static Pattern_8 Instance;
    public GameObject CellPosition;
    public GameObject CellParent;
    public List<GameObject> CanvasOut;
    public List<GameObject> CellObj;
    public float width;
    public float height;
    //public float tileSize;
    public GameObject Cell;
    //public Transform Camera;
    public float percentage;
    public List<Cell> CellGroup = new List<Cell>();


    private void Awake()
    {
        Instance = this;
        percentage = Cell.transform.localScale.x;
        InstantiateObj();

    }

    void Start()
    {
        //SquareLocation();
    }
    void InstantiateObj()
    {
        GameObject parent = Instantiate(CellParent);
        CanvasOut.Add(parent);
        CanvasOut[0].transform.GetComponent<CellParent8>().Pattern_8 = this;
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
