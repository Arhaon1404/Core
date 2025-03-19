using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CoreHandler
{
    private List<Vector3> _wayPoints = new List<Vector3>();
    private StartField _coreStartField;
    private Core _core;
    
    private int _wayPointCount; 
    
    public event Action MoveСompleted;
    
    public void CollectCoordinates(List<AbstractField> path)
    {
        _wayPointCount = 0;
        
        _coreStartField = (StartField)path[0];
        
        _core = _coreStartField.CoreOnField;
        
        foreach (AbstractField field in path)
        {
            int nextField = path.IndexOf(field);

            nextField++;
            
            if (nextField < path.Count)
            {
                Connection rightConnection = FindRightWay(field,path[nextField]);
                
                _wayPoints.Add(rightConnection.CenterPoint.transform.position);
                _wayPoints.Add(rightConnection.ConnectionAnotherField.CenterPoint.transform.position);
                _wayPoints.Add(path[nextField].CenterPoint.transform.position);
            }
        }

        _core.CoreMover.TargetReached += MoveCore;

        MoveCore();
    }

    private void MoveCore()
    {
        if (_wayPointCount >= _wayPoints.Count)
        {
            _core.CoreMover.TargetReached -= MoveCore;
            
            _coreStartField.ReleaseCore();
            _coreStartField.enabled = false;
            
            MoveСompleted?.Invoke();
        }
        else
        {
            _core.CoreMover.Move(_wayPoints[_wayPointCount]);
            
            _wayPointCount++;
        }
    }
    
    
    private Connection FindRightWay(AbstractField startField,AbstractField endField)
    {
        foreach (Connection connection in startField.ActiveConnections)
        {
            if (connection.ConnectionAnotherField.MotherField == endField)
            {
                return connection;
            }
        }
        
        return null;
    }
}
