using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock mouse
    }

    public void OnPlayPress()
    {
        SceneManager.LoadScene(1); // 1: ingame scene
    }

    public void OnQuitPress()
    {
        Application.Quit();
    }

}
