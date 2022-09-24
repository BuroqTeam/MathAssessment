using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsParent : MonoBehaviour
{
    public Pattern_8 Pattern_8;
    public GameObject PointPrefabs;
    public int PointNumber;
    public List<GameObject> Pointlist;
    int k = 0;
    void Start()
    {
        PointNumber = Pattern_8.Figure;
        InstantiatePoints();
    }
    private void Awake()
    {
       
    }

    public void InstantiatePoints()
    {
        if (PointNumber == 2)
        {            
            for (int i = 0; i < 3; i++)
            {
                //Logging.Log("2Isgkfhwieu");
                //Vector3 pos = Pattern_8.CellObj[i ^ 3 + 15].GetComponent<Cell>().points[0];
                GameObject point = Instantiate(PointPrefabs, gameObject.transform);
                Pattern_8.PointList.Add(point);                 
            }
            Pattern_8.Point();            
        }
        else if(PointNumber == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                //Logging.Log("1Isgkfhwieu");
                GameObject point = Instantiate(PointPrefabs, gameObject.transform);
                Pattern_8.PointList.Add(point);
            }
            Pattern_8.Point();           
        }
        else if (PointNumber == 4)
        {
            for (int i = 0; i < 4; i++)
            {
                //Logging.Log("Isgkfhwieu");
                GameObject point = Instantiate(PointPrefabs, gameObject.transform);
                Pattern_8.PointList.Add(point);
            }
            Pattern_8.Point();            
        }        
    }
}
