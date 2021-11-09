using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{

    public Camera _camera;
    public ParticleSystem shootParticle;
    public GameObject flashLight;
    public GameObject bullet;
    public Transform attackPoint;
    public TextMeshProUGUI ammoDisplay;
    public float damage = 10F;
    public float ammunitionCapacity = 30F;
    public float reloadTime = 1.2F;
    public float shootDelay = 0.3F;
    public float currentAmmo;
    public float spread = 1F;
    public float shootForce;
    public float bulletLifetime;
    public int ID;
    public bool flashLightEnabled;

    private bool reloading;
    private bool inShootDelay;
    private AudioLib audioLib;
    private Animator animator;
    private bool inFlashlightDelay;
    private const float flashlightDelayTime = 0.6f;

    private void Start()
    {
        currentAmmo = ammunitionCapacity; // Magazin voll beim Start
        audioLib = FindObjectOfType<GameManager>().audioLib;
        animator = transform.GetComponent<Animator>();
    }

    public void Shoot()
    {
        if (!reloading && !inShootDelay)
        {

            currentAmmo -= 1;

            // AMMO DISPLAY
            ammoDisplay.SetText($"{currentAmmo}/{ammunitionCapacity}");

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
            Vector3 targetPoint;
            Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // Wird ausgeführt, wenn etwas getroffen wird
            {
                Damagable damagable = hit.transform.gameObject.GetComponent<Damagable>();
                if (damagable != null) // Getroffenes objekt hat den component Damageable und ist somit zerstörbar
                {
                    damagable.DealDamage(damage);
                }
                targetPoint = hit.point;
            } else // Wird ausgeführt, wenn nichts getroffen wurde
            {
                targetPoint = ray.GetPoint(75);
            }

            // BULLET
            Vector3 directionWithoutSpread = targetPoint - attackPoint.position;
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);
            Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);
            GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
            currentBullet.gameObject.SetActive(true);
            currentBullet.transform.forward = directionWithSpread.normalized;
            currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
            Destroy(currentBullet, bulletLifetime);

            inShootDelay = true;
            Invoke("ClearShootDelay", shootDelay);
        }
    }

    public void Reload()
    {
        if (!reloading && currentAmmo < ammunitionCapacity) // Wird ausgeführt, wenn die Waffe nicht voll ist und nicht gerade neu geladen wird
        {
            reloading = true;
            animator.SetTrigger("StartReload");
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
        ammoDisplay.SetText($"{currentAmmo}/{ammunitionCapacity}");
    }
    private void ClearShootDelay()
    {
        inShootDelay = false;
    }

}
