using UnityEngine;

public class CellParent_20 : MonoBehaviour
{
    public Pattern_20 Pattern_20;
    public GameObject Cell;

    void Start()
    {
        SquareLocation();
        Pattern_20.XYPosition();
    }

    public void SquareLocation()
    {
        for (float i = -4.5f * Pattern_20.percentage; i < Pattern_20.width - 4.5f * Pattern_20.percentage; i += Pattern_20.percentage)
        {
            for (float j = -4.5f * Pattern_20.percentage; j < Pattern_20.height - 4.5f * Pattern_20.percentage; j += Pattern_20.percentage)
            {
                GameObject SpawnedCell = Instantiate(Cell, new Vector3(j, i), Quaternion.identity, gameObject.transform);
                Pattern_20.CellGroup.Add(SpawnedCell.GetComponent<CellPattern_20>());
                Pattern_20.CellObj.Add(SpawnedCell);
            }
        }
        gameObject.transform.position = Pattern_20.CanvasOut[3].transform.position;
    }   
}
