using System;
using System.Collections.Generic;

public class LevelStateMachine
{
    private Dictionary<Type, ILevelState> _states;
    private ILevelState _currentState;
    private LevelManager _levelManager;
    private СlickHandler _clickHandler;
    private LevelAStarProcceder _levelAStarProcceder;
    
    public LevelStateMachine(СlickHandler clickHandler, LevelAStarProcceder levelAStarProcceder)
    {
        if(clickHandler == null)
            throw new ArgumentNullException(nameof(clickHandler));
        
        if(levelAStarProcceder == null)
            throw new ArgumentNullException(nameof(levelAStarProcceder));
            
        _clickHandler = clickHandler;
        _levelAStarProcceder = levelAStarProcceder;
        
        _levelManager = new LevelManager();
        
        _states = new Dictionary<Type, ILevelState>()
        {
            [typeof(StateWaitingFields)] = new StateWaitingFields(this,_levelManager,_clickHandler),
            [typeof(StateProccesingFields)] = new StateProccesingFields(this,_levelManager),
            [typeof(StateMovingCrystal)] = new StateMovingCrystal(this,_levelManager),
            [typeof(StateProccesingFieldsFeatures)] = new StateProccesingFieldsFeatures(this,_levelManager),
            [typeof(StateMovingCore)] = new StateMovingCore(this,_levelManager,_levelAStarProcceder)
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

    

