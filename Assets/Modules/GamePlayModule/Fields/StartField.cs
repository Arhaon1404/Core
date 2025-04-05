using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartField : AbstractField
{
    [SerializeField] private List<Core> _listCores ;
    [SerializeField] private Core _coreOnField;
    
    public Core CoreOnField => _coreOnField;
    public List<Core> listCores => _listCores;

    public void ReleaseCore(Core coreToRelease)
    {
        _listCores?.Remove(coreToRelease);
        _coreOnField = null;
        
        SetNextCore();
    }

    private void SetNextCore()
    {
        if (_listCores.Count != 0)
        {
            _coreOnField = _listCores[0];
            _coreOnField.gameObject.SetActive(true);
        }
    }
}
