using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private State _currentState;

    public StateMachine(State state)
    {
        _currentState = state;
    }

    public void Request(State state)
    {
        
    }
}
