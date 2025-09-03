using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    
    public ParticleSystem ParticleSystem => _particleSystem;
}
