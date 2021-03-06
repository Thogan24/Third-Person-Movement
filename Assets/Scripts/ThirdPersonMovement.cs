using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;

    public float speed = 15f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Jumping variables
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundCheckDistance = 0.4f;
    public LayerMask groundMask;
    bool sprintApplied = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (this.GetComponent<PlayerStats>().isDead == false) {
            // Jump
            isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

            // Gravity
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);


            // Walk
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
        }
    }

    public float getSpeed()
    {
        return speed;
    }

    public void applySprint()
    {
        if(!sprintApplied)
        {
            speed += 50;
            sprintApplied = true;
        }
    }

    public void removeSprint()
    {
        if(sprintApplied)
        {
            speed -= 50;
            sprintApplied = false;
        }
    }
}
