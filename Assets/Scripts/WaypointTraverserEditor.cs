using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(WaypointTraverser))]
public class WaypointTraverserEditor : Editor
{
    SerializedProperty path;
    SerializedProperty speed;
    private void OnEnable()
    {
        path = serializedObject.FindProperty("path");
        speed = serializedObject.FindProperty("speed");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(path);
        EditorGUILayout.PropertyField(speed);
        serializedObject.ApplyModifiedProperties();
        if (GUILayout.Button("Traverse"))
        {
            WaypointTraverser traverser = target as WaypointTraverser;
            traverser.Traverse();
        }
    }
}
