using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntryPoint : MonoBehaviour
{
    [SerializeField] private LevelObjects _levelObjects;
    [SerializeField] private CenterPoint _centerPoint;
    
    private MapGenerator _mapGenerator;
    
    private void Awake()
    {
        CenterPoint instantiatedCenterPoint = Instantiate(_centerPoint);
        
        Vector3 spawnPoint = instantiatedCenterPoint.transform.position;
        
        LevelObjects instantiatedSceneObjects = Instantiate(_levelObjects,spawnPoint,Quaternion.identity);
        
        LevelInfo CurrentLevel = ServiceLocator.GetService<LevelInformationManager>().CurrentLevel;
        
        instantiatedSceneObjects.StartMapGeneration(CurrentLevel);
        
        ServiceLocator.GetService<LevelCompletionManager>().Registration(instantiatedSceneObjects.NextLevelButton, instantiatedSceneObjects.RestartButton, instantiatedSceneObjects.StepsCounter);
        
        ServiceLocator.GetService<LoadingBackground>().TurnOff();
    }
}
