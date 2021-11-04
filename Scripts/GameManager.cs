using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Vector3 spawnPoint = new Vector3(0F, 2F, 0F);
    public AudioLib audioLib;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock mouse
    }

}
