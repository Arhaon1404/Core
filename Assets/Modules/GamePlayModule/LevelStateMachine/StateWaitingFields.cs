using System;
using UnityEngine;

public class StateWaitingFields : ILevelState
{
    private readonly LevelStateMachine _levelStateMachine;
    private readonly ClickHandler _clickHandler;
    private readonly FieldSelector _fieldSelector;
    private readonly LevelManager _levelManager;
    
    public StateWaitingFields(LevelStateMachine levelStateMachine,LevelManager levelManager,ClickHandler clickHandler, FieldSelector fieldSelector)
    {
        if(levelStateMachine == null)
            throw new ArgumentNullException(nameof(levelStateMachine));
        
        if(levelManager == null)
            throw new ArgumentNullException(nameof(levelManager));
        
        if(clickHandler == null)
            throw new ArgumentNullException(nameof(clickHandler));
        
        if(fieldSelector == null)
            throw new ArgumentNullException(nameof(fieldSelector));
        
        _clickHandler = clickHandler;
        _levelManager = levelManager;
        _levelStateMachine = levelStateMachine;
        _fieldSelector = fieldSelector;
    }

    public void Enter()
    {
        _fieldSelector.StateUpdated += ReceivingFields;
        _fieldSelector.Clear();
    }

    public void Exit()
    {
        _fieldSelector.StateUpdated -= ReceivingFields;
    }

    private void ReceivingFields(State currentState,Field firstField, Field secondField)
    {
        if (currentState == State.HasEnd)
        {
            _clickHandler.TurnOff();
            
            if(firstField == null)
                throw new ArgumentNullException(nameof(firstField));
        
            if(secondField == null)
                throw new ArgumentNullException(nameof(secondField));
        
            _levelManager.ReceiveFields(firstField, secondField);
        
            _levelStateMachine.EnterIn<StateProccesingFields>();
        }
    }
}
    

