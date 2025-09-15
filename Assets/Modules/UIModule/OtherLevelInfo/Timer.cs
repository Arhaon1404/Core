using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _secondTime;
    [SerializeField] private float _minuteTime;
    
    private bool _isActive;
    
    public float SecondTime => _secondTime;
    public float MinuteTime => _minuteTime;
    
    private void Awake()
    {
        _isActive = true;
        _secondTime = 0;
        _minuteTime = 0;
    }

    private void Update()
    {
        if (_isActive)
        {
            _secondTime += Time.deltaTime;

            if (_secondTime >= 60.0f)
            {
                _secondTime = 0;
                _minuteTime++;
            }
        }
    }

    public void StopTimer()
    {
        _isActive = false;
    }

    public int GetFinaleSecondTime()
    {
        int finaleTime = Convert.ToInt32(_secondTime);
        
        finaleTime += Convert.ToInt32(_minuteTime * 60);

        return finaleTime;
    }
}
