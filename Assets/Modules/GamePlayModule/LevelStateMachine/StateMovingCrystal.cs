using System;
using UnityEngine;

public class StateMovingCrystal : ILevelState
{
    private readonly LevelStateMachine _levelStateMachine;
    private readonly LevelManager _levelManager;
    
    public StateMovingCrystal(LevelStateMachine levelStateMachine, LevelManager levelManager)
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
        _levelManager.CrystalHandler.MoveСompleted += EnterNextState;
        
        _levelManager.ProcessCrystal();
    }

    public void Exit()
    {
        _levelManager.CrystalHandler.MoveСompleted -= EnterNextState;
    }

    private void EnterNextState()
    {
        _levelStateMachine.EnterIn<StateProccesingFieldsFeatures>();
    }
}
    

