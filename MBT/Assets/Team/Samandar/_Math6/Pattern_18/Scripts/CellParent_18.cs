using UnityEngine;

public class CellParent_18 : MonoBehaviour
{
    public Pattern_18 Pattern_18;
    public GameObject Cell;

    void Start()
    {
        SquareLocation();
        Pattern_18.XYPosition();
    }

    public void SquareLocation()
    {
        for (float i = -4.5f * Pattern_18.percentage; i < Pattern_18.width - 4.5f * Pattern_18.percentage; i += Pattern_18.percentage)
        {
            for (float j = -4.5f * Pattern_18.percentage; j < Pattern_18.height - 4.5f * Pattern_18.percentage; j += Pattern_18.percentage)
            {
                GameObject SpawnedCell = Instantiate(Cell, new Vector3(j, i), Quaternion.identity, gameObject.transform);
                Pattern_18.CellGroup.Add(SpawnedCell.GetComponent<CellPattern_18>());
                Pattern_18.CellObj.Add(SpawnedCell);
            }
        }
        gameObject.transform.position = Pattern_18.CanvasOut[1].transform.position;
    }
}
