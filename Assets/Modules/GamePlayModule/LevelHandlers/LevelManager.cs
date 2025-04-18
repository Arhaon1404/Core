using System.Collections.Generic;
public class LevelManager 
{
    private readonly FieldsHandler _fieldsHandler;
    private readonly CrystalHandler _crystalHandler;
    private readonly FieldsFeaturesHandler _fieldsFeaturesHandler;
    private readonly CoreHandler _coreHandler;
    private readonly LevelCompletionHandler _levelCompletionHandler;
    private Connection _rightWayConnection;
    private Field _firstField;
    private Field _secondField;

    public CrystalHandler CrystalHandler => _crystalHandler;
    public CoreHandler CoreHandler => _coreHandler;
    public LevelCompletionHandler LevelCompletionHandler => _levelCompletionHandler;

    public LevelManager()
    {
        _fieldsHandler = new FieldsHandler();
        _crystalHandler = new CrystalHandler();
        _coreHandler = new CoreHandler();
        _fieldsFeaturesHandler = new FieldsFeaturesHandler();
        _levelCompletionHandler = new LevelCompletionHandler();
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

    public void ProcessCore(List<AbstractField> path)
    {
        _coreHandler.CollectCoordinates(path);
    }

    public void ProccessLevelCompletion(VictoryFieldStorage victoryFieldStorage)
    {
        _levelCompletionHandler.CheckVictoryConditions(victoryFieldStorage);
    }
}
    

