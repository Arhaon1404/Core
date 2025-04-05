using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAStarProcceder : MonoBehaviour
{
    [SerializeField] private List<Crystal> _crystalsOnLevel;
    [SerializeField] private StartField _startField;
    
    private List<AbstractField> _path;
    
    private AlgorithmAStar _algorithmAStar;
    private PreliminaryCrystalSearcher _preliminaryCrystalSearcher;
    
    public List<Crystal> CrystalsOnLevel => _crystalsOnLevel;
    public StartField StartField => _startField;

    public void Awake()
    {
        _path = new List<AbstractField>();
        _algorithmAStar = new AlgorithmAStar();
        _preliminaryCrystalSearcher = new PreliminaryCrystalSearcher();
    }

    public Field SearchCrystals()
    {
        Field targetField = _preliminaryCrystalSearcher.Search(_startField);
        
        if (targetField)
            return targetField;
        
        return null;
    }
    
    public List<AbstractField> LaunchAStar(Field targetField)
    {
        _path = _algorithmAStar.Launch(_startField, targetField);
        
        _path.Reverse();
        
        return _path;
    }
}
