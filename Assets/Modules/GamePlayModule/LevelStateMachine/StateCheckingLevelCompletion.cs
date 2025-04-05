using System;
using System.Collections.Generic;
using UnityEngine;

public class StateCheckingLevelCompletion : ILevelState
{
    private readonly LevelStateMachine _levelStateMachine;
    private readonly LevelManager _levelManager;
    private readonly VictoryFieldStorage _victoryFieldStorage;
    
    public StateCheckingLevelCompletion(LevelStateMachine levelStateMachine, LevelManager levelManager, VictoryFieldStorage victoryFieldStorage)
    {
        if(levelStateMachine == null)
            throw new ArgumentNullException(nameof(levelStateMachine));
        
        if(levelManager == null)
            throw new ArgumentNullException(nameof(levelManager));
        
        if(victoryFieldStorage == null)
            throw new ArgumentNullException(nameof(victoryFieldStorage));
        
        _levelManager = levelManager;
        _levelStateMachine = levelStateMachine;
        _victoryFieldStorage = victoryFieldStorage;

        _levelManager.LevelCompletionHandler.VictoryСonfirmed += CompliteLevel; 
        _levelManager.LevelCompletionHandler.LoseСonfirmed += LoseLevel;
        _levelManager.LevelCompletionHandler.VictoryNotAchieved += ReturnPreviousState;
    }
    
    public void Enter()
    {
        _levelManager.ProccessLevelCompletion(_victoryFieldStorage);
    }
    
    public void Exit()
    { }

    private void CompliteLevel()
    {
        Debug.Log("GG");
    }

    private void LoseLevel()
    {
        Debug.Log("Skill issue");
    }

    private void ReturnPreviousState()
    {
        _levelStateMachine.EnterIn<StateMovingCore>();
    }
}
