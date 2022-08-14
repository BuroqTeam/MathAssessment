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

    [HideInInspector]
    public Image Center;

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
        Center = transform.GetChild(1).GetComponent<Image>();
    }

    public void UpdateFlower(int number)
    {
        if (number > 0)
        {
            Center.sprite = FlowerSo.CenterOn;
            for (int i = 0; i < number; i++)
            {
                LeafGroup[i].sprite = FlowerSo.LeafOn;
            }
        }
    }




}
