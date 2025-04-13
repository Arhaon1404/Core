using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[System.Serializable]
public class NodeInfo
{
    [SerializeField] private string _cellName;
    
    [SerializeField] private Field _field;
    
    [SerializeField] private bool _isNotRight;
    [SerializeField] private bool _isNotLeft;
    [SerializeField] private bool _isNotUp;
    [SerializeField] private bool _isNotDown;

    [SerializeField] private List<Core> _listCores = new List<Core>();
    
    [SerializeField] private Crystal _crystalOnField;
    [SerializeField] private ColorType _colorField;
    
    private List<ConnectionType> _connectionsToHide;
    
    public string CellName => _cellName;
    public Field Field => _field;
    public List<ConnectionType> ConnectionsToHide => _connectionsToHide;
    public List<Core> ListCores => _listCores;
    public Crystal CrystalOnField => _crystalOnField;
    public ColorType ColorField => _colorField;
    public bool IsNotRight => _isNotRight;
    public bool IsNotLeft => _isNotLeft;
    public bool IsNotUp => _isNotUp;
    public bool IsNotDown => _isNotDown;

    public void FillListConnectionsToHide()
    {
        if (_isNotRight)
            _connectionsToHide.Add(ConnectionType.right);
        
        if(_isNotLeft)
            _connectionsToHide.Add(ConnectionType.left);
        
        if(_isNotUp)
            _connectionsToHide.Add(ConnectionType.up);
        
        if(_isNotDown)
            _connectionsToHide.Add(ConnectionType.down);
    }
}
