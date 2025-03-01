using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateWaitingFields : ILevelState
{
    private readonly LevelStateMachine _levelStateMachine;
    public StateWaitingFields(LevelStateMachine levelStateMachine)
    {
        _levelStateMachine = levelStateMachine;
    }

    public void Enter()
    {
        
        Debug.Log("Im wait fields");
    }

    public void Exit()
    {
        Debug.Log("Fields received");
    }
}
