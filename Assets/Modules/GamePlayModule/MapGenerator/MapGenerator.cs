using System;
using UnityEngine;

[RequireComponent(typeof(FieldsPlacer))]
[RequireComponent(typeof(RealizerOtherFeatures))]
[RequireComponent(typeof(LevelAStarProcceder))]
[RequireComponent(typeof(VictoryFieldStorage))]
public class MapGenerator : MonoBehaviour
{
    [SerializeField] private CenterPoint _centerPoint;
    
    private LevelInfo _levelInfo;
    private FieldsPlacer _fieldsPlacer;
    private ConnectLinker _connectLinker;
    private RealizerOtherFeatures _realizerOtherFeatures;
    private LevelAStarProcceder _levelAStarProcceder;
    private VictoryFieldStorage _victoryFieldStorage;

    private float _marginSpacing;
    private NodeInfo[,] _map;
    private Field[,] _filledMap;

    private StartField _startField;
    
    public StartField StartField => _startField;
    
    private void Awake()
    {
        _marginSpacing = 3.95f;
        _fieldsPlacer = GetComponent<FieldsPlacer>();
        _connectLinker = new ConnectLinker();
        _realizerOtherFeatures = GetComponent<RealizerOtherFeatures>();
        _levelAStarProcceder = GetComponent<LevelAStarProcceder>();
        _victoryFieldStorage = GetComponent<VictoryFieldStorage>();
    }

    public void SetLevelInfo(LevelInfo levelInfo)
    {
        if (levelInfo == null)
        {
            throw new ArgumentNullException(nameof(levelInfo));
        }

        _levelInfo = levelInfo;
    }

    public void ProcessGeneration()
    {
        ValidationArray();
        FillArray();
        _filledMap = _fieldsPlacer.PlaceField(_map,_marginSpacing);
        _connectLinker.ConnectConnections(_filledMap,_map);
        _realizerOtherFeatures.Realize(_filledMap,_map);
        GenerateEnd();
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
                _map[i, j].FillListConnectionsToRemove();
                _map[i, j].FillListConnectionsToHide();
                _map[i, j].FillListColorConnections();
            }
        }
    }

    private void GenerateEnd()
    {
        for (int i = 0; i < _filledMap.GetLength(0); i++)
        {
            for (int j = 0; j < _filledMap.GetLength(1); j++)
            {
                if (_filledMap[i, j] is StartField)
                {
                    _victoryFieldStorage.SetNewStartField((StartField)_filledMap[i, j]);
                    _levelAStarProcceder.SetNewStartField((StartField)_filledMap[i, j]);
                    _startField = (StartField)_filledMap[i, j];
                }

                if (_map[i, j].Mark != null)
                {
                    _victoryFieldStorage.SpecialFields.Add(_filledMap[i, j]);
                }
            }
        }
    }
}
