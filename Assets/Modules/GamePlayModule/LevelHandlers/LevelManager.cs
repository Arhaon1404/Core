using UnityEngine;

public class LevelManager 
{
    private readonly FieldsHandler _fieldsHandler;
    private readonly CrystalMover _crystalMover;
    private Connection _rightWayConnection;
    private Field _firstField;
    private Field _secondField;

    public LevelManager()
    {
        _fieldsHandler = new FieldsHandler();
        _crystalMover = new CrystalMover();
    }

    public void ReceiveFields(Field firstField, Field secondField)
    {
        _firstField = firstField;
        _secondField = secondField;
        Debug.Log("LevelManager received fields: ");
        Debug.Log(_firstField);
        Debug.Log(_secondField);
    }

    public bool ProcessFields()
    {
         _rightWayConnection = _fieldsHandler.Process(_firstField,_secondField);
         
         return _rightWayConnection != null;
    }

    public void ProcessCrystal()
    {
        _crystalMover.CollectCoordinates(_rightWayConnection,_firstField,_secondField);
    }
}
    

