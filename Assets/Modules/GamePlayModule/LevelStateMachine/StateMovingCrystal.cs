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
        Debug.Log("Entering StateMovingCrystal");

        _levelManager.ProcessCrystal();
    }

    public void Exit()
    {
        Debug.Log("Exiting StateMovingCrystal");
    }
}
    

