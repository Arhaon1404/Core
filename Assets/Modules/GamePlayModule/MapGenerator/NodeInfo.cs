using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NodeInfo
{
    [SerializeField] private string _cellName;
    
    [SerializeField] private Field _field;
    
    [SerializeField] private bool _isRemoveRight;
    [SerializeField] private bool _isRemoveLeft;
    [SerializeField] private bool _isRemoveUp;
    [SerializeField] private bool _isRemoveDown;

    [SerializeField] private bool _isHideRight;
    [SerializeField] private bool _isHideLeft;
    [SerializeField] private bool _isHideUp;
    [SerializeField] private bool _isHideDown;

    [SerializeField] private ConnectionLine _rightConnectionLine;
    [SerializeField] private ConnectionLine _leftConnectionLine;
    [SerializeField] private ConnectionLine _upConnectionLine;
    [SerializeField] private ConnectionLine _downConnectionLine;
    
    [SerializeField] private List<Core> _listCores = new List<Core>();
    
    [SerializeField] private Crystal _crystalOnField;
    [SerializeField] private Mark _mark;
    
    private List<ConnectionType> _connectionsToHide;
    private List<ConnectionType> _connectionsToRemove;
    private Dictionary<ConnectionType,ConnectionLine> _colorsConnections = new Dictionary<ConnectionType, ConnectionLine>();
    
    public string CellName => _cellName;
    public Field Field => _field;
    public IReadOnlyList<ConnectionType> ConnectionsToHide => _connectionsToHide;
    public IReadOnlyList<ConnectionType> ConnectionsToRemove => _connectionsToRemove;
    public Dictionary<ConnectionType, ConnectionLine> ColorsConnections => _colorsConnections;
    public List<Core> ListCores => _listCores;
    public Crystal CrystalOnField => _crystalOnField;
    public Mark Mark => _mark;

    public NodeInfo()
    {
        _connectionsToHide = new List<ConnectionType>();
        _connectionsToRemove = new List<ConnectionType>();
    }

    public void FillListConnectionsToRemove()
    {
        _connectionsToRemove.Clear();
        
        if (_isRemoveRight)
            _connectionsToRemove.Add(ConnectionType.right);
        
        if(_isRemoveLeft)
            _connectionsToRemove.Add(ConnectionType.left);
        
        if(_isRemoveUp)
            _connectionsToRemove.Add(ConnectionType.up);
        
        if(_isRemoveDown)
            _connectionsToRemove.Add(ConnectionType.down);
    }

    public void ClearColorsConnectionsList()
    {
        _colorsConnections.Clear();
    }

    public void FillListConnectionsToHide()
    {
        _connectionsToHide.Clear();
        
        if (_isHideRight)
            _connectionsToHide.Add(ConnectionType.right);
        
        if(_isHideLeft)
            _connectionsToHide.Add(ConnectionType.left);
        
        if(_isHideUp)
            _connectionsToHide.Add(ConnectionType.up);
        
        if(_isHideDown)
            _connectionsToHide.Add(ConnectionType.down);
    }

    public void FillListColorConnections()
    {
        if (_rightConnectionLine)
            _colorsConnections.Add(ConnectionType.right,_rightConnectionLine);
        
        if(_leftConnectionLine)
            _colorsConnections.Add(ConnectionType.left,_leftConnectionLine);
        
        if(_upConnectionLine)
            _colorsConnections.Add(ConnectionType.up,_upConnectionLine);
        
        if (_downConnectionLine)
            _colorsConnections.Add(ConnectionType.down,_downConnectionLine);
        
    }
}
