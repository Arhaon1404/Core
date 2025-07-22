using System.Collections.Generic;
using UnityEngine;

public class AbstractField : MonoBehaviour
{
    [SerializeField] protected List<Connection> _activeConnections;
    [SerializeField] protected CenterPoint _centerPoint;
    
    public List<Connection> ActiveConnections => _activeConnections;
    public CenterPoint CenterPoint => _centerPoint;
}
