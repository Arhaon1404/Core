using System;
using UnityEngine;

public interface IInputSource
{
    public event Action<GameObject> GottenHit;
}
