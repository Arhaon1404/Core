using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MapGenerator/Level")]

public class LevelInfo : ScriptableObject
{
    [System.Serializable]
    public struct rowData
    {
        [SerializeField] private NodeInfo[] _mapRow;
        public NodeInfo[] MapRow => _mapRow;
    }
    
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private int _maxLevelPoints;
    [SerializeField] private int _deductedMovePoints;
    [SerializeField] private int _maxDeductedMovePoints;
    [SerializeField] private int _pointsDeductedTenSeconds;
    [SerializeField] private int _maxPointsDeductedTenSeconds;
    
    [SerializeField] private rowData[] _mapRows = new rowData[0];
    
    public rowData[] MapRows => _mapRows;
    
    public int maxLevelPoints => _maxLevelPoints;
    public int deductedMovePoints => _deductedMovePoints;
    public int maxDeductedMovePoints => _maxDeductedMovePoints;
    public int pointsDeductedTenSeconds => _pointsDeductedTenSeconds;
    public int maxPointsDeductedTenSeconds => _maxPointsDeductedTenSeconds;
}
