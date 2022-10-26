using UnityEngine;

public class CellParent : MonoBehaviour
{
    public Pattern_7 Pattern_7;
    public GameObject Cell;

    void Start()
    {        
        SquareLocation();
        Pattern_7.XYPosition();
    }

    public void SquareLocation()
    {
        for (float i = -4.5f * Pattern_7.percentage; i < Pattern_7.width - 4.5f * Pattern_7.percentage; i += Pattern_7.percentage)
        {
            for (float j = -4.5f * Pattern_7.percentage; j < Pattern_7.height - 4.5f * Pattern_7.percentage; j += Pattern_7.percentage)
            {
                GameObject SpawnedCell = Instantiate(Cell, new Vector3(j, i), Quaternion.identity, gameObject.transform);
                Pattern_7.CellGroup.Add(SpawnedCell.GetComponent<CellPattern7>());
                Pattern_7.CellObj.Add(SpawnedCell);                
            }
        }
        gameObject.transform.position = Pattern_7.CanvasOut[3].transform.position;        
    }
    void Update()
    {
        
    }
}
