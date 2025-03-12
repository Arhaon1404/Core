using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FieldSwitherHandler 
{
    public void SwitchFieldConnections(RotateField startField)
    {
        int countActiveConnections = 0;

        foreach (Connection activeConnection in startField.ActiveConnections)
        {
            if (activeConnection.ConnectionLine.isActiveAndEnabled)
            {
                countActiveConnections++;
            }
        }
        
        
        
        for (int i = 0; i < countActiveConnections; i++)
        {
            ConnectionLine connectionLineAnotherField = startField.ActiveConnections[i].ConnectionAnotherField.ConnectionLine;
                
            startField.ActiveConnections[i].ConnectionAnotherField.ConnectionLine.TurnOff(connectionLineAnotherField);
                
            ConnectionLine startFieldConnectionLine = startField.ActiveConnections[i].ConnectionLine;
                
            startField.ActiveConnections[i].ConnectionLine.TurnOff(startFieldConnectionLine);
            
            int nextElement = (i + 1) % startField.ActiveConnections.Count;
            
            startField.ActiveConnections[nextElement].ConnectionLine.TurnOn();
            
            startField.ActiveConnections[nextElement].ConnectionAnotherField.ConnectionLine.TurnOn();

            Connection ActiveConnection = startField.ActiveConnections[i];
            
            startField.ActiveConnections.Remove(ActiveConnection);
            
            startField.ActiveConnections.Add(ActiveConnection);
        }
    }
}
