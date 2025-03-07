using UnityEngine;

public class Connection : MonoBehaviour
{
    [SerializeField] private Field _motherField;
    [SerializeField] private Connection _connectionAnotherField;  
    
    public Field MotherField => _motherField;
    public Connection ConnectionAnotherField => _connectionAnotherField;
}
