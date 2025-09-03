using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelButton : PlayButton
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _levelID;
    
    public event Action<int> ElementClicked;
    
    public override void Click()
    {
        if (_levelID != 0)
        {
            ElementClicked?.Invoke(_levelID);
        }
    }

    public void UpdateButtonData(int levelID)
    {
        _levelID = levelID;
        
        _text.text = _levelID.ToString();
        
        _icon.gameObject.SetActive(false);
    }

    public void HideUncomplitedLevel()
    {
        _levelID = 0;
        
        _text.text = "";
        
        _icon.gameObject.SetActive(true);
    }
}
