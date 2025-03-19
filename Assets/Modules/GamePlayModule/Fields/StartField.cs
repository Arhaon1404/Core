using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartField : AbstractField
{
    [SerializeField] private Core _coreOnField;
    
    public Core CoreOnField => _coreOnField;

    public void ReleaseCore()
    {
        _coreOnField = null;
    }
}
