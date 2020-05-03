using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
[CustomEditor(typeof(Waypoint))]
[CanEditMultipleObjects]
public class WaypointEditor : Editor
{
    SerializedProperty wayPoints;
    SerializedProperty looping;
    [SerializeField] List<Vector3> points;
    [SerializeField] Waypoint waypoint;
    void OnEnable()
    {
        wayPoints = serializedObject.FindProperty("points");
        looping = serializedObject.FindProperty("looping");
        SceneView.duringSceneGui += OnScene;
        waypoint = target as Waypoint;
    }
    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnScene;
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(wayPoints);
        serializedObject.ApplyModifiedProperties();
        base.OnInspectorGUI();

    }
    void OnScene(SceneView sceneView)
    {
       
        points = waypoint.Points;
        Undo.RecordObject(waypoint, "points");
        for (int i = 0; i < points.Count; i++)
        {
            
            points[i] = Handles.PositionHandle(points[i], Quaternion.identity);
            if(i != points.Count - 1)
            {
                Handles.DrawLine(points[i], points[i + 1]);
            }
            else if (waypoint.Looping)
            {
                Handles.DrawLine(points[i], points[0]);
            }
        }
        waypoint.Points = points;
        
    }
    
}
