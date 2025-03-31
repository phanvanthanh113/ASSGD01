using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("New Scene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
