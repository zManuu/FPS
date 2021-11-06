using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public Transform cameraTransform;
    public WeaponSwitch weaponManager;
    private float dpi = 200;

    public float rotationX, rotationY;

    private void Start()
    {
        dpi = PlayerPrefs.GetInt("SETTINGS_DPI");
        Debug.Log(dpi);
    }

    private void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * dpi * Time.deltaTime;
        rotationY -= Input.GetAxis("Mouse Y") * dpi * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -70, 70);

        cameraTransform.localRotation = Quaternion.Euler(rotationY, 0, 0);
        if (weaponManager.currentWeaponObj.ID == 1)
        {
            weaponManager.currentWeapon.transform.localRotation = Quaternion.Euler(rotationY, 270, 0);
        } else if (weaponManager.currentWeaponObj.ID == 2)
        {
            weaponManager.currentWeapon.transform.localRotation = Quaternion.Euler(-rotationY, 90, 0);
        }
        transform.localRotation = Quaternion.Euler(0, rotationX, 0);
    }

}
