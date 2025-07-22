using System.Collections.Generic;
using UnityEngine;

public class RotateField : Field
{
    [SerializeField] private List<Connection> _orderAdjacentConnections;

    [SerializeField] private RotatePointersBlinker _rotatePointersBlinker;

    public List<Connection> OrderAdjacentConnections => _orderAdjacentConnections;
    
    public void PlayBlinker()
    {
        _rotatePointersBlinker.Play();
    }

    public void StopBlinker()
    {
        _rotatePointersBlinker.Stop();
    }
}
