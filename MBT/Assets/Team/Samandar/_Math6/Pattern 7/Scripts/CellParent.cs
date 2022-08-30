using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellParent : MonoBehaviour
{
    public Pattern_7 Pattern_7;
    public GameObject Cell;
    
    void Start()
    {
        SquareLocation();
    }

    public void SquareLocation()
    {
        for (float i = -4.5f * Pattern_7.percentage; i < Pattern_7.width - 4.5f * Pattern_7.percentage; i += Pattern_7.percentage)
        {
            for (float j = -4.5f * Pattern_7.percentage; j < Pattern_7.height - 4.5f * Pattern_7.percentage; j += Pattern_7.percentage)
            {
                GameObject SpawnedCell = Instantiate(Cell, new Vector3(j, i), Quaternion.identity, gameObject.transform);
                Pattern_7.CellGroup.Add(SpawnedCell.GetComponent<CellPattern7>());
                
            }
        }
        gameObject.transform.position = Pattern_7.Koordinata.transform.position;
        //Pattern_7.Camera.transform.position = new Vector3((float)Pattern_7.width / 2 - 0.5f, (float)Pattern_7.height / 2 - 0.5f, transform.position.z);
    }
    void Update()
    {
        
    }
}
