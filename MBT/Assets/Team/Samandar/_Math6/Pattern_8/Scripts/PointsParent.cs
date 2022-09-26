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
                GameObject point = Instantiate(PointPrefabs, gameObject.transform);
                Pattern_8.PointList.Add(point);                 
            }
            Pattern_8.Point();            
        }
        else if(PointNumber == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject point = Instantiate(PointPrefabs, gameObject.transform);
                Pattern_8.PointList.Add(point);
            }
            Pattern_8.Point();           
        }
        else if (PointNumber == 4)
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject point = Instantiate(PointPrefabs, gameObject.transform);
                Pattern_8.PointList.Add(point);
            }
            Pattern_8.Point();            
        }        
    }
}
