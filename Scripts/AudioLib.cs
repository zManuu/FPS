using UnityEngine;

public class AudioLib : MonoBehaviour
{

    public AudioSource PISTOL_EMPTY;
    public AudioSource PISTOL_RELOAD;
    public AudioSource PISTOL_SHOOT;
    public AudioClip PISTOL_EMPTY_CLIP;
    public AudioClip PISTOL_RELOAD_CLIP;
    public AudioClip PISTOL_SHOOT_CLIP;

    public AudioSource RIFLE_EMPTY;
    public AudioSource RIFLE_RELOAD;
    public AudioSource RIFLE_SHOOT;
    public AudioClip RIFLE_EMPTY_CLIP;
    public AudioClip RIFLE_RELOAD_CLIP;
    public AudioClip RIFLE_SHOOT_CLIP;

    public AudioClip FLASHLIGHT;
    public AudioSource FLASHLIGHT_CLIP;

    public void PlaySound(int weaponID, string state)
    {

        /*
         * IDs:
         * - 1: rifle
         * - 2: pistol
        */

        float volume = Mathf.Round(PlayerPrefs.GetInt("SETTINGS_VOLUME")) / 100;

        switch (weaponID)
        {
            case 1:
                switch (state)
                {
                    case "empty":
                        RIFLE_EMPTY.PlayOneShot(RIFLE_EMPTY_CLIP, volume);
                        break;
                    case "reload":
                        RIFLE_RELOAD.PlayOneShot(RIFLE_RELOAD_CLIP, volume);
                        break;
                    case "shoot":
                        RIFLE_SHOOT.PlayOneShot(RIFLE_SHOOT_CLIP, volume);
                        break;
                }
                break;
            case 2:
                switch (state)
                {
                    case "empty":
                        PISTOL_EMPTY.PlayOneShot(PISTOL_EMPTY_CLIP, volume);
                        break;
                    case "reload":
                        PISTOL_RELOAD.PlayOneShot(PISTOL_RELOAD_CLIP, volume);
                        break;
                    case "shoot":
                        PISTOL_SHOOT.PlayOneShot(PISTOL_SHOOT_CLIP, volume);
                        break;
                }
                break;
        }
    }

}
