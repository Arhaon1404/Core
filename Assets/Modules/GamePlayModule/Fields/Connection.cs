using UnityEngine;

public class Connection : MonoBehaviour
{
    [SerializeField] private Field _motherField;
    [SerializeField] private Connection _connectionAnotherField; 
    [SerializeField] private CenterPoint _centerPoint;
    [SerializeField] private ConnectionLine _connectionLine;
    
    public Field MotherField => _motherField;
    public Connection ConnectionAnotherField => _connectionAnotherField;
    public CenterPoint CenterPoint => _centerPoint;
    public ConnectionLine ConnectionLine => _connectionLine;
}
