using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelObjects : MonoBehaviour
{
    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private RestartButton _restartButton;
    [SerializeField] private BackToMenuButton _backToMenuButton;
    [SerializeField] private NextLevelButton _nextLevelButton;
    [SerializeField] private StepsCounter _stepsCounter;
    [SerializeField] private SequenceControler _sequenceControler;
    
    [SerializeField] private LevelInfo _levelForTesting;
    
    private LevelInfo _levelInfo;
    
    public RestartButton RestartButton => _restartButton;
    public NextLevelButton NextLevelButton => _nextLevelButton;
    public StepsCounter StepsCounter => _stepsCounter;
    
    //Test Awake
    /*
    private void Awake()
    {
        StartMapGeneration(_levelForTesting);
    }
    */
    
    private void OnEnable()
    {
        _restartButton.OnButtonClicked += RestartLevel;
        _backToMenuButton.OnButtonClicked += BackToMainMenu;
        _nextLevelButton.OnButtonClicked += OpenNextLevel;
    }

    private void OnDisable()
    {
        _restartButton.OnButtonClicked -= RestartLevel;
        _backToMenuButton.OnButtonClicked -= BackToMainMenu;
        _nextLevelButton.OnButtonClicked -= OpenNextLevel;
    }

    
    public void StartMapGeneration(LevelInfo levelInfo)
    {
        _mapGenerator.SetLevelInfo(levelInfo);
        
        _mapGenerator.ProcessGeneration();
        
        _sequenceControler.InitializeSequence(_mapGenerator.StartField);
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
