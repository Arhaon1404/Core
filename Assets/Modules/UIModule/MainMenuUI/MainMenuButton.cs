using System;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public event Action ElementClicked;

    public virtual void Click()
    {
        ElementClicked?.Invoke();
    }
}
