using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsChanger : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    private AudioGameManager _audioGameManager;

    private void Awake()
    {
        if (_audioGameManager == null)
        {
            _audioGameManager = ServiceLocator.GetService<AudioGameManager>();
        }
        
        _slider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    private void ChangeVolume()
    {
        _audioGameManager.AudioMixerGroup.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80,0,_slider.value));
    }
}
