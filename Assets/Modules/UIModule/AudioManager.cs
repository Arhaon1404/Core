using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    private AudioBackground _audioBackground;

    private void Awake()
    {
        if (_audioBackground == null)
        {
            _audioBackground = ServiceLocator.GetService<AudioBackground>();
        }
        
        _slider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    private void ChangeVolume()
    {
        _audioBackground.audioBackground.volume = _slider.value;
    }
}
