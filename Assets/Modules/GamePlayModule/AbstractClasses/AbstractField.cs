using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractField : MonoBehaviour
{
    [SerializeField] protected List<Connection> _activeConnections;
    [SerializeField] protected CenterPoint _centerPoint;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _firstSelectColor;
    [SerializeField] private Color _secondSelectColor;
    
    
    public List<Connection> ActiveConnections => _activeConnections;
    public CenterPoint CenterPoint => _centerPoint;

    private void Awake()
    {
        _defaultColor = _meshRenderer.material.color;
    }

    public void ChangeColorFirstSelectField()
    {
        _meshRenderer.material.color = _firstSelectColor;
    }
    
    public void ChangeColorSecondSelectField()
    {
        _meshRenderer.material.color = _secondSelectColor;
    }

    public void ResetColorChanges()
    {
        _meshRenderer.material.color = _defaultColor;
    }
}
