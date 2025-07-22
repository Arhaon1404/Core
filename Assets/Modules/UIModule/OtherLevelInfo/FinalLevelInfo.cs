using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class FinalLevelInfo : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private StepsCounter _stepsCounter;
    [SerializeField] private TextMeshProUGUI _textTime;
    [SerializeField] private TextMeshProUGUI _textSteps;
    [SerializeField] private SpawnPoint _spawnPoint;

    public void UpdateInfo()
    {
        _timer.StopTimer();

        if (_timer.MinuteTime < 9)
        {
            int roundedSeconds = Mathf.RoundToInt(_timer.SecondTime);

            string minuteConversion = "0" + _timer.MinuteTime;
            
            string secondConversion = "0" + roundedSeconds;
            
            if (roundedSeconds <= 9)
            {
                _textTime.text = minuteConversion + ":" + secondConversion;
            }
            else
            {
                _textTime.text = minuteConversion + ":" + roundedSeconds;
            }
        }
        else
        {
            int roundedSeconds = Mathf.RoundToInt(_timer.SecondTime);
            
            _textTime.text = _timer.MinuteTime + ":" + roundedSeconds;
        }

        _textSteps.text = _stepsCounter.StepsCount.ToString();

        SmoothMove();
    }

    private void SmoothMove()
    {
        float duration = 0.5f;
        
        transform.DOLocalMove(_spawnPoint.transform.localPosition,duration);
    }
}
