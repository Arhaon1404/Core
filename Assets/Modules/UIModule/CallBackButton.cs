using System;
using UnityEngine;

public class CallBackButton : MonoBehaviour
{
    public event Action OnButtonClicked;
    private void OnMouseUp()
    {
        OnButtonClicked?.Invoke();
    }
}
