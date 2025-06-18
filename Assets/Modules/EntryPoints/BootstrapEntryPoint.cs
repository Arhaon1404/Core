using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapEntryPoint : MonoBehaviour
{
    [SerializeField] private LoadingBackground _loadingBackground;
    [SerializeField] private AudioBackground _audioBackground;
    
    
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
        
        InitializePlayerData();
        
        DontDestroyOnLoad(_loadingBackground);
        DontDestroyOnLoad(_audioBackground);
        
        SceneManager.LoadScene("MainMenuScene");
    }

    private void InitializePlayerData()
    {
        PlayerPrefs.SetInt("CurrentLevel", 20);
        
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
