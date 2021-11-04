using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public Transform cameraTransform;
    public WeaponSwitch weaponManager;
    public float dpi = 200;

    public float rotationX, rotationY;

    private void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * dpi * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * dpi * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -70, 70);

        cameraTransform.localRotation = Quaternion.Euler(rotationY, 0, 0);
        weaponManager.currentWeapon.transform.localRotation = Quaternion.Euler(0, 0, rotationY);
        transform.localRotation = Quaternion.Euler(0, rotationX, 0);
    }

}
