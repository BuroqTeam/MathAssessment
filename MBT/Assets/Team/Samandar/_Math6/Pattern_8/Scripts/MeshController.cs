using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MeshController : MonoBehaviour
{
    public Pattern_8 Pattern_8;
    public List<Transform> points;
    void Start()
    {

    }

    public void MeshPointPosition()
    {
        if (Pattern_8.Figure == 2)
        {
            Transform points0 = Pattern_8.PointList[0].transform;
            Transform points1 = Pattern_8.PointList[1].transform;
            Transform points2 = Pattern_8.PointList[2].transform;
            points.Add(points0);
            points.Add(points1);
            points.Add(points2);            
        }
        else if (Pattern_8.Figure == 3)
        {
            Transform points0 = Pattern_8.PointList[0].transform;
            Transform points1 = Pattern_8.PointList[1].transform;
            Transform points2 = Pattern_8.PointList[2].transform;
            points.Add(points0);
            points.Add(points1);
            points.Add(points2);
        }
        else if (Pattern_8.Figure == 4)
        {
            Transform points0 = Pattern_8.PointList[0].transform;
            Transform points1 = Pattern_8.PointList[1].transform;
            Transform points2 = Pattern_8.PointList[2].transform;
            Transform points3 = Pattern_8.PointList[3].transform;
            points.Add(points0);
            points.Add(points1);
            points.Add(points2);
            points.Add(points3);            
        }
    }
    public void StartMetod()
    {
        if (Pattern_8.Figure == 2)
        {
            Mesh mesh = new Mesh();
            Vector3[] vertices = new Vector3[3];
            vertices[0] = new Vector3(points[0].transform.position.x, points[0].transform.position.y);
            vertices[1] = new Vector3(points[1].transform.position.x, points[1].transform.position.y);
            vertices[2] = new Vector3(points[2].transform.position.x, points[2].transform.position.y);
            mesh.vertices = vertices;
            mesh.triangles = new int[] { 0, 1, 2 };
            GetComponent<MeshFilter>().mesh = mesh;
        }
        else if (Pattern_8.Figure == 3)
        {
            Mesh mesh = new();
            Vector3[] vertices = new Vector3[3];
            vertices[0] = new Vector3(points[0].transform.position.x, points[0].transform.position.y);
            vertices[1] = new Vector3(points[1].transform.position.x, points[1].transform.position.y);
            vertices[2] = new Vector3(points[2].transform.position.x, points[2].transform.position.y);
            mesh.vertices = vertices;
            mesh.triangles = new int[] { 0, 1, 2 };
            GetComponent<MeshFilter>().mesh = mesh;
        }
        else if (Pattern_8.Figure == 4)
        {
            Mesh mesh = new();
            Vector3[] vertices = new Vector3[4];
            int[] triangles = new int[6];
            vertices[0] = new Vector3(points[0].transform.position.x, points[0].transform.position.y);
            vertices[1] = new Vector3(points[1].transform.position.x, points[1].transform.position.y);
            vertices[2] = new Vector3(points[2].transform.position.x, points[2].transform.position.y);
            vertices[3] = new Vector3(points[3].transform.position.x, points[3].transform.position.y);
            
            mesh.vertices = vertices;
            triangles[0] = 0;
            triangles[1] = 1;
            triangles[2] = 2;

            triangles[3] = 0;
            triangles[4] = 2;
            triangles[5] = 3;
            
            mesh.triangles = triangles;
            GetComponent<MeshFilter>().mesh = mesh;
        }

    }
    void Update()
    {
        if (Pattern_8.Figure == 2)
        {
            Mesh mesh = new();
            Vector3[] vertices = new Vector3[3];
            vertices[0] = new Vector3(points[0].transform.position.x, points[0].transform.position.y);
            vertices[1] = new Vector3(points[1].transform.position.x, points[1].transform.position.y);
            vertices[2] = new Vector3(points[2].transform.position.x, points[2].transform.position.y);
            mesh.vertices = vertices;
            mesh.triangles = new int[] { 0, 1, 2 };
            GetComponent<MeshFilter>().mesh = mesh;
        }
        else if (Pattern_8.Figure == 3)
        {
            Mesh mesh = new();
            Vector3[] vertices = new Vector3[3];
            vertices[0] = new Vector3(points[0].transform.position.x, points[0].transform.position.y);
            vertices[1] = new Vector3(points[1].transform.position.x, points[1].transform.position.y);
            vertices[2] = new Vector3(points[2].transform.position.x, points[2].transform.position.y);
            mesh.vertices = vertices;
            mesh.triangles = new int[] { 0, 1, 2 };
            GetComponent<MeshFilter>().mesh = mesh;
        }
        else if (Pattern_8.Figure == 4)
        {
            Mesh mesh = new();
            Vector3[] vertices = new Vector3[4];
            int[] triangles = new int[6];
            vertices[0] = new Vector3(points[0].transform.position.x, points[0].transform.position.y);
            vertices[1] = new Vector3(points[1].transform.position.x, points[1].transform.position.y);
            vertices[2] = new Vector3(points[2].transform.position.x, points[2].transform.position.y);
            vertices[3] = new Vector3(points[3].transform.position.x, points[3].transform.position.y);            
            mesh.vertices = vertices;
            triangles[0] = 0;
            triangles[1] = 1;
            triangles[2] = 2;

            triangles[3] = 0;
            triangles[4] = 2;
            triangles[5] = 3;           
            mesh.triangles = triangles;
            GetComponent<MeshFilter>().mesh = mesh;
        }
    }
}
