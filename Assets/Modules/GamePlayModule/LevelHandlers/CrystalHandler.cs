using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalHandler
{
    private Vector3 _wayPoint;
    private Field _startField;
    private Field _endField;
    
    private bool _isDone;
    
    public event Action MoveСompleted;
    
    public void CollectCoordinates(Field startField,Field endField)
    {
        _isDone = false;
        
        Vector3 endFieldCenterPoint = endField.CenterPoint.transform.position;
        
        _wayPoint = endFieldCenterPoint;

        _startField = startField;
        _endField = endField;
        
        _startField.CrystalOnField.CrystalMover.TargetReached += MoveCrystal;
        
        MoveCrystal();
    }

    private void MoveCrystal()
    {
        Crystal crystal = _startField.CrystalOnField;

        if(_isDone == false)
            crystal.PauseAnimation();
        
        if (_isDone)
        {
            _startField.CrystalOnField.CrystalMover.TargetReached -= MoveCrystal;
            
            _startField.ReleaseCrystal(crystal);
            _endField.SetCrystal(crystal);
            
            crystal.transform.SetParent(_endField.transform);
            
            crystal.PlayAnimation();
            
            MoveСompleted?.Invoke();
        }
        else
        {
            crystal.CrystalMover.Move(_wayPoint);
            
            _isDone = true;
        }
    }
}
