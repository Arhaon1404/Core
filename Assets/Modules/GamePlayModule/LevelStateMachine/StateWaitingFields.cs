using System;
using UnityEngine;

public class StateWaitingFields : ILevelState
{
    private readonly LevelStateMachine _levelStateMachine;
    private readonly СlickHandler _сlickHandler;
    private readonly LevelManager _levelManager;
    
    public StateWaitingFields(LevelStateMachine levelStateMachine,LevelManager levelManager, СlickHandler сlickHandler)
    {
        if(levelStateMachine == null)
            throw new ArgumentNullException(nameof(levelStateMachine));
        
        if(levelManager == null)
            throw new ArgumentNullException(nameof(levelManager));
        
        if(сlickHandler == null)
            throw new ArgumentNullException(nameof(сlickHandler));
        
        _levelManager = levelManager;
        _levelStateMachine = levelStateMachine;
        _сlickHandler = сlickHandler;
    }

    public void Enter()
    {
        _сlickHandler.FieldsReceived += ReceivingFields;
        _сlickHandler.ClearSelectedFields();
        Debug.Log("StateWaitingFields entered");
    }

    public void Exit()
    {
        _сlickHandler.FieldsReceived -= ReceivingFields;
        Debug.Log("Fields received");
    }

    private void ReceivingFields(Field firstField, Field secondField)
    {
        if(firstField == null)
            throw new ArgumentNullException(nameof(firstField));
        
        if(secondField == null)
            throw new ArgumentNullException(nameof(secondField));
        
        _levelManager.ReceiveFields(firstField, secondField);
        
        _levelStateMachine.EnterIn<StateProccesingFields>();
    }
}
    

