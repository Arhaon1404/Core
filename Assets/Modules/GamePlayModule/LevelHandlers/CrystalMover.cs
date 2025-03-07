using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMover 
{
    public void CollectCoordinates(Connection rightWayConnection,Field firstField,Field endField)
    {
        Vector3 startFieldConnection = rightWayConnection.transform.position;
        Vector3 endFieldConnection = rightWayConnection.ConnectionAnotherField.MotherField.transform.position;
        Vector3 endFieldCenterPoint = endField.CenterPoint.transform.position;
        
        Vector3[] wayPoints = {startFieldConnection,endFieldConnection,endFieldCenterPoint};
    }
    
    //private void MoveCrystal(Field endField)
}
