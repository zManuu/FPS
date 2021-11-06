using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock mouse
        if (!PlayerPrefs.HasKey("DEFAULT_SET"))
        {
            PlayerPrefs.SetString("DEFAULT_SET", "TRUE");
            PlayerPrefs.SetInt("SETTINGS_CROSSHAIR", 60);
            PlayerPrefs.SetInt("SETTINGS_VOLUME", 100);
            PlayerPrefs.SetInt("SETTINGS_DPI", 200);
        }
    }

    public void OnPlayPress()
    {
        SceneManager.LoadScene(2); // 2: ingame scene
    }

    public void OnSettingsPress()
    {
        SceneManager.LoadScene(1); // 1: settings scene
    }

    public void OnQuitPress()
    {
        Application.Quit();
    }

}
