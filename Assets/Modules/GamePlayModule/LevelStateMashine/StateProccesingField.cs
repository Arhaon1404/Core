using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateProccesingFields : ILevelState
{
    private readonly LevelStateMachine _levelStateMachine;

    public StateProccesingFields(LevelStateMachine levelStateMachine)
    {
        _levelStateMachine = levelStateMachine;
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
        
    }
}
