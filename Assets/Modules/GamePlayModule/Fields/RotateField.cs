using System.Collections.Generic;
using UnityEngine;

public class RotateField : Field
{
    [SerializeField] private List<Connection> _orderAdjacentConnections;
    
    public List<Connection> OrderAdjacentConnections => _orderAdjacentConnections;
}
