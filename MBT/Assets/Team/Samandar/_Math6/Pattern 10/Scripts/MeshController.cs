using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour
{
    public Pattern_8 Pattern_8;
    public Transform[] points;
    void Start()
    {
                
    }

    public void MeshPointPosition()
    {
        if (Pattern_8.Figure[0] == 2)
        {
            points[0] = Pattern_8.PointList[0].transform;
            points[1] = Pattern_8.PointList[1].transform;
            points[2] = Pattern_8.PointList[2].transform;
        }
        else if (Pattern_8.Figure[1] == 3)
        {
            points[0] = Pattern_8.PointList[0].transform;
            points[1] = Pattern_8.PointList[1].transform;
            points[2] = Pattern_8.PointList[2].transform;
        }
        else if (Pattern_8.Figure[2] == 3)
        {
            points[0] = Pattern_8.PointList[0].transform;
            points[1] = Pattern_8.PointList[1].transform;
            points[2] = Pattern_8.PointList[2].transform;
            points[3] = Pattern_8.PointList[3].transform;
        }
        
    }    
    public void StartMetod()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[3];
        if (Pattern_8.Figure[0] == 2)
        {
            vertices[0] = new Vector3(points[0].transform.position.x, points[0].transform.position.y);
            vertices[1] = new Vector3(points[1].transform.position.x, points[1].transform.position.y);
            vertices[2] = new Vector3(points[2].transform.position.x, points[2].transform.position.y);
        }
        else if(Pattern_8.Figure[1] == 3)
        {
            vertices[0] = new Vector3(points[0].transform.position.x, points[0].transform.position.y);
            vertices[1] = new Vector3(points[1].transform.position.x, points[1].transform.position.y);
            vertices[2] = new Vector3(points[2].transform.position.x, points[2].transform.position.y);
        }
        else if(Pattern_8.Figure[2] == 4)
        {
            vertices[0] = new Vector3(points[0].transform.position.x, points[0].transform.position.y);
            vertices[1] = new Vector3(points[1].transform.position.x, points[1].transform.position.y);
            vertices[2] = new Vector3(points[2].transform.position.x, points[2].transform.position.y);
            vertices[3] = new Vector3(points[3].transform.position.x, points[3].transform.position.y);
        }
        mesh.vertices = vertices;

        mesh.triangles = new int[] { 0, 1, 2/*, 0, 2, 3 */};

        GetComponent<MeshFilter>().mesh = mesh;
    }
    void Update()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[3];
        if (Pattern_8.Figure[0] == 2)
        {
            vertices[0] = new Vector3(points[0].transform.position.x, points[0].transform.position.y);
            vertices[1] = new Vector3(points[1].transform.position.x, points[1].transform.position.y);
            vertices[2] = new Vector3(points[2].transform.position.x, points[2].transform.position.y);
        }
        else if (Pattern_8.Figure[1] == 3)
        {
            vertices[0] = new Vector3(points[0].transform.position.x, points[0].transform.position.y);
            vertices[1] = new Vector3(points[1].transform.position.x, points[1].transform.position.y);
            vertices[2] = new Vector3(points[2].transform.position.x, points[2].transform.position.y);
        }
        else if (Pattern_8.Figure[2] == 4)
        {
            vertices[0] = new Vector3(points[0].transform.position.x, points[0].transform.position.y);
            vertices[1] = new Vector3(points[1].transform.position.x, points[1].transform.position.y);
            vertices[2] = new Vector3(points[2].transform.position.x, points[2].transform.position.y);
            vertices[3] = new Vector3(points[3].transform.position.x, points[3].transform.position.y);
        }

        mesh.vertices = vertices;

        mesh.triangles = new int[] { 0, 1, 2};

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
