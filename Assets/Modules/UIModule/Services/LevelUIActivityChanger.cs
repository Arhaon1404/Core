using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIActivityChanger : MonoBehaviour
{
    [SerializeField] private WaitingIcon _waitingIcon;

    public void Registration(WaitingIcon waitingIcon)
    {
        if (waitingIcon == null)
        {
            throw new System.ArgumentNullException(nameof(waitingIcon));
        }
        
        _waitingIcon = waitingIcon;

        _waitingIcon.RegistrationTween();
    }

    public void TurnOnWaitingIcon()
    {   
        _waitingIcon.TurnOnAnimation();
    }
    
    public void TurnOffWaitingIcon()
    {
        _waitingIcon.TurnOffAnimation();
    }

    public void TurnOffIcons()
    {
        _waitingIcon.TurnOffAnimation();
        
        _waitingIcon.gameObject.SetActive(false);
    }
}
