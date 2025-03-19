using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMovingCore : ILevelState
{
    private readonly LevelStateMachine _levelStateMachine;
    private readonly LevelManager _levelManager;
    private readonly LevelAStarProcceder _levelAStarProcceder;

    public StateMovingCore(LevelStateMachine levelStateMachine, LevelManager levelManager, LevelAStarProcceder levelAStarProcceder)
    {
        if(levelStateMachine == null)
            throw new ArgumentNullException(nameof(levelStateMachine));
        
        if(levelManager == null)
            throw new ArgumentNullException(nameof(levelManager));
        
        if(levelAStarProcceder == null)
            throw new ArgumentNullException(nameof(levelAStarProcceder));
        
        _levelManager = levelManager;
        _levelStateMachine = levelStateMachine;
        _levelAStarProcceder = levelAStarProcceder;
    }
    
    public void Enter()
    {
        Debug.Log("Enter StateMovingCore");
        
        if (_levelAStarProcceder.SearchCrystals())
        {
            
        }
        else
        {
            _levelStateMachine.EnterIn<StateWaitingFields>();
        }
    }

    public void Exit()
    {
        Debug.Log("Exit StateMovingCore");
    }
}
