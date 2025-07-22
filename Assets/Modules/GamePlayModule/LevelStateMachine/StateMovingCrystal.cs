using System;
using UnityEngine;

public class StateMovingCrystal : ILevelState
{
    private readonly LevelStateMachine _levelStateMachine;
    private readonly LevelManager _levelManager;
    private readonly FieldSelector _fieldSelector;
    
    public StateMovingCrystal(LevelStateMachine levelStateMachine, LevelManager levelManager, FieldSelector fieldSelector)
    {
        if(levelStateMachine == null)
            throw new ArgumentNullException(nameof(levelStateMachine));
        
        if(levelManager == null)
            throw new ArgumentNullException(nameof(levelManager));
        
        if(fieldSelector == null)
            throw new ArgumentNullException(nameof(fieldSelector));
        
        _levelManager = levelManager;
        _levelStateMachine = levelStateMachine;
        _fieldSelector = fieldSelector;
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
        _fieldSelector.Clear();
        
        ServiceLocator.GetService<LevelCompletionManager>().PassStep();
        
        _levelStateMachine.EnterIn<StateProccesingFieldsFeatures>();
    }
}
    

