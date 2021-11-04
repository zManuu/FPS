using UnityEngine;

public class Movement : MonoBehaviour
{

    public CharacterController controller;
    public Transform groundcheck;
    public Transform wallcheck;
    public LayerMask groundmask;
    public LayerMask wallmask;
    public float gravity = -10F;
    public float movementSpeed = 10F;
    public float jumpForce = 100F;
    public bool onGround;
    public bool nearWall;
    public Vector3 velocity = new Vector3(0F, 0F, 0F);

    void Update()
    {
        onGround = Physics.CheckSphere(groundcheck.position, 0.2F, groundmask);
        nearWall = Physics.CheckSphere(wallcheck.position, 1F, wallmask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * movementSpeed * Time.deltaTime);

        if (!onGround)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0;
        }

        if (onGround && !nearWall && Input.GetButton("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2F * (gravity));
            Debug.Log(velocity.y);
        }

        controller.Move(velocity * Time.deltaTime);

    }

}
