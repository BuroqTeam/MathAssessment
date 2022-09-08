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
        PointPosition();
    }
    public void PointPosition()
    {
        Debug.Log("1");
        for (int i = 0; i < PointNumber; i++)
        {
            GameObject point = Instantiate(PointPrefabs, gameObject.transform);
            Pattern_8.PointList.Add(point);            
        }        
    }    
    
    void Update()
    {
        
    }
}
