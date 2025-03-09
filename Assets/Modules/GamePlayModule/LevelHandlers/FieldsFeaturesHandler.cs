using UnityEngine;

public class FieldsFeaturesHandler
{
    public void ProcessFieldsFeatures(Connection rightWayConnection,Field startField, Field endField)
    {
        if (startField is DisappearingField)
        {
            DisapearConnection(rightWayConnection, startField, endField);
        }
    }

    private void DisapearConnection(Connection rightWayConnection,Field startField, Field endField)
    {
        ConnectionLine endFieldConnectionLine = rightWayConnection.ConnectionAnotherField.ConnectionLine;
        
        rightWayConnection.ConnectionAnotherField.ConnectionLine.TurnOff(endFieldConnectionLine);
        
        ConnectionLine startFieldConnectionLine = rightWayConnection.ConnectionLine;
        
        rightWayConnection.ConnectionLine.TurnOff(startFieldConnectionLine);
        
        endField.ReleaseConnection(rightWayConnection.ConnectionAnotherField);
        startField.ReleaseConnection(rightWayConnection);
    }
}
