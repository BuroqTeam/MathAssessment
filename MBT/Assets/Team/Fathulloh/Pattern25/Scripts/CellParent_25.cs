using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellParent_25 : MonoBehaviour
{
    public Pattern_25 Pattern_25;
    public GameObject Cell;


    void Start()
    {
        SquareLocation();
        Pattern_25.XYPosition();
    }


    public void SquareLocation()
    {
        for (float i = -4.5f * Pattern_25.percentage; i < Pattern_25.width - 4.5f * Pattern_25.percentage; i += Pattern_25.percentage)
        {
            for (float j = -4.5f * Pattern_25.percentage; j < Pattern_25.height - 4.5f * Pattern_25.percentage; j += Pattern_25.percentage)
            {
                GameObject SpawnedCell = Instantiate(Cell, new Vector3(j, i), Quaternion.identity, gameObject.transform);
                Pattern_25.CellGroup.Add(SpawnedCell.GetComponent<CellPattern_25>());
                Pattern_25.CellObj.Add(SpawnedCell);
            }
        }
        gameObject.transform.position = Pattern_25.CanvasOut[2].transform.position;        
    }


}
