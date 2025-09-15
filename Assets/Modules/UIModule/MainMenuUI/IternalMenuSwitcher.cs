using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using UnityEngine.UIElements;
using YG.Utils.LB;

public class IternalMenuSwitcher : MonoBehaviour
{
    [SerializeField] private MainMenuElement _mainMenu;
    [SerializeField] private MainMenuElement _selectLevel;
    [SerializeField] private MainMenuElement _settingsMenu;
    [SerializeField] private MainMenuElement _leaderboard;
    
    [SerializeField] private PlayButton _startLevelButton;
    
    [SerializeField] private MainMenuButton _levelSelectionButton;
    [SerializeField] private MainMenuButton _levelSelectionBackButton;
    
    [SerializeField] private LeaderboardYG _leaderboardYG;
    [SerializeField] private MainMenuButton _settingsButton;
    [SerializeField] private MainMenuButton _settingsBackButton;
    
    [SerializeField] private MainMenuButton _leaderboardButton;
    [SerializeField] private MainMenuButton _leaderboardBackButton;
    
    [SerializeField] private MainMenuButton _testUpdateButton;
    
    [SerializeField] private LevelSelectorVisualizer _levelSelectorVisualizer;
    
    private void OnEnable()
    {
        _startLevelButton.ElementClicked += OpenLevel;
        _levelSelectionButton.ElementClicked += OpenSelectLevelMenu;
        _levelSelectionBackButton.ElementClicked += CloseSelectLevelMenu;
        _settingsButton.ElementClicked += OpenOptionsMenu;
        _settingsBackButton.ElementClicked += CloseOptionsMenu;
        _leaderboardButton.ElementClicked += OpenLeaderboard;
        _leaderboardBackButton.ElementClicked += CloseLeaderboard;
        
        foreach (SelectLevelButton button in _levelSelectorVisualizer.SelectLevelButtons)
        {
            button.ElementClicked += OpenLevel;
        }
    }

    private void OnDisable()
    {
        _startLevelButton.ElementClicked -= OpenLevel;
        _levelSelectionButton.ElementClicked -= OpenSelectLevelMenu;
        _levelSelectionBackButton.ElementClicked -= CloseSelectLevelMenu;
        _settingsButton.ElementClicked -= OpenOptionsMenu;
        _settingsBackButton.ElementClicked -= CloseOptionsMenu;
        _leaderboardButton.ElementClicked -= OpenLeaderboard;
        _leaderboardBackButton.ElementClicked -= CloseLeaderboard;
        
        foreach (SelectLevelButton button in _levelSelectorVisualizer.SelectLevelButtons)
        {
            button.ElementClicked -= OpenLevel;
        }
    }

    public void OpenLevel(int levelID)
    {
        ServiceLocator.GetService<LevelInformationManager>().CompareLevelID(levelID);
        
        YG2.InterstitialAdvShow();
        
        SceneManager.LoadScene("LevelScene");
        
        ServiceLocator.GetService<LoadingBackground>().TurnOn();
    }

    public void OpenSelectLevelMenu()
    {
        _mainMenu.gameObject.SetActive(false);
        _selectLevel.gameObject.SetActive(true);
    }

    public void CloseSelectLevelMenu()
    {
        _selectLevel.gameObject.SetActive(false);
        _mainMenu.gameObject.SetActive(true);
    }

    public void OpenOptionsMenu()
    {
        _mainMenu.gameObject.SetActive(false);
        _settingsMenu.gameObject.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        _settingsMenu.gameObject.SetActive(false);
        _mainMenu.gameObject.SetActive(true);
    }
    
    public void OpenLeaderboard()
    {
        if (YG2.player.auth == false)
        {
            YG2.OpenAuthDialog();    
        }
        else
        {
            _mainMenu.gameObject.SetActive(false);
            _leaderboard.gameObject.SetActive(true);
            
            _leaderboardYG.UpdateLB();
        }
    }

    public void CloseLeaderboard()
    {
        _leaderboard.gameObject.SetActive(false);
        _mainMenu.gameObject.SetActive(true);
    }
}
