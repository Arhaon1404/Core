using UnityEngine;

public class AudioBackground : MonoBehaviour
{
    [SerializeField] private AudioSource _audioBackground;
    
    public AudioSource audioBackground => _audioBackground;
}
