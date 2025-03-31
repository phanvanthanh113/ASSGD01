using UnityEngine;
using UnityEngine.SceneManagement; // Dùng để chuyển scene

public class MenuController : MonoBehaviour
{
    // Hàm bắt đầu game
    public void PlayGame()
    {
        SceneManager.LoadScene("New Scene");
    }

    // Hàm thoát game
    public void QuitGame()
    {
        Debug.Log("Thoát game");
        Application.Quit(); // Thoát game (Chỉ hoạt động khi build game)
    }
}
