using System;
using UnityEngine;

[RequireComponent(typeof(FieldsPlacer))]
[RequireComponent(typeof(RealizerOtherFeatures))]
public class MapGenerator : MonoBehaviour
{
    [SerializeField] private LevelInfo _levelInfo;
    [SerializeField] private CenterPoint _centerPoint;
    
    private FieldsPlacer _fieldsPlacer;
    private ConnectLinker _connectLinker;
    private RealizerOtherFeatures _realizerOtherFeatures;

    private float _marginSpacing;
    private NodeInfo[,] _map;
    private Field[,] _filledMap;
    
    private void Awake()
    {
        _marginSpacing = 4.066f;
        _fieldsPlacer = GetComponent<FieldsPlacer>();
        _connectLinker = new ConnectLinker();
        _realizerOtherFeatures = GetComponent<RealizerOtherFeatures>();
        ProcessGeneration();
    }

    private void ProcessGeneration()
    {
        ValidationArray();
        FillArray();
        _filledMap = _fieldsPlacer.PlaceField(_map,_marginSpacing);
        _connectLinker.ConnectConnections(_filledMap,_map);
        _realizerOtherFeatures.Realize(_filledMap,_map);
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
                _map[i, j].FillListConnectionsToHide();
            }
        }
    }
}
