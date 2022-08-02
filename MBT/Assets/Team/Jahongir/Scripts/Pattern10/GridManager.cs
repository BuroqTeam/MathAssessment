using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width;

    [SerializeField] private GameObject tilePrefab;

    private void Start()
    {
        GenerateGrid();
    }
    void GenerateGrid()
    {
        for (int i = 0; i < 2*_width; i++)
        {
            Instantiate(tilePrefab, transform);
        }   
    }
}
