using System.Collections.Generic;

public class FieldSwitherHandler 
{
    public void  SwitchFieldConnections(RotateField startField)
    {
        List<Connection> currentActiveConnections = new List<Connection>();
        List<Connection> nextConnections = new List<Connection>();
        
        foreach (Connection activeConnection in startField.ActiveConnections)
        {
            if (activeConnection.ConnectionLine.isActiveAndEnabled)
            {
                currentActiveConnections.Add(activeConnection);
            }
        }

        if (currentActiveConnections.Count < startField.ActiveConnections.Count)
        {
            foreach (Connection disableConnection in currentActiveConnections)
            {
                disableConnection.ConnectionLine.TurnOff(disableConnection.ConnectionLine);

                disableConnection.ConnectionAnotherField.ConnectionLine.TurnOff(disableConnection.ConnectionAnotherField.ConnectionLine);
                
                int nextElementIndex = (startField.OrderAdjacentConnections.IndexOf(disableConnection) + 1) % startField.OrderAdjacentConnections.Count;
                
                nextConnections.Add(startField.OrderAdjacentConnections[nextElementIndex]);
            }

            foreach (Connection inclusionConnection in nextConnections)
            {
                inclusionConnection.ConnectionLine.TurnOn();
                
                inclusionConnection.ConnectionAnotherField.ConnectionLine.TurnOn();
            }
        }
    }
}
