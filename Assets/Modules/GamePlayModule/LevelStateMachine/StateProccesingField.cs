using System;
using UnityEngine;

public class StateProccesingFields : ILevelState
{
    private readonly LevelStateMachine _levelStateMachine;
    private readonly LevelManager _levelManager;

    public StateProccesingFields(LevelStateMachine levelStateMachine, LevelManager levelManager)
    {
        if(levelStateMachine == null)
            throw new ArgumentNullException(nameof(levelStateMachine));
        
        if(levelManager == null)
            throw new ArgumentNullException(nameof(levelManager));
        
        _levelManager = levelManager;
        _levelStateMachine = levelStateMachine;
    }

    public void Enter()
    {
        Debug.Log("StateProcessingFields entered");
        bool isSuccess = _levelManager.ProcessFields();

        if (isSuccess)
        {
            _levelStateMachine.EnterIn<StateMovingCrystal>();
        }
        else
        {
            _levelStateMachine.EnterIn<StateWaitingFields>();
        }
    }

    public void Exit()
    {
        Debug.Log("Proccessing end");
    }
}

    
