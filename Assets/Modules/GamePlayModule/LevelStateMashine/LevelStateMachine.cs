using System;
using System.Collections;
using System.Collections.Generic;

public class LevelStateMachine
{
    private Dictionary<Type, ILevelState> _states;
    private ILevelState _currentState;

    public LevelStateMachine()
    {
        _states = new Dictionary<Type, ILevelState>()
        {
            [typeof(StateWaitingFields)] = new StateWaitingFields(this),
            [typeof(StateProccesingFields)] = new StateProccesingFields(this)
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
