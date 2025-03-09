using System;
using System.Collections.Generic;

public class LevelStateMachine
{
    private Dictionary<Type, ILevelState> _states;
    private ILevelState _currentState;
    private LevelManager _levelManager;
    private СlickHandler _clickHandler;
    
    public LevelStateMachine(СlickHandler clickHandler)
    {
        if(clickHandler == null)
            throw new ArgumentNullException(nameof(clickHandler));
            
        _clickHandler = clickHandler;
        
        _levelManager = new LevelManager();
        
        _states = new Dictionary<Type, ILevelState>()
        {
            [typeof(StateWaitingFields)] = new StateWaitingFields(this,_levelManager,_clickHandler),
            [typeof(StateProccesingFields)] = new StateProccesingFields(this,_levelManager),
            [typeof(StateMovingCrystal)] = new StateMovingCrystal(this,_levelManager),
            [typeof(StateProccesingFieldsFeatures)] = new StateProccesingFieldsFeatures(this,_levelManager)
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

    

