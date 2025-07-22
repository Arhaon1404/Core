using System;
using UnityEngine;

public class StepsCounter : MonoBehaviour
{
    [SerializeField] private int _stepsCount;

    public int StepsCount => _stepsCount;
    
    private void Awake()
    {
        _stepsCount = 0;
    }

    public void AddStep()
    {
        _stepsCount++;
    }
}
