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

    private bool _isActiveConnections;

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
            
            _isActiveConnections = EditorGUILayout.BeginFoldoutHeaderGroup(_isActiveConnections, "Connections");

            if (_isActiveConnections)
            {
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_isNotRight"));
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_isNotLeft"));
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_isNotUp"));
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_isNotDown"));
            }
            
            EditorGUILayout.EndFoldoutHeaderGroup();
            
            if (mapElement.FindPropertyRelative("_field").objectReferenceValue is StartField)
            {
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_listCores"));
            }
            else if (mapElement.FindPropertyRelative("_field").objectReferenceValue is Field)
            {
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_crystalOnField"));
                EditorGUILayout.PropertyField(mapElement.FindPropertyRelative("_colorField"));
            }
        }
    }
    
    private void CreateArray()
    {
        if (GUILayout.Button("CreateArray"))
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
