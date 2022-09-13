using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    //public Pattern_8 Pattern_8;
    SpriteRenderer spriteRenderer;    
    public List<Vector3> points = new();
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CollectPoints();       
    }
    private void Awake()
    {
        
    }
    public void CollectPoints()
    {
       
        float rightPointX_1 = transform.position.x + spriteRenderer.bounds.size.x * 0.5f;
        float rightPointX_2 = transform.position.x - spriteRenderer.bounds.size.x * 0.5f;
        float upPointY_1 = transform.position.y + spriteRenderer.bounds.size.y * 0.5f;
        float upPointY_2 = transform.position.y - spriteRenderer.bounds.size.y * 0.5f;
        points.Add(new Vector3(rightPointX_1, upPointY_1, 0));
        points.Add(new Vector3(rightPointX_2, upPointY_1, 0));
        points.Add(new Vector3(rightPointX_1, upPointY_2, 0));
        points.Add(new Vector3(rightPointX_2, upPointY_2, 0));
    }   
}
