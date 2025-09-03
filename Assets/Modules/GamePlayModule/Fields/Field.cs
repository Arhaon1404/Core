using System;
using System.Collections.Generic;
using UnityEngine;

public class Field : AbstractField
{
    [SerializeField] private Crystal _crystalOnField;
    [SerializeField] private Platform _platform;
    [SerializeField] private ColorType _color;
    [SerializeField] private AreaParticleSystem _areaParticleSystem;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _firstSelectColor;
    [SerializeField] private Color _secondSelectColor;
    [SerializeField] private FreeFieldChecker _freeFieldChecker;
    private List<Field> _freeFields;
    private FieldNode _fieldNode;
    
    public Crystal CrystalOnField => _crystalOnField;
    public FieldNode FieldNode => _fieldNode;
    public AreaParticleSystem AreaParticleSystem => _areaParticleSystem;
    public ColorType Color => _color;
    public Platform Platform => _platform;
    
    public FreeFieldChecker FreeFieldChecker => _freeFieldChecker;

    private void Awake()
    {
        _fieldNode = gameObject.AddComponent<FieldNode>();
        _freeFields = new List<Field>();
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

    public void SetColor(ColorType color)
    {
        if (_color != ColorType.Black)
        {
            _color = color;
        }
    }
    
    public void ChangeColorFirstSelectField()
    {
        _platform.ChangeColor(_firstSelectColor, true);
        
        ActivateAreaEffect();
    }
    
    public void ChangeColorSecondSelectField()
    {
        _platform.ChangeColor(_secondSelectColor, true);
    }

    public void ResetColorChanges()
    {
        _platform.ChangeColor(_defaultColor,false);
        
        DeactivateAreaEffect();
    }

    public void ActivateBacklight()
    {
        _platform.ActivateBacklight();
    }

    public void DeactivateBacklight()
    {
        _platform.DeactivateBacklight();
    }

    public void DeactivateAllEffects()
    {
        _areaParticleSystem.Deactivate();
    }

    private void ActivateAreaEffect()
    {
        _freeFields = _freeFieldChecker.GetListFreeField(this);
        
        foreach (Field field in _freeFields)
        {
            field.AreaParticleSystem.Activate();
        }
    }

    private void DeactivateAreaEffect()
    {
        foreach (Field field in _freeFields)
        {
            field.AreaParticleSystem.Deactivate();
        }
        
        _freeFields.Clear();    
    }
}
    

