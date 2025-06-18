using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class MainMenuButton : MonoBehaviour
{
    private Collider2D _collider;

    public event Action ElementClicked;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    protected virtual void OnMouseUp()
    {
        ElementClicked?.Invoke();
    }
}
