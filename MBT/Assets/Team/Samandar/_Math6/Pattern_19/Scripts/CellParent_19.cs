using UnityEngine;

public class CellParent_19 : MonoBehaviour
{
    public Pattern_19 Pattern_19;
    public GameObject Cell;

    void Start()
    {
        SquareLocation();
        Pattern_19.XYPosition();
    }

    public void SquareLocation()
    {
        for (float i = -4.5f * Pattern_19.percentage; i < Pattern_19.width - 4.5f * Pattern_19.percentage; i += Pattern_19.percentage)
        {
            for (float j = -4.5f * Pattern_19.percentage; j < Pattern_19.height - 4.5f * Pattern_19.percentage; j += Pattern_19.percentage)
            {
                GameObject SpawnedCell = Instantiate(Cell, new Vector3(j, i), Quaternion.identity, gameObject.transform);
                Pattern_19.CellGroup.Add(SpawnedCell.GetComponent<CellPattern_19>());
                Pattern_19.CellObj.Add(SpawnedCell);
            }
        }
        gameObject.transform.position = Pattern_19.CanvasOut[2].transform.position;
        //Pattern_19.Check();
    }
    void Update()
    {

    }
}
