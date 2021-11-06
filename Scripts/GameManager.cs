using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Vector3 spawnPoint = new Vector3(0F, 2F, 0F);
    public AudioLib audioLib;
    public Image crosshairIMG;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock mouse

        // crosshair size
        int crosshairSize = PlayerPrefs.GetInt("SETTINGS_CROSSHAIR");
        crosshairIMG.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, crosshairSize);
        crosshairIMG.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, crosshairSize);
        crosshairIMG.rectTransform.ForceUpdateRectTransforms();
    }

}
