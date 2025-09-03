using System;
using UnityEngine;

public class PlayButton : MainMenuButton
{
    public event Action<int> ElementClicked;
    
    public override void Click()
    {
        int currentLevelID = PlayerPrefs.GetInt("CurrentLevel");
        
        ElementClicked?.Invoke(currentLevelID);
    }
}
