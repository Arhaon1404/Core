using System;
using UnityEngine;

[RequireComponent(typeof(CrystalMover))]

public class Crystal : MonoBehaviour
{
    [SerializeField] private ColorType _color; 
    private CrystalMover _crystalMover;
    [SerializeField]private bool _isActiveCrystal;
    
    public CrystalMover CrystalMover => _crystalMover;
    public ColorType Color => _color;
    
    public bool IsActiveCrystal => _isActiveCrystal;

    public void Awake()
    {
        _isActiveCrystal = true;
        _crystalMover = GetComponent<CrystalMover>();
    }

    public void СonnectCoreToCrystal()
    {
        _isActiveCrystal = false;
    }
}
