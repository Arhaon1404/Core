using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    [SerializeField] private CoreMover _coreMover;
    
    public CoreMover CoreMover => _coreMover;
}
