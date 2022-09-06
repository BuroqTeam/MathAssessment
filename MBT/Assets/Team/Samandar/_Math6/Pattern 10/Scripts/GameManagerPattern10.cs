using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPattern10 : MonoBehaviour
{
    public static GameManagerPattern10 Instance;
    
    public int width;
    public int height;
    //public float tileSize;
    public GameObject Cell;
    public Transform Camera;
    float percentage;
    public List<Cell> CellGroup = new List<Cell>();


    private void Awake()
    {
        Instance = this;
        percentage = Cell.transform.localScale.x;
    }

    void Start()
    {
        SquareLocation();
    }

    public void SquareLocation()
    {
        for (float i = 0; i < width; i+=percentage)
        {
            for (float j = 0; j < height; j+=percentage)
            {
                var SpawnedCell = Instantiate(Cell, new Vector3(i, j), Quaternion.identity);
                //SpawnedCell.name = $"Cell {i}, {j}";
                CellGroup.Add(SpawnedCell.GetComponent<Cell>());
            }
        }
        Camera.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, transform.position.z - 200);
    }

    void Update()
    {
        
    }
}
