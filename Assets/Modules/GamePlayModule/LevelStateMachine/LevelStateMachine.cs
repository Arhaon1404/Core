using System;
using System.Collections.Generic;

public class LevelStateMachine
{
    private Dictionary<Type, ILevelState> _states;
    private ILevelState _currentState;
    private LevelManager _levelManager;
    private ClickHandler _clickHandler;
    private FieldSelector _fieldSelector;
    private LevelAStarProcceder _levelAStarProcceder;
    private VictoryFieldStorage _victoryFieldStorage;
    
    public LevelStateMachine(ClickHandler clickHandler ,FieldSelector fieldSelector, LevelAStarProcceder levelAStarProcceder,VictoryFieldStorage victoryFieldStorage)
    {
        if(clickHandler == null)
            throw new ArgumentNullException(nameof(clickHandler));
        
        if(fieldSelector == null)
            throw new ArgumentNullException(nameof(fieldSelector));
        
        if(levelAStarProcceder == null)
            throw new ArgumentNullException(nameof(levelAStarProcceder));
        
        if(victoryFieldStorage == null)
            throw new ArgumentNullException(nameof(victoryFieldStorage));
            
        _clickHandler = clickHandler;
        _fieldSelector = fieldSelector;
        _levelAStarProcceder = levelAStarProcceder;
        _victoryFieldStorage = victoryFieldStorage;
        
        _levelManager = new LevelManager();
        
        _states = new Dictionary<Type, ILevelState>()
        {
            [typeof(StateWaitingFields)] = new StateWaitingFields(this,_levelManager,_clickHandler,_fieldSelector),
            [typeof(StateProccesingFields)] = new StateProccesingFields(this,_levelManager),
            [typeof(StateMovingCrystal)] = new StateMovingCrystal(this,_levelManager,_fieldSelector),
            [typeof(StateProccesingFieldsFeatures)] = new StateProccesingFieldsFeatures(this,_levelManager),
            [typeof(StateMovingCore)] = new StateMovingCore(_clickHandler,this,_levelManager,_levelAStarProcceder),
            [typeof(StateCheckingLevelCompletion)] = new StateCheckingLevelCompletion(this,_levelManager,_victoryFieldStorage)
        };
    }

    public void EnterIn<TState>() where TState : ILevelState
    {
        if (_states.TryGetValue(typeof(TState), out ILevelState state))
        {
            _currentState?.Exit(); 
            _currentState = state;
            _currentState.Enter();
        }
    }
}

    

