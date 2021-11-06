using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{

    [SerializeField] private Slider crosshairSlider;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider dpiSlider;
    [SerializeField] private TextMeshProUGUI crosshairText;
    [SerializeField] private TextMeshProUGUI volumeText;
    [SerializeField] private TextMeshProUGUI dpiText;

    public void Start()
    {
        // load settings
        crosshairSlider.value = PlayerPrefs.GetInt("SETTINGS_CROSSHAIR");
        volumeSlider.value = PlayerPrefs.GetInt("SETTINGS_VOLUME");
        dpiSlider.value = PlayerPrefs.GetInt("SETTINGS_DPI");
    }

    public void OnBackPress()
    {
        SceneManager.LoadScene(0); // 0: main menu
    }

    public void OnCrosshairChange()
    {
        int newValue = (int) Mathf.Round(crosshairSlider.value);
        PlayerPrefs.SetInt("SETTINGS_CROSSHAIR", newValue);
        crosshairText.text = newValue.ToString();
    }
    public void OnVolumeChange()
    {
        int newValue = (int) Mathf.Round(volumeSlider.value);
        PlayerPrefs.SetInt("SETTINGS_VOLUME", newValue);
        volumeText.text = newValue.ToString();
    }
    public void OnDPIChange()
    {
        int newValue = (int) Mathf.Round(dpiSlider.value);
        PlayerPrefs.SetInt("SETTINGS_DPI", newValue);
        dpiText.text = newValue.ToString();
    }

}
