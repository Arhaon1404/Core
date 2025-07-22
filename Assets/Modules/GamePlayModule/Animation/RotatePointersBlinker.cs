using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePointersBlinker : MonoBehaviour
{
    [SerializeField] private List<RotatePointer> _rotatePointers;

    public void Play()
    {
        foreach (RotatePointer rotatePointer in _rotatePointers)
        {
            rotatePointer.StartBlinking();
        }
    }

    public void Stop()
    {
        foreach (RotatePointer rotatePointer in _rotatePointers)
        {
            rotatePointer.StopBlinking();
        }
    }
}
