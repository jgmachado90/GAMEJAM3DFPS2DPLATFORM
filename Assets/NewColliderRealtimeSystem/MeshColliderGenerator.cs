using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshColliderGenerator : MonoBehaviour
{
    public static MeshColliderGenerator instance;

    //A standard cube mesh
    public Mesh mesh;
    //The red cube
    public Transform cubeParent;
    public GameObject wall;
    //Cube vertex list
    public List<Vector3> points;
    //Cube vertex projection list
    public List<Vector3> pointsOnWall = new List<Vector3>();


    IList<Point> pointsHulled;

    //A cube prefab for testOnly
    public GameObject cube;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        FindObjectVertexPositions();
        RayCastToWall();
        List<Point> WallPoints = ConvertToPoint(pointsOnWall);
        pointsHulled = Hull.MakeHull(WallPoints);
        ShowHulledPoints(pointsHulled);
        CreateCollider();
    }

    private void FixedUpdate()
    {
      
    }

    public void UpdateMeshCollider()
    {
        Debug.Log("Updating mesh collider");
        points.Clear();
        pointsOnWall.Clear();
        Destroy(wall.GetComponent<MeshCollider>());
        FindObjectVertexPositions();
        RayCastToWall();
        List<Point> WallPoints = ConvertToPoint(pointsOnWall);
        pointsHulled = Hull.MakeHull(WallPoints);
        ShowHulledPoints(pointsHulled);
        CreateCollider();
    }

    private void ShowHulledPoints(IList<Point> points)
    {
        foreach(Point p in points)
        {
            //Instantiate(cube, new Vector3((float)p.x, (float)p.y, wall.transform.position.z), Quaternion.identity, wall.transform);
        }
    }

    private List<Point> ConvertToPoint(List<Vector3> pointsOnWall)
    {
        List<Point> newPoints = new List<Point>();

        foreach(Vector3 point in pointsOnWall)
        {
            Point newPoint = new Point(point.x, point.y);
            newPoints.Add(newPoint);
        }

        return newPoints;
    }

    private void FindObjectVertexPositions()
    {
        foreach (Vector3 vertex in mesh.vertices)
        {
            Vector3 worldPt = cubeParent.TransformPoint(vertex);

            if (!points.Contains(worldPt))
            {
                points.Add(worldPt);
               // Instantiate(cube, worldPt, Quaternion.identity, cubeParent);
            }
        }
    }

    private void RayCastToWall()
    {
        foreach (Vector3 point in points)
        {
            Vector3 direction = (point - transform.position).normalized;  
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity, 1 << 9))
            {
                //pointsOnWall.Add(wall.transform.InverseTransformPoint(hit.point));
                pointsOnWall.Add(hit.point);
                //Instantiate(cube, hit.point, Quaternion.identity, null);
            }
            else
                print("Raycast não colidiu com nada");       
        }
    }

    private void CreateCollider()
    {
        List<Vector3> pointsToCollider = new List<Vector3>();
        foreach(Point p in pointsHulled)
        {
            Vector3 newPoint = wall.transform.InverseTransformPoint(new Vector3((float)p.x, (float)p.y, wall.transform.position.z-0.8f));
            pointsToCollider.Add(newPoint);
            Vector3 newPointWithZ = wall.transform.InverseTransformPoint(new Vector3((float)p.x + 0.01f, (float)p.y + 0.01f, wall.transform.position.z + 0.8f));
            pointsToCollider.Add(newPointWithZ);
        }
       

        Triangulator tr = new Triangulator(pointsToCollider.ToArray());
        int[] indices = tr.Triangulate();

        // Create the mesh
        Mesh mesh = new Mesh();
        mesh.SetVertices(pointsToCollider);
        mesh.triangles = indices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        MeshCollider wallMeshCollider = wall.AddComponent<MeshCollider>();
        wallMeshCollider.sharedMesh = mesh;
        wallMeshCollider.convex = true;
    }

    
 
}
