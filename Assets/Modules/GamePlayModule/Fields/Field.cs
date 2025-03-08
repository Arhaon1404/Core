using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private Connection[] _connections;
    [SerializeField] private Crystal _crystalOnField;
    [SerializeField] private CenterPoint _centerPoint;
    
    public Connection[] Connections => _connections;
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
    

