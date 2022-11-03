using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    public Pattern_20 Pattern_20;
    public GameObject PointPositionsPrefabs;
    public float Top;
    public float Size;
    public float SizeBolak;
    public float percentage;
    public List<char> AlphabetList;
    void Awake()
    {
        percentage = gameObject.transform.localScale.x;
        float _size = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y * percentage;
        SizeBolak = _size / (Pattern_20.Data20.options.Count);
        if (Pattern_20.Data20.options.Count == 8)
        {
            Top = 2.28f;
        }
        else if (Pattern_20.Data20.options.Count == 7)
        {
            Top = 2.33f;
        }
        else if (Pattern_20.Data20.options.Count == 6)
        {
            Top = 2.38f;
        }
        else if (Pattern_20.Data20.options.Count == 5)
        {
            Top = 2.5f;
        }
        else if (Pattern_20.Data20.options.Count == 4)
        {
            Top = 2.65f;
        }
        else if (Pattern_20.Data20.options.Count == 3)
        {
            Top = 2.95f;
        }
        else if (Pattern_20.Data20.options.Count == 2)
        {
            Top = 3.9f;
        }
        else if (Pattern_20.Data20.options.Count == 1)
        {
            Top = 1;
        }
        Size = _size / Top;
        float startPosition = gameObject.transform.position.y - Size;        
        for (float i = startPosition; i < gameObject.transform.position.y + _size / 2; i += SizeBolak)
        {
            GameObject SpawnedCell = Instantiate(PointPositionsPrefabs, new Vector3(gameObject.transform.position.x, i, -2), Quaternion.identity, gameObject.transform);
            Pattern_20.PointList.Add(SpawnedCell);
        }
        for (char ci = 'A'; ci <= 'Z'; ++ci)
        {
            AlphabetList.Add(ci);
        }
        //List<string> options = Pattern_20.Data20.options;
        Pattern_20.PointList.Reverse();
        for (int i = 0; i < Pattern_20.PointList.Count; i++)
        {
            Pattern_20.PointList[i].transform.GetChild(0).transform.GetComponent<TMP_Text>().text = AlphabetList[i].ToString();
        }
    }
}
