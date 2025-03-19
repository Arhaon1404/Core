using System;
using System.Collections.Generic;
using UnityEngine;

public class Field : AbstractField
{
    [SerializeField] private Crystal _crystalOnField;
    private FieldNode _fieldNode;
    
    public Crystal CrystalOnField => _crystalOnField;
    public FieldNode FieldNode => _fieldNode;

    private void Awake()
    {
        _fieldNode = gameObject.AddComponent<FieldNode>();
    }

    public void ReleaseCrystal(Crystal verifiableCrystal)
    {
        if(verifiableCrystal == _crystalOnField)
            _crystalOnField = null;
    }

    public void SetCrystal(Crystal crystal)
    {
        if(_crystalOnField != null)
            throw new System.Exception("Crystal already set");
        
        _crystalOnField = crystal;
    }
}
    

