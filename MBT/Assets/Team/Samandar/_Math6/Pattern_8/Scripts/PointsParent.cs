using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsParent : MonoBehaviour
{
    public Pattern_8 Pattern_8;
    public GameObject PointPrefabs;
    public int PointNumber;
    public List<GameObject> Pointlist;
    void Start()
    {
        PointNumber =  Pattern_8.Figure;
        InstantiatePoints();
        //PointPosition();
    }
    public void InstantiatePoints()
    {
        if (PointNumber == 2)
        {
            for (int i = 0; i < 3; i++)
            {
                Logging.Log("2Isgkfhwieu");
                GameObject point = Instantiate(PointPrefabs, gameObject.transform);
                Pattern_8.PointList.Add(point);
            }
            Pattern_8.Point();
        }
        else if(PointNumber == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                Logging.Log("1Isgkfhwieu");
                GameObject point = Instantiate(PointPrefabs, gameObject.transform);
                Pattern_8.PointList.Add(point);
            }
            Pattern_8.Point();
        }
        else if (PointNumber == 4)
        {
            for (int i = 0; i < 4; i++)
            {
                Logging.Log("Isgkfhwieu");
                GameObject point = Instantiate(PointPrefabs, gameObject.transform);
                Pattern_8.PointList.Add(point);
            }
            Pattern_8.Point();
        }        
    }    
    //public void PointPosition()
    //{
    //    Pattern_8.PointList[0].transform.position = Pattern_8.CellObj[25].transform.GetComponent<Cell>().points[0];
    //    Pattern_8.PointList[1].transform.position = Pattern_8.CellObj[45].transform.GetComponent<Cell>().points[0];
    //    Pattern_8.PointList[2].transform.position = Pattern_8.CellObj[75].transform.GetComponent<Cell>().points[0];
    //}
    void Update()
    {
        
    }
}
