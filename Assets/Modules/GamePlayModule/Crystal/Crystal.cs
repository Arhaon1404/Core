using System;
using UnityEngine;

[RequireComponent(typeof(CrystalMover))]

public class Crystal : MonoBehaviour
{
    [SerializeField] private CrystalAnimator _crystalAnimator;
    [SerializeField] private OutlineSwicher _outlineSwicher;
    [SerializeField] private ColorType _color; 
    private CrystalMover _crystalMover;
    private bool _isActiveCrystal;
    
    
    public CrystalMover CrystalMover => _crystalMover;
    public ColorType Color => _color;
    
    public bool IsActiveCrystal => _isActiveCrystal;
    
    private void Awake()
    {
        _isActiveCrystal = true;
        _crystalMover = GetComponent<CrystalMover>();
    }

    public void СonnectCoreToCrystal()
    {
        _isActiveCrystal = false;
    }

    public void PlayAnimation()
    {
        _crystalAnimator.TurnOnUpAndDownAnimation();
    }

    public void PauseAnimation()
    {
        _crystalAnimator.TurnOffUpAndDownAnimation();
    }

    public void TurnOnOutline()
    {
        _outlineSwicher.TurnOn();
    }

    public void TurnOffOutline()
    {
        _outlineSwicher.TurnOff();
    }
}
