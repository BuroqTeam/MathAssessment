using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPattern_7 : MonoBehaviour
{


    SpriteRenderer spriteRenderer;


    public List<Vector3> points = new List<Vector3>();


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CollectPoints();

    }

    public void CollectPoints()
    {
        float rightPointX = transform.localPosition.x + spriteRenderer.bounds.size.x * 0.5f;
        float upPointY = transform.localPosition.y + spriteRenderer.bounds.size.y * 0.5f;
        points.Add(new Vector3(rightPointX, upPointY, 0));
        points.Add(new Vector3(rightPointX, -upPointY, 0));
        points.Add(new Vector3(-rightPointX, -upPointY, 0));
        points.Add(new Vector3(-rightPointX, upPointY, 0));

    }


}
