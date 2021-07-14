using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;

    public float walkSpeed = 4f;
    public float sprintSpeed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.25f;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    bool isGrounded;

    float playerSpeed;
    Vector3 velocity;

    void Start()
    {
        
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        SprintCheck();

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        Vector3 move = transform.right * x + transform.forward * z;
        velocity.y += gravity * Time.deltaTime;

        controller.Move(move * playerSpeed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        CheckIfGrounded();
    }

    private void CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            
        }
        
            
    }

    private void SprintCheck()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            playerSpeed = sprintSpeed;
        else
            playerSpeed = walkSpeed;
    }
}