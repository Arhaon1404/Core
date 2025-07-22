using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MainMenuButton
{
    public event Action<int> ElementClicked;
    
    protected virtual void OnMouseUp()
    {
        int currentLevelID = PlayerPrefs.GetInt("CurrentLevel");
        
        ElementClicked?.Invoke(currentLevelID);
    }
}
