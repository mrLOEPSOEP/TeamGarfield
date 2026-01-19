using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartGame(string sceneName)
    {
        // Get the name of the scene that is currently open
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Load it again
        SceneManager.LoadScene(currentSceneName);
    }
}
