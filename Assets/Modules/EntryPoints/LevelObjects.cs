using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class LevelObjects : MonoBehaviour
{
    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private Backlighter _backlighter;
    [SerializeField] private VictoryScreen _victoryScreen;
    
    [SerializeField] private RestartButton _restartButton;
    [SerializeField] private BackToMenuButton _backToMenuButton;
    [SerializeField] private NextLevelButton _nextLevelButton;
    [SerializeField] private ADVButton _advButton;
    
    [SerializeField] private ADVRecordCalculator _advRecordCalculator;
    
    [SerializeField] private StepsCounter _stepsCounter;
    [SerializeField] private Timer _timer;
    [SerializeField] private PointsCalculator _pointsCalculator;
    
    [SerializeField] private SequenceControler _sequenceControler;
    [SerializeField] private DownUIObjects _downUIObjects;
    
    [SerializeField] private LevelTitle _levelTitle;
    [SerializeField] private TextMeshProUGUI _titleText;
    
    [SerializeField] private LevelTitle _scoreTitle;
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    [SerializeField] private FinalLevelInfo _finalLevelInfo;
    
    [SerializeField] private WaitingIcon _waitingIcon;

    [SerializeField] private ClickHandler _clickHandler;
    
    [SerializeField] private CameraPositioner _cameraPositioner;
    
    [SerializeField] private TutorialHelper _tutorialHelper;
    
    private LevelInfo _levelInfo;

    private int _finaleLevelScore;
    
    public RestartButton RestartButton => _restartButton;
    public NextLevelButton NextLevelButton => _nextLevelButton;
    public StepsCounter StepsCounter => _stepsCounter;
    public WaitingIcon WaitingIcon => _waitingIcon;
    
    private void OnEnable()
    {
        _restartButton.OnButtonClicked += RestartLevel;
        _backToMenuButton.OnButtonClicked += BackToMainMenu;
        _nextLevelButton.OnButtonClicked += OpenNextLevel;
        _advButton.OnButtonClicked += ClickADVButton;
        ServiceLocator.GetService<LevelCompletionManager>().IsLevelCompleted += BringLevelFinaleState;
    }

    private void OnDisable()
    {
        _restartButton.OnButtonClicked -= RestartLevel;
        _backToMenuButton.OnButtonClicked -= BackToMainMenu;
        _nextLevelButton.OnButtonClicked -= OpenNextLevel;
        _advButton.OnButtonClicked -= ClickADVButton;
        ServiceLocator.GetService<LevelCompletionManager>().IsLevelCompleted -= BringLevelFinaleState;
    }
    
    public void StartMapGeneration(LevelInfo levelInfo)
    {
        _levelInfo = levelInfo;
        
        _mapGenerator.SetLevelInfo(levelInfo);
        
        _mapGenerator.ProcessGeneration();
        
        _titleText.text = levelInfo.name;

        _scoreText.text = YG2.saves.GetCurrentPlayerScore().ToString();
        
        _sequenceControler.InitializeSequence(_mapGenerator.StartField);
        
        _cameraPositioner.Initialize();
        
        _mapGenerator.StartField.IconSpinner.Initialize();
        
        _backlighter.Initialize(_clickHandler.FieldSelector);
        
        _victoryScreen.Initialize(_mapGenerator.ProvideListCrystals());
        
        int level = int.Parse(_levelInfo.name);

        if (_tutorialHelper.FirstLevelTutorial == level || _tutorialHelper.SecondLevelTutorial == level)
        {
            _tutorialHelper.Initialize(_mapGenerator.ProvideListFields(),_clickHandler.FieldSelector);    
        }
    }

    private void BringLevelFinaleState()
    {
        int finaleTime = _timer.GetFinaleSecondTime();
        
        _finaleLevelScore = _pointsCalculator.Calculate(_levelInfo,_stepsCounter.StepsCount,finaleTime);

        int level = int.Parse(_levelInfo.name);
        
        bool isNewRecord = YG2.saves.IsNewRecord(level,_finaleLevelScore);
        
        _finalLevelInfo.IsShowNewRecordImage(isNewRecord);
        
        _nextLevelButton.MoveButton(_finaleLevelScore);

        if (_advRecordCalculator.IsShowButton(level, _finaleLevelScore))
        {
            _advButton.ActivateButton();
        }
        else
        {
            _advButton.DeactivateButton();
        }

        _restartButton.HideButton();
        _backToMenuButton.HideButton();
        _scoreTitle.Hide();
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
        
        YG2.InterstitialAdvShow();
        
        SceneManager.LoadScene("LevelScene");
    }

    private void BackToMainMenu()
    {
        DOTween.KillAll();
        
        YG2.InterstitialAdvShow();
        
        SceneManager.LoadScene("MainMenuScene");
    }

    private void OpenNextLevel()
    {
        DOTween.KillAll();
        
        ServiceLocator.GetService<LevelInformationManager>().SetNextLevelInfo();
        
        int level = int.Parse(_levelInfo.name);
        
        YG2.saves.SetNewRecordLeaderbord(level,_finaleLevelScore);
        
        YG2.InterstitialAdvShow();
        
        YG2.SaveProgress();
        
        SceneManager.LoadScene("LevelScene");
    }

    private void ClickADVButton()
    {
        YG2.RewardedAdvShow("multiplyPoints", () =>
        {
            _finaleLevelScore *= 2;
            
            int level = int.Parse(_levelInfo.name);
            
            YG2.saves.SetADVView(level);
            
            _finalLevelInfo.UpdateScore(_finaleLevelScore);
        
            bool isNewRecord = YG2.saves.IsNewRecord(level,_finaleLevelScore);
        
            _finalLevelInfo.IsShowNewRecordImage(isNewRecord);
            
            _advButton.DeactivateButton();
        });  
    }
}
