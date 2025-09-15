using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LevelSelectorVisualizer : MonoBehaviour
{
    [SerializeField] private List<SelectLevelButton> _selectLevelButtons;
    [SerializeField] private MainMenuButton _leftScrollButton;
    [SerializeField] private MainMenuButton _rightScrollButton;

    private int _minListID;
    private int _maxListID;
    private int _currentListID;
    
    private int _indentMinElement;
    
    public List<SelectLevelButton> SelectLevelButtons => _selectLevelButtons;

    private void OnEnable()
    {
        _leftScrollButton.ElementClicked += OpenPreviousListLevels;
        _rightScrollButton.ElementClicked += OpenNextListLevels;
    }

    private void OnDisable()
    {
        _leftScrollButton.ElementClicked -= OpenPreviousListLevels;
        _rightScrollButton.ElementClicked -= OpenNextListLevels;
    }

    private void Awake()
    {
        _minListID = 1;
        _maxListID = 51;
        _indentMinElement = 10;
            
        UpdateButtons(_minListID);
        
        _leftScrollButton.gameObject.SetActive(false);
    }
    
    private void UpdateButtons(int firstElementID)
    {
        int currentLevelID = YG2.saves.CurrentLevel;
        int currentButtonID = firstElementID;

        _currentListID = currentButtonID;
        
        foreach (SelectLevelButton button in _selectLevelButtons)
        {
            if (currentButtonID <= currentLevelID)
            {
                button.UpdateButtonData(currentButtonID);
            }
            else
            {
                button.HideUncomplitedLevel();
            }
            
            currentButtonID++;
        }
    }

    private void OpenNextListLevels()
    {
        if (_rightScrollButton.isActiveAndEnabled != false)
        {
            UpdateButtons(_currentListID + _indentMinElement);

            if (_leftScrollButton.isActiveAndEnabled == false)
            {
                _leftScrollButton.gameObject.SetActive(true);
            }
            
            if (_currentListID == _maxListID)
            {
                _rightScrollButton.gameObject.SetActive(false);
            }
        }
    }
    
    private void OpenPreviousListLevels()
    {
        if (_leftScrollButton.isActiveAndEnabled != false)
        {
            UpdateButtons(_currentListID - _indentMinElement);

            if (_rightScrollButton.isActiveAndEnabled == false)
            {
                _rightScrollButton.gameObject.SetActive(true);
            }
            
            if (_currentListID <= _minListID)
            {
                _leftScrollButton.gameObject.SetActive(false);
            }
        }
    }
}
