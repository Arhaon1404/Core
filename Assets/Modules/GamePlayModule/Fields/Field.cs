using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private Connection[] _connections;
    [SerializeField] private Crystal _crystalOnField;
    [SerializeField] private CenterPoint _centerPoint;
    
    public Connection[] Connections => _connections;
    public Crystal CrystalOnField => _crystalOnField;
    public CenterPoint CenterPoint => _centerPoint;
}
    

