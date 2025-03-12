using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private List<Connection> _activeConnections;
    [SerializeField] private Crystal _crystalOnField;
    [SerializeField] private CenterPoint _centerPoint;
    
    public List<Connection> ActiveConnections => _activeConnections;
    public Crystal CrystalOnField => _crystalOnField;
    public CenterPoint CenterPoint => _centerPoint;

    public void ReleaseCrystal(Crystal verifiableCrystal)
    {
        if(verifiableCrystal == _crystalOnField)
            _crystalOnField = null;
    }

    public void SetCrystal(Crystal crystal)
    {
        if(_crystalOnField != null)
            throw new System.Exception("Crystal already set");
        
        _crystalOnField = crystal;
    }
}
    

