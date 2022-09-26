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
        Pattern_8.OlchamPosition();
        //Pattern_8.CanvasOut[1].GetComponent<PointsParent>().InstantiatePoints();        
    }
    private void Awake()
    {
       
    }  
    public void SquareLocation()
    {      
        for (float i = -4.5f * Pattern_8.percentage; i < Pattern_8.width - 4.5f * Pattern_8.percentage; i += Pattern_8.percentage)
        {
            for (float j = -4.5f * Pattern_8.percentage; j < Pattern_8.height - 4.5f * Pattern_8.percentage; j += Pattern_8.percentage)
            {
                GameObject SpawnedCell = Instantiate(Cell, new Vector3(j, i), Quaternion.identity, gameObject.transform);
                Pattern_8.CellGroup.Add(SpawnedCell.GetComponent<Cell>());
                Pattern_8.CellObj.Add(SpawnedCell);
            }
        }        
        gameObject.transform.position = Pattern_8.CellPosition.transform.position;
    }
}
