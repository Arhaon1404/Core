using UnityEngine;
using UnityEngine.Audio;

public class AudioGameManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private AudioSource _audioBackground;
    [SerializeField] private AudioSource _audioSelectCrystal;
    [SerializeField] private AudioSource _audioDeselectCrystal;
    [SerializeField] private AudioSource _audioMovementCrystal;
    [SerializeField] private AudioSource _audioCoreUnitedCrystal;
    [SerializeField] private AudioSource _audioCompliteLevel;
    [SerializeField] private AudioSource _audioButtonClick;
    
    public AudioMixerGroup AudioMixerGroup => _audioMixerGroup;

    public void PlaySelectSound()
    {
        _audioSelectCrystal.pitch = Random.Range(0.9f, 1.1f);
        _audioSelectCrystal.Play();
    }

    public void PlayDeselectSound()
    {
        _audioDeselectCrystal.Play();
    }

    public void PlayMovementSound()
    {
        _audioMovementCrystal.Play();
    }

    public void PlayWinningSound()
    {
        _audioCoreUnitedCrystal.Stop();
        _audioCompliteLevel.Play();
    }

    public void PlayCoreUniteCrystalSound()
    {
        _audioCoreUnitedCrystal.Play();
    }

    public void PlayButtonClickSound()
    {
        _audioButtonClick.Play();
    }
}
