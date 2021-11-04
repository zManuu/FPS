using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyHandler : MonoBehaviour
{

    public WeaponSwitch weaponManager;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            weaponManager.SwitchWeapon(); // Die prim�re / sekund�re Waffe ausr�sten
        }
        else if (Input.GetButton("Fire1"))
        {
            weaponManager.currentWeaponObj.Shoot(); // Mit der momentanen Waffe schie�en
        }
        else if (Input.GetKey(KeyCode.R))
        {
            weaponManager.currentWeaponObj.Reload(); // Die momentane Waffe neuladen
        }

        if (Input.GetKey(KeyCode.E))
        {
            weaponManager.currentWeaponObj.SwitchFlashLight();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0); // 1: main menu
        }

    }

}
