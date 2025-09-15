using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletionManager : MonoBehaviour
{
    [SerializeField] private NextLevelButton _nextLevelButton;
    [SerializeField] private RestartButton _restartButton;
    [SerializeField] private StepsCounter _stepsCounter;

    public event Action IsFirstStepComplited;
    public event Action IsLevelCompleted;
    
    public void Registration(NextLevelButton nextLevelButton, RestartButton restartButton, StepsCounter stepsCounter)
    {
        if (nextLevelButton == null)
        {
            throw new NullReferenceException(nameof(nextLevelButton));
        }
        
        if (restartButton == null)
        {
            throw new NullReferenceException(nameof(nextLevelButton));
        }
        
        if (stepsCounter == null)
        {
            throw new NullReferenceException(nameof(nextLevelButton));
        }
        
        _nextLevelButton = nextLevelButton;
        _restartButton = restartButton;
        _stepsCounter = stepsCounter;
    }

    public void RestartLevel()
    {
        
    }

    public void ShowNextLevelButton()
    {
        IsLevelCompleted?.Invoke();
    }

    public void ShowRestartButton()
    {
        _restartButton.ShowButton();
        IsFirstStepComplited?.Invoke();
    }

    public void PassStep()
    {
        _stepsCounter.AddStep();
    }
}
