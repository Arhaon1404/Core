using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEditor.UIElements;
using UnityEngine;

[CustomEditor(typeof(LevelInfo))]
[CanEditMultipleObjects]
public class LevelInfoEditor : Editor
{
    SerializedProperty widthMap;
    SerializedProperty heightMap;
    SerializedProperty map;
    SerializedProperty mapElement;

    private LevelInfo _levelInfo;

    private bool _isRemoveConnections;
    private bool _isHideConnections;
    private bool _isColorConnections;

    public void OnEnable()
    {
        _levelInfo = (LevelInfo)target;
        widthMap = serializedObject.FindProperty("_width");
        heightMap = serializedObject.FindProperty("_height");
        map = serializedObject.FindProperty("_mapRows");
    }
    
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(widthMap);
        EditorGUILayout.PropertyField(heightMap);

        CreateArray();
        
        DrawMap();

        DrawElementInfo();

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawElementInfo()
    {
        if (mapElement == null)
        {
            GUILayout.Label("Map Element is not selected");
        }
        else
        {
            GUILayout.Label(mapElement.FindPropertyRelative("_cellName").stringValue);
            
            EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_field"));
            
            _isRemoveConnections = EditorGUILayout.BeginFoldoutHeaderGroup(_isRemoveConnections, "Connections To Remove");

            if (_isRemoveConnections)
            {
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_isRemoveRight"));
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_isRemoveLeft"));
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_isRemoveUp"));
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_isRemoveDown"));
            }
            
            EditorGUILayout.EndFoldoutHeaderGroup();

            if (mapElement.FindPropertyRelative("_field").objectReferenceValue is RotateField)
            {
                _isHideConnections = EditorGUILayout.BeginFoldoutHeaderGroup(_isHideConnections, "Connections To Hide");

                if (_isHideConnections)
                {
                    EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_isHideRight"));
                    EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_isHideLeft"));
                    EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_isHideUp"));
                    EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_isHideDown"));
                }
                
                EditorGUILayout.EndFoldoutHeaderGroup();
            }
            
            _isColorConnections = EditorGUILayout.BeginFoldoutHeaderGroup(_isColorConnections, "Colors Connections");

            if (_isColorConnections)
            {
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_rightConnectionLine"));
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_leftConnectionLine"));
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_upConnectionLine"));
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_downConnectionLine"));
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
            
            if (mapElement.FindPropertyRelative("_field").objectReferenceValue is StartField)
            {
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_listCores"));
            }
            else if (mapElement.FindPropertyRelative("_field").objectReferenceValue is Field)
            {
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_crystalOnField"));
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_mark"));
            }
        }
    }
    
    private void CreateArray()
    {
        if (GUILayout.Button("Clear Array"))
        {
            map.ClearArray();
            
            for (int i = 0; i < widthMap.intValue; i++)
            {
                map.InsertArrayElementAtIndex(i);
                
                SerializedProperty row = map.GetArrayElementAtIndex(i).FindPropertyRelative("_mapRow");
                
                row.ClearArray();
                
                for (int j = 0; j < heightMap.intValue; j++)
                {
                    row.InsertArrayElementAtIndex(j);
                    SerializedProperty cellName = row.GetArrayElementAtIndex(j).FindPropertyRelative("_cellName");

                    cellName.stringValue = (i + 1) + "." + (j + 1);
                }
            }
            
            if(serializedObject.hasModifiedProperties)
                serializedObject.ApplyModifiedProperties();
        }
    }

    private void DrawMap()
    {
        GUILayout.Label("Map:");
        
        for (int i = 0; i < widthMap.intValue; i++)
        {
            GUILayout.BeginHorizontal("box");
            
            for (int j = 0; j < heightMap.intValue; j++)
            {
                string format = (i + 1) + "." + (j + 1);
                
                int minWidth = 30;

                if (GUILayout.Button(format, GUILayout.Width(minWidth)))
                {
                    ButtonClicked(i,j);
                }
            } 
            GUILayout.EndHorizontal();
        }
    }

    private void ButtonClicked(int iIndex, int jIndex)
    {
        mapElement = map.GetArrayElementAtIndex(iIndex).FindPropertyRelative("_mapRow").GetArrayElementAtIndex(jIndex);
    }
}
