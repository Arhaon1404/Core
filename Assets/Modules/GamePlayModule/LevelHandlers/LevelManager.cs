
public class LevelManager 
{
    private readonly FieldsHandler _fieldsHandler;
    private readonly CrystalHandler _crystalHandler;
    private readonly FieldsFeaturesHandler _fieldsFeaturesHandler;
    private Connection _rightWayConnection;
    private Field _firstField;
    private Field _secondField;

    public CrystalHandler CrystalHandler => _crystalHandler;

    public LevelManager()
    {
        _fieldsHandler = new FieldsHandler();
        _crystalHandler = new CrystalHandler();
        _fieldsFeaturesHandler = new FieldsFeaturesHandler();
    }

    public void ReceiveFields(Field firstField, Field secondField)
    {
        _firstField = firstField;
        _secondField = secondField;
    }

    public bool ProcessFields()
    {
         _rightWayConnection = _fieldsHandler.Process(_firstField,_secondField);
         
         return _rightWayConnection != null;
    }

    public void ProcessCrystal()
    {
        _crystalHandler.CollectCoordinates(_rightWayConnection,_firstField,_secondField);
    }

    public void ProcessFieldsFeatures()
    {
        _fieldsFeaturesHandler.ProcessFieldsFeatures(_rightWayConnection,_firstField, _secondField);
    }
}
    

