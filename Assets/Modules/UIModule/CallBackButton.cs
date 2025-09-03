using System;
using UnityEngine;

public class CallBackButton : MonoBehaviour
{
    public event Action OnButtonClicked;
    public void Click()
    {
        OnButtonClicked?.Invoke();
    }
}
