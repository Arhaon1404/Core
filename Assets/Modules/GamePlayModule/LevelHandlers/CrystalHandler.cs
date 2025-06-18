using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalHandler
{
    private Vector3[] _wayPoints = new Vector3[3];
    private Field _startField;
    private Field _endField;
    
    private int _wayPointCount;
    
    public event Action MoveСompleted;
    
    public void CollectCoordinates(Connection rightWayConnection,Field startField,Field endField)
    {
        _wayPointCount = 0;
        
        Vector3 startFieldConnection = rightWayConnection.CenterPoint.transform.position;
        Vector3 endFieldConnection = rightWayConnection.ConnectionAnotherField.CenterPoint.transform.position;
        Vector3 endFieldCenterPoint = endField.CenterPoint.transform.position;
        
        _wayPoints[0] = startFieldConnection;
        _wayPoints[1] = endFieldConnection;
        _wayPoints[2] = endFieldCenterPoint;

        _startField = startField;
        _endField = endField;
        
        _startField.CrystalOnField.CrystalMover.TargetReached += MoveCrystal;
        
        MoveCrystal();
    }

    private void MoveCrystal()
    {
        Crystal crystal = _startField.CrystalOnField;

        if(_wayPointCount == 0)
            crystal.PauseAnimation();
        
        if (_wayPointCount >= _wayPoints.Length)
        {
            _startField.CrystalOnField.CrystalMover.TargetReached -= MoveCrystal;
            
            _startField.ReleaseCrystal(crystal);
            _endField.SetCrystal(crystal);
            
            crystal.PlayAnimation();
            
            MoveСompleted?.Invoke();
        }
        else
        {
            crystal.CrystalMover.Move(_wayPoints[_wayPointCount]);
            
            _wayPointCount++;
        }
    }
}
