using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    
    public ParticleSystem ParticleSystem => _particleSystem;
}
