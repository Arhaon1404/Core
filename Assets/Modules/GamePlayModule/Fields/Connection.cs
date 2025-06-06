using System;
using UnityEngine;

public class Connection : MonoBehaviour
{
    [SerializeField] private ConnectionType _connectionType;
    [SerializeField] private Field _motherField;
    [SerializeField] private Connection _connectionAnotherField; 
    [SerializeField] private CenterPoint _centerPoint;
    [SerializeField] private ConnectionLine _connectionLine;
    [SerializeField] private CenterPoint _connectionLineCenterPoint;
    
    public Field MotherField => _motherField;
    public Connection ConnectionAnotherField => _connectionAnotherField;
    public CenterPoint CenterPoint => _centerPoint;
    public ConnectionLine ConnectionLine => _connectionLine;
    public ConnectionType ConnectionType => _connectionType;
    public CenterPoint ConnectionLineCenterPoint => _connectionLineCenterPoint;

    public void SetConnectionAnotherField(Connection newConnection)
    {
        if (newConnection == null)
        {
            throw new NullReferenceException(nameof(newConnection));
        }
        
        _connectionAnotherField = newConnection;
    }

    public void SetNewConnectionLine(ConnectionLine newConnection)
    {
        _connectionLine = newConnection;
    }
}
