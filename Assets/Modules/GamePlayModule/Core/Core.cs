using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CoreMover))]

public class Core : MonoBehaviour
{
    [SerializeField] private ColorType _color;
    [SerializeField] private OutlineSwicher _outlineSwicher;
    private CoreMover _coreMover;
    
    public CoreMover CoreMover => _coreMover;
    public ColorType Color => _color;
    
    public void Awake()
    {
        _coreMover = GetComponent<CoreMover>();
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
