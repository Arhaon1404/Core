using UnityEngine;

public class FieldsFeaturesHandler
{
    private readonly DisapearearConnectionsHandler _disapearearConnectionsHandler;
    private readonly FieldSwitherHandler _fieldSwitherHandler;

    public FieldsFeaturesHandler()
    {
        _disapearearConnectionsHandler = new DisapearearConnectionsHandler();
        _fieldSwitherHandler = new FieldSwitherHandler();
    }

    public void ProcessFieldsFeatures(Connection rightWayConnection,Field startField, Field endField)
    {
        if (startField is DisappearingField)
        {
            _disapearearConnectionsHandler.DisapearConnection(rightWayConnection, startField, endField);
        }

        if (startField is RotateField)
        {
            _fieldSwitherHandler.SwitchFieldConnections((RotateField)startField);
        }
    }
}
