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
    
    [SerializeField] private rowData[] _mapRows = new rowData[0];
    
    public rowData[] MapRows => _mapRows;
}
