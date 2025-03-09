using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private List<Connection> _connections;
    [SerializeField] private Crystal _crystalOnField;
    [SerializeField] private CenterPoint _centerPoint;
    
    public List<Connection> Connections => _connections;
    public Crystal CrystalOnField => _crystalOnField;
    public CenterPoint CenterPoint => _centerPoint;

    public void ReleaseCrystal(Crystal verifiableCrystal)
    {
        if(verifiableCrystal == _crystalOnField)
            _crystalOnField = null;
    }

    public void ReleaseConnection(Connection connection)
    {
        _connections.Remove(connection);
    }

    public void SetCrystal(Crystal crystal)
    {
        if(_crystalOnField != null)
            throw new System.Exception("Crystal already set");
        
        _crystalOnField = crystal;
    }
}
    

