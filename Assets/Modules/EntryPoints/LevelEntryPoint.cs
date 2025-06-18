using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntryPoint : MonoBehaviour
{
    [SerializeField] private LevelObjects _levelObjects;
    [SerializeField] private CenterPoint _centerPoint;
    
    private void Awake()
    {
        CenterPoint instantiatedCenterPoint = Instantiate(_centerPoint);
        
        Vector3 spawnPoint = instantiatedCenterPoint.transform.position;
        
        LevelObjects instantiatedSceneObjects = Instantiate(_levelObjects,spawnPoint,Quaternion.identity);
        
        instantiatedSceneObjects.StartMapGeneration();
        
        ServiceLocator.GetService<LoadingBackground>().TurnOff();
    }
}
