using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInformationManager : MonoBehaviour
{
    [SerializeField] private List<LevelInfo> _allGameLevels;
    [SerializeField] private LevelInfo _currentLevel;
    [SerializeField] private int _currentID;
    
    public LevelInfo CurrentLevel => _currentLevel;
    
    public void CompareLevelID(int levelID)
    {
        int id = levelID - 1;
        
        if (_allGameLevels[id] != null)
        {
            SetNewLevel(_allGameLevels[id]);
            _currentID = id;
        }
        else
        {
            throw new NullReferenceException(nameof(_allGameLevels));
        }
    }

    public void SetNextLevelInfo()
    {
        int id = _currentID + 1;
        
        if (_allGameLevels[id] != null)
        {
            SetNewLevel(_allGameLevels[id]);
            _currentID = id;
            
            if (PlayerPrefs.GetInt("CurrentLevel") < (_currentID + 1))
            {
                PlayerPrefs.SetInt("CurrentLevel", (_currentID + 1));
            }
        }
        else
        {
            throw new NullReferenceException(nameof(_allGameLevels));
        }
    }

    private void SetNewLevel(LevelInfo newLevel)
    {
        _currentLevel = newLevel;
    }
}
