using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CoreMover))]

public class Core : MonoBehaviour
{
    [SerializeField] private ColorType _color;
    private CoreMover _coreMover;
    
    public CoreMover CoreMover => _coreMover;
    public ColorType Color => _color;
    
    public void Awake()
    {
        _coreMover = GetComponent<CoreMover>();
    }
}
