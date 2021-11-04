using UnityEngine;

public class Gun : MonoBehaviour
{

    public Camera _camera;
    public ParticleSystem shootParticle;
    public GameObject impactEffect;
    public GameObject flashLight;
    public float damage = 10F;
    public float range = 100F;
    public float ammunitionCapacity = 30F;
    public float reloadTime = 1.2F;
    public float shootDelay = 0.3F;
    public float currentAmmo;
    public float impactEffectTime = 1.5F;
    public float shootVolume = 1F;
    public int ID;
    public bool flashLightEnabled;

    private bool reloading;
    private bool inShootDelay;
    private AudioLib audioLib;
    private bool inFlashlightDelay;
    private const float flashlightDelayTime = 0.6f;

    private void Start()
    {
        currentAmmo = ammunitionCapacity; // Magazin voll beim Start
        audioLib = FindObjectOfType<GameManager>().audioLib;
    }

    public void Shoot()
    {
        if (!reloading && !inShootDelay)
        {

            currentAmmo -= 1;
            if (currentAmmo <= 0)
            {
                currentAmmo = 0;
                audioLib.PlaySound(ID, "empty"); // Sound
                inShootDelay = true;
                Invoke("ClearShootDelay", shootDelay);
                return;
            }

            shootParticle.Play(); // Schuss Partikel abspielen
            audioLib.PlaySound(ID, "shoot"); // Schuss Sound abspielen
            RaycastHit hit;
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range)) // Wird ausgeführt, wenn etwas getroffen wird
            {
                Damagable damagable = hit.transform.gameObject.GetComponent<Damagable>();
                if (damagable != null) // Getroffenes objekt hat den component Damageable und ist somit zerstörbar
                {
                    damagable.DealDamage(damage);
                }

                GameObject impactEffectObj = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactEffectObj, impactEffectTime);
            }
            inShootDelay = true;
            Invoke("ClearShootDelay", shootDelay);
        }
    }

    public void Reload()
    {
        if (!reloading && currentAmmo < ammunitionCapacity) // Wird ausgeführt, wenn die Waffe nicht voll ist und nicht gerade neu geladen wird
        {
            reloading = true;
            audioLib.PlaySound(ID, "reload");
            Invoke("ClearReload", reloadTime);
        }
    }

    public void SwitchFlashLight()
    {
        if (!inFlashlightDelay)
        {
            if (flashLight.activeSelf)
            {
                flashLight.SetActive(false);
            } else
            {
                flashLight.SetActive(true);
            }

            audioLib.FLASHLIGHT_CLIP.PlayOneShot(audioLib.FLASHLIGHT);
            inFlashlightDelay = true;
            Invoke("ClearFlashlightDelay", flashlightDelayTime);
        }
    }

    private void ClearFlashlightDelay()
    {
        inFlashlightDelay = false;
    }

    private void ClearReload()
    {
        reloading = false;
        currentAmmo = ammunitionCapacity;
    }

    private void ClearShootDelay()
    {
        inShootDelay = false;
    }

}
