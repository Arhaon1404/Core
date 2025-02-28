using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public void OpenLevel()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
