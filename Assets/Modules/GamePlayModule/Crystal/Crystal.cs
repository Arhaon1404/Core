using UnityEngine;

[RequireComponent(typeof(CrystalMover))]

public class Crystal : MonoBehaviour
{
    [SerializeField] private CrystalMover _crystalMover;
    
    public CrystalMover CrystalMover => _crystalMover;
}
