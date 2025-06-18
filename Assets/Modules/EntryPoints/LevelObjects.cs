using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjects : MonoBehaviour
{
    [SerializeField] private MapGenerator _mapGenerator;

    public void StartMapGeneration()
    {
        _mapGenerator.ProcessGeneration();
    }
}
