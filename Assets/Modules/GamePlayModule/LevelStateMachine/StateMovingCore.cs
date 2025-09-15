using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMovingCore : ILevelState
{
    private readonly LevelStateMachine _levelStateMachine;
    private readonly ClickHandler _clickHandler;
    private readonly LevelManager _levelManager;
    private readonly LevelAStarProcceder _levelAStarProcceder;

    public StateMovingCore(ClickHandler clickHandler,LevelStateMachine levelStateMachine, LevelManager levelManager, LevelAStarProcceder levelAStarProcceder)
    {
        if(clickHandler == null)
            throw new ArgumentNullException(nameof(clickHandler));
        
        if(levelStateMachine == null)
            throw new ArgumentNullException(nameof(levelStateMachine));
        
        if(levelManager == null)
            throw new ArgumentNullException(nameof(levelManager));
        
        if(levelAStarProcceder == null)
            throw new ArgumentNullException(nameof(levelAStarProcceder));
        
        _clickHandler = clickHandler;
        _levelManager = levelManager;
        _levelStateMachine = levelStateMachine;
        _levelAStarProcceder = levelAStarProcceder;
    }
    
    public void Enter()
    {
        _clickHandler.TurnOff();
        
        Field targetField = _levelAStarProcceder.SearchCrystals();
        
        if (targetField)
        {
            ServiceLocator.GetService<LevelUIActivityChanger>().TurnOnWaitingIcon();
            
            List<AbstractField> path = _levelAStarProcceder.LaunchAStar(targetField);
            
            _levelManager.CoreHandler.MoveСompleted += TransiteToNextState;
            
            _levelManager.ProcessCore(path);
        }
        else
        {
            ServiceLocator.GetService<LevelUIActivityChanger>().TurnOffWaitingIcon();
            
            _clickHandler.TurnOn();
            
            _levelStateMachine.EnterIn<StateWaitingFields>();
        }
    }

    public void Exit()
    { }

    private void TransiteToNextState()
    {
        _levelManager.CoreHandler.MoveСompleted -= TransiteToNextState;
        
        ServiceLocator.GetService<AudioGameManager>().PlayCoreUniteCrystalSound();
        
        _levelStateMachine.EnterIn<StateCheckingLevelCompletion>();
    }
}
