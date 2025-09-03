using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelObjects : MonoBehaviour
{
    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private Backlighter _backlighter;
    [SerializeField] private VictoryScreen _victoryScreen;
    
    [SerializeField] private RestartButton _restartButton;
    [SerializeField] private BackToMenuButton _backToMenuButton;
    [SerializeField] private NextLevelButton _nextLevelButton;
    
    [SerializeField] private StepsCounter _stepsCounter;
    
    [SerializeField] private SequenceControler _sequenceControler;
    [SerializeField] private DownUIObjects _downUIObjects;
    
    [SerializeField] private LevelTitle _levelTitle;
    [SerializeField] private TextMeshProUGUI _titleText;
    
    [SerializeField] private WaitingIcon _waitingIcon;

    [SerializeField] private ClickHandler _clickHandler;
    
    [SerializeField] private CameraPositioner _cameraPositioner;
    
    private LevelInfo _levelInfo;
    
    public RestartButton RestartButton => _restartButton;
    public NextLevelButton NextLevelButton => _nextLevelButton;
    public StepsCounter StepsCounter => _stepsCounter;
    public WaitingIcon WaitingIcon => _waitingIcon;
    
    private void OnEnable()
    {
        _restartButton.OnButtonClicked += RestartLevel;
        _backToMenuButton.OnButtonClicked += BackToMainMenu;
        _nextLevelButton.OnButtonClicked += OpenNextLevel;
        ServiceLocator.GetService<LevelCompletionManager>().IsLevelCompleted += BringLevelFinaleState;
    }

    private void OnDisable()
    {
        _restartButton.OnButtonClicked -= RestartLevel;
        _backToMenuButton.OnButtonClicked -= BackToMainMenu;
        _nextLevelButton.OnButtonClicked -= OpenNextLevel;
        ServiceLocator.GetService<LevelCompletionManager>().IsLevelCompleted -= BringLevelFinaleState;
    }
    
    public void StartMapGeneration(LevelInfo levelInfo)
    {
        _mapGenerator.SetLevelInfo(levelInfo);
        
        _mapGenerator.ProcessGeneration();
        
        _titleText.text = levelInfo.name;
        
        _sequenceControler.InitializeSequence(_mapGenerator.StartField);
        
        _cameraPositioner.Initialize();
        
        _mapGenerator.StartField.IconSpinner.Initialize();
        
        _backlighter.Initialize(_clickHandler.FieldSelector);
        
        _victoryScreen.Initialize(_mapGenerator.ProvideListCrystals());
    }

    private void BringLevelFinaleState()
    {
        _restartButton.HideButton();
        _backToMenuButton.HideButton();
        
        _downUIObjects.Hide();
        
        _levelTitle.Hide();
        
        List<Field> fields = _mapGenerator.ProvideListFields();
        
        foreach (Field field in fields)
        {
            field.DeactivateAllEffects();
            field.Platform.ActivateWinningBacklight();
        }

        _victoryScreen.LightUpCrystals();
        
        _clickHandler.enabled = false;
    }

    private void RestartLevel()
    {
        DOTween.KillAll();
        
        SceneManager.LoadScene("LevelScene");
    }

    private void BackToMainMenu()
    {
        DOTween.KillAll();
        
        SceneManager.LoadScene("MainMenuScene");
    }

    private void OpenNextLevel()
    {
        DOTween.KillAll();
        
        ServiceLocator.GetService<LevelInformationManager>().SetNextLevelInfo();
        
        SceneManager.LoadScene("LevelScene");
    }
}
