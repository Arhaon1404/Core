using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class BootstrapEntryPoint : MonoBehaviour
{
    [SerializeField] private LoadingBackground _loadingBackground;
    [SerializeField] private AudioGameManager _audioManager;
    [SerializeField] private LevelInformationManager _levelInformationManager;
    [SerializeField] private LevelCompletionManager _levelCompletionManager;
    [SerializeField] private LevelUIActivityChanger _levelUIActivityChanger;
    
    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _loadingBackground = Instantiate(_loadingBackground);
        
        ServiceLocator.Register(_loadingBackground);
        
        _audioManager = Instantiate(_audioManager);
        
        ServiceLocator.Register(_audioManager);
        
        _levelInformationManager = Instantiate(_levelInformationManager);
        
        ServiceLocator.Register(_levelInformationManager);

        _levelCompletionManager = Instantiate(_levelCompletionManager);
        
        ServiceLocator.Register(_levelCompletionManager);
        
        _levelUIActivityChanger = Instantiate(_levelUIActivityChanger);
        
        ServiceLocator.Register(_levelUIActivityChanger);
        
        InitializePlayerData();
        
        DontDestroyOnLoad(_levelInformationManager);
        DontDestroyOnLoad(_loadingBackground);
        DontDestroyOnLoad(_audioManager);
        DontDestroyOnLoad(_levelCompletionManager);
        DontDestroyOnLoad(_levelUIActivityChanger);
        
        SceneManager.LoadScene("MainMenuScene");
    }

    private void InitializePlayerData()
    {
        YG2.saves.CurrentLevel = 50;
        
        //PlayerPrefs.SetInt("CurrentLevel", 50);
        
        /*
        Debug.Log(PlayerPrefs.GetInt("CurrentLevel"));
        
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
            PlayerPrefs.Save();
        }
        */
    }
}
