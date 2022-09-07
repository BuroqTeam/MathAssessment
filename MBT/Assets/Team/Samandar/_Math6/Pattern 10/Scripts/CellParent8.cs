using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellParent8 : MonoBehaviour
{
    public Pattern_8 Pattern_8;
    public GameObject Cell;

    void Start()
    {
        SquareLocation();
    }

    public void SquareLocation()
    {
        for (float i = 0; i < Pattern_8.width; i += Pattern_8.percentage)
        {
            for (float j = 0; j < Pattern_8.height; j += Pattern_8.percentage)
            {
                GameObject SpawnedCell = Instantiate(Cell, new Vector3(j, i), Quaternion.identity, gameObject.transform);
                Pattern_8.CellGroup.Add(SpawnedCell.GetComponent<Cell>());
                Pattern_8.CellObj.Add(SpawnedCell);
            }
        }
        gameObject.transform.position = Pattern_8.CellPosition.transform.position;
    }
}
