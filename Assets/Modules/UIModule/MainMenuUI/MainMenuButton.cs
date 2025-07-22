using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class MainMenuButton : MonoBehaviour
{
    private Collider _collider;

    public event Action ElementClicked;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    protected virtual void OnMouseUp()
    {
        ElementClicked?.Invoke();
    }
}
