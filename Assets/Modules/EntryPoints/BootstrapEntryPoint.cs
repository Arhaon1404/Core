using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapEntryPoint : MonoBehaviour
{
    [SerializeField] private LoadingBackground _loadingBackground;
    [SerializeField] private AudioBackground _audioBackground;
    [SerializeField] private LevelInformationManager _levelInformationManager;
    [SerializeField] private LevelCompletionManager _levelCompletionManager;
    
    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _loadingBackground = Instantiate(_loadingBackground);
        
        ServiceLocator.Register(_loadingBackground);
        
        _audioBackground = Instantiate(_audioBackground);
        
        ServiceLocator.Register(_audioBackground);
        
        _levelInformationManager = Instantiate(_levelInformationManager);
        
        ServiceLocator.Register(_levelInformationManager);

        _levelCompletionManager = Instantiate(_levelCompletionManager);
        
        ServiceLocator.Register(_levelCompletionManager);
        
        InitializePlayerData();
        
        DontDestroyOnLoad(_levelInformationManager);
        DontDestroyOnLoad(_loadingBackground);
        DontDestroyOnLoad(_audioBackground);
        DontDestroyOnLoad(_levelCompletionManager);
        
        SceneManager.LoadScene("MainMenuScene");
    }

    private void InitializePlayerData()
    {
        PlayerPrefs.SetInt("CurrentLevel", 10);
        
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
