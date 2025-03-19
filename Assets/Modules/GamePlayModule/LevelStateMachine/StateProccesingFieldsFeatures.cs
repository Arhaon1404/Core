using System;
using UnityEngine;

public class StateProccesingFieldsFeatures : ILevelState
{
    private readonly LevelStateMachine _levelStateMachine;
    private readonly LevelManager _levelManager;

    public StateProccesingFieldsFeatures(LevelStateMachine levelStateMachine, LevelManager levelManager)
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
        Debug.Log("Enter StateProccesingFieldsFeatures");
        _levelManager.ProcessFieldsFeatures();
        _levelStateMachine.EnterIn<StateMovingCore>();
    }

    public void Exit()
    {
        Debug.Log("Exit StateProccesingFieldsFeatures");
    }
}
