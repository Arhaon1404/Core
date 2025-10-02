using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using YG;

public class BootstrapEntryPoint : MonoBehaviour
{
    [SerializeField] private LoadingBackground _loadingBackground;
    [SerializeField] private AudioGameManager _audioManager;
    [SerializeField] private LevelInformationManager _levelInformationManager;
    [SerializeField] private LevelCompletionManager _levelCompletionManager;
    [SerializeField] private LevelUIActivityChanger _levelUIActivityChanger;
    [SerializeField] private PostProcessProfile _postProcessProfile;

    private string settingOff;
    
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

        settingOff = "AmbientOcclusion";
        
        if (YG2.envir.isMobile == true)
        {
            foreach (PostProcessEffectSettings effectSettings in _postProcessProfile.settings)
            {
                if (effectSettings.name == settingOff)
                {
                    effectSettings.enabled.value = false;
                }
            }
        }
        else
        {
            foreach (PostProcessEffectSettings effectSettings in _postProcessProfile.settings)
            {
                if (effectSettings.name == settingOff)
                {
                    effectSettings.enabled.value = true;
                }
            }
        }
        
        SceneManager.LoadScene("MainMenuScene");
    }

    private void InitializePlayerData()
    {
        if (YG2.saves.CurrentLevel == 0)
        {
            YG2.saves.CurrentLevel = 1;
        }
    }
}
