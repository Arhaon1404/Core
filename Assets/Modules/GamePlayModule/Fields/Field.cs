using System;
using System.Collections.Generic;
using UnityEngine;

public class Field : AbstractField
{
    [SerializeField] private Crystal _crystalOnField;
    [SerializeField] private ColorType _color;
    [SerializeField] private AreaParticleSystem _areaParticleSystem;
    [SerializeField] private MeshRenderer _meshRenderer;
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
        _meshRenderer.material.color = _firstSelectColor;
        ActivateAreaEffect();
    }
    
    public void ChangeColorSecondSelectField()
    {
        _meshRenderer.material.color = _secondSelectColor;
    }

    public void ResetColorChanges()
    {
        _meshRenderer.material.color = _defaultColor;
        DeactivateAreaEffect();
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
    

