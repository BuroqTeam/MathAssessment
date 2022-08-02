using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tilePrefab;

    [SerializeField] private Transform _cam;

    float percentage;

    private void Start()
    {
        GenerateGrid();
        percentage = _tilePrefab.transform.localScale.x;
    }
    void GenerateGrid()
    {
        for (float i = 0; i < _width; i++)
        {
            for (float j = 0; j < _height; j++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(i, j), Quaternion.identity);
                spawnedTile.name = $"Tile {i} {j}";
            }
        }
        _cam.transform.position = new Vector3((float)_width / 2, (float)_height / 2 - 0.5f, -50);
    }
}
