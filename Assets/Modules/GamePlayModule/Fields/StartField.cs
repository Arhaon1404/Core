using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartField : Field
{
    [SerializeField] private List<Core> _listCores;
    [SerializeField] private Core _coreOnField;

    public event Action IsCoreMoved;
    
    public Core CoreOnField => _coreOnField;
    public List<Core> ListCores => _listCores;

    public void ReleaseCore(Core coreToRelease)
    {
        _listCores?.Remove(coreToRelease);
        _coreOnField = null;
        
        SetNextCore();
    }

    public void SetStartCore(Core coreToSet)
    {
        if(_coreOnField == null)
            _coreOnField = coreToSet;
    }

    private void SetNextCore()
    {
        IsCoreMoved?.Invoke();
        
        if (_listCores.Count != 0)
        {
            _coreOnField = _listCores[0];
            _coreOnField.gameObject.SetActive(true);
        }
    }
}
