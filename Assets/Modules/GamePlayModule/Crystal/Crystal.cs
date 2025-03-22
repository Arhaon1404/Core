using System;
using UnityEngine;

[RequireComponent(typeof(CrystalMover))]

public class Crystal : MonoBehaviour
{
    [SerializeField] private ColorType _color; 
    private CrystalMover _crystalMover;
    
    public CrystalMover CrystalMover => _crystalMover;
    public ColorType Color => _color;

    public void Awake()
    {
        _crystalMover = GetComponent<CrystalMover>();
    }
}
