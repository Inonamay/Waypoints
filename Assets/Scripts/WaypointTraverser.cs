using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointTraverser : MonoBehaviour
{
    [SerializeField] Waypoint path = null;
    [SerializeField] float speed = 0.1f;
    [SerializeField] public bool traverse = true;
    int point;
    float distanceAlong = 0;
    private void Update()
    {
        if (traverse)
        {
            if(point < path.Points.Count)
            {
                distanceAlong += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(transform.position, path.Points[point], distanceAlong);
                if(Vector3.Distance(transform.position, path.Points[point]) < 0.7f)
                {
                    point++;
                    distanceAlong = 0;
                }
            }
            else if (path.Looping)
            {
                point = 0;
            }
        }
    }
    [ExecuteAlways]
    public void Traverse()
    {
        traverse = true;
        point = 0;
        distanceAlong = 0;
        transform.position = path.Points[point];
    }
    private void Start()
    {
        traverse = true;
       // StartCoroutine("TraverseWaypoints");
    }

    public IEnumerator TraverseWaypoints()
    {
        for (int i = 0; i < path.Points.Count; i++)
        {
            while(Vector3.Distance(transform.position, path.Points[i]) > 0.1f)
            {
               
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
