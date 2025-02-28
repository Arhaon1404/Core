using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapEntryPoint : MonoBehaviour
{
    [SerializeField] private LoadingBackground _loadingBackground;
    
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _loadingBackground = Instantiate(_loadingBackground);

        Debug.Log("Initialize complete");
        
        SceneManager.LoadScene("MainMenuScene");
    }
}
