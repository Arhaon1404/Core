using System;
using UnityEngine;
using YG;

public class PlayButton : MainMenuButton
{
    public event Action<int> ElementClicked;
    
    public override void Click()
    {
        int currentLevelID = YG2.saves.CurrentLevel;
        
        ElementClicked?.Invoke(currentLevelID);
    }
}
