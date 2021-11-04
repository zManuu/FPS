using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{

    public GameObject rifle;
    public GameObject pistol;
    public Text ammoDisplay;
    public Transform weaponContainer;
    public float switchCooldown = 0.5F;

    public GameObject currentWeapon;
    public Gun currentWeaponObj;

    private bool inSwitchCooldown;

    private void Start()
    {
        currentWeapon = rifle; // Die Rifle ist am Anfang ausgerüstet
        currentWeaponObj = currentWeapon.GetComponent<Gun>();
        inSwitchCooldown = false;

    }

    private void Update()
    {
        UpdateAmmoDisplay();
    }

    public void SwitchWeapon()
    {
        if (!inSwitchCooldown)
        {
            if (currentWeapon.Equals(rifle))
            {
                rifle.SetActive(false);
                pistol.SetActive(true);
                currentWeapon = pistol;
            }
            else
            {
                pistol.SetActive(false);
                rifle.SetActive(true);
                currentWeapon = rifle;
            }
            currentWeaponObj = currentWeapon.GetComponent<Gun>();
            inSwitchCooldown = true;
            Invoke("RemoveCooldown", switchCooldown);
        }
    }

    private void RemoveCooldown()
    {
        inSwitchCooldown = false;
    }

    private void UpdateAmmoDisplay()
    {
        ammoDisplay.text = currentWeaponObj.currentAmmo.ToString();
    }

}
