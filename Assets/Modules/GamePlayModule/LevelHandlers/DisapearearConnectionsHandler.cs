using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearearConnectionsHandler
{
    public void DisapearConnection(Connection rightWayConnection,Field startField, Field endField)
    {
        ConnectionLine endFieldConnectionLine = rightWayConnection.ConnectionAnotherField.ConnectionLine;
        
        rightWayConnection.ConnectionAnotherField.ConnectionLine.TurnOff(endFieldConnectionLine);
        
        ConnectionLine startFieldConnectionLine = rightWayConnection.ConnectionLine;
        
        rightWayConnection.ConnectionLine.TurnOff(startFieldConnectionLine);
    }
}
