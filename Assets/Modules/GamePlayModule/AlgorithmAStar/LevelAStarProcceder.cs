using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAStarProcceder : MonoBehaviour
{
    [SerializeField] private List<Crystal> _crystalsOnLevel;
    [SerializeField] private StartField _startField;
    
    private AlgorithmAStar _algorithmAStar;
    private PreliminaryCrystalSearcher _preliminaryCrystalSearcher;
    
    public List<Crystal> CrystalsOnLevel => _crystalsOnLevel;
    public StartField StartField => _startField;

    public void Awake()
    {
        _algorithmAStar = new AlgorithmAStar();
        _preliminaryCrystalSearcher = new PreliminaryCrystalSearcher();
    }

    public bool SearchCrystals()
    {
        Field targetField = _preliminaryCrystalSearcher.Search(_startField);
        
        if (targetField)
        {
            LaunchAStar(targetField);
            return true;
        }
        
        return false;
    }
    
    private void LaunchAStar(Field targetField)
    {
        List<AbstractField> list = _algorithmAStar.Launch(_startField, targetField);

        Debug.Log("---------------------------");
        
        foreach (var field in list)
        {
            Debug.Log(field);
        }
    }
}
