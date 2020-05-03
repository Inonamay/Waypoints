using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Create Waypoints", order = 1)]
public class Waypoint : ScriptableObject
{
    [SerializeField] List<Vector3> points = new List<Vector3>();
    public List<Vector3> Points
    {
        get
        {
            return points;
        }
        set
        {
            if(value.Count == 0)
            {
                Debug.LogWarning("Warning! Path contains no waypoints!");
            }
            points = value;
        }
    }
    [SerializeField] bool looping;
    public bool Looping
    {
        get
        {
            return looping;
        }
        set
        {
            looping = value;
        }
    }
}
