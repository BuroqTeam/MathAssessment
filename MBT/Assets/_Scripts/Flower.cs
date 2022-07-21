using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Extension;

public class Flower : MonoBehaviour
{
    public FlowerSO FlowerSo;

    [HideInInspector]
    public List<Image> LeafGroup;

    private void Awake()
    {
        SetInitial();       
    }

    void SetInitial()
    {
        List<GameObject> leafGroup = transform.GetChild(0).transform.GetChildren();
        foreach (GameObject obj in leafGroup)
        {
            LeafGroup.Add(obj.GetComponent<Image>());
        }
    }




}
