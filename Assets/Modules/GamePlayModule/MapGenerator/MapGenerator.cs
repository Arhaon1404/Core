using System;
using UnityEngine;

[RequireComponent(typeof(FieldsPlacer))]
public class MapGenerator : MonoBehaviour
{
    [SerializeField] private LevelInfo _levelInfo;
    [SerializeField] private CenterPoint _centerPoint;
    
    private FieldsPlacer _fieldsPlacer;

    private float _marginSpacing;
    private NodeInfo[,] _map;
    
    private void Awake()
    {
        _marginSpacing = 4.066f;
        _fieldsPlacer = GetComponent<FieldsPlacer>();
        ProcessGeneration();
    }

    private void ProcessGeneration()
    {
        ValidationArray();
        FillArray();
        _fieldsPlacer.PlaceField(_map,_marginSpacing);
    }

    private void ValidationArray()
    {
        if (_levelInfo.MapRows != null)
        {
            foreach (var rowData in _levelInfo.MapRows)
            {
                if (rowData.MapRow != null)
                {
                    _map = new NodeInfo[_levelInfo.MapRows.Length,rowData.MapRow.Length];
                    break;
                }
                else
                {
                    throw new ArgumentNullException(nameof(rowData.MapRow));
                }
            }
        }
        else
        {
            throw new ArgumentNullException(nameof(_levelInfo.MapRows));
        }
    }

    private void FillArray()
    {
        for (int i = 0; i < _map.GetLength(0); i++)
        {
            for (int j = 0; j < _map.GetLength(1); j++)
            {
                _map[i, j] = _levelInfo.MapRows[i].MapRow[j]; 
            }
        }
    }
}
