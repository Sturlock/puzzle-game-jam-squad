using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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

    public float mouseSensitivity = 100;
    public Camera playerCam;

    float playerSpeed;
    float inAirMult = 1f;
    float xRotation = 0f;
    Vector3 velocity;

    private Transform rightHand;
    private Transform centerHands; 

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        //Camera
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        //Movement
        SprintCheck();

        float x = Input.GetAxis("Horizontal") * inAirMult;
        float z = Input.GetAxis("Vertical") * inAirMult;

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

    void CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            inAirMult = 1f;
        }
        else
            inAirMult = 0.5f;
    }

    void SprintCheck()
    {
         if (Input.GetKey(KeyCode.LeftShift))
            playerSpeed = sprintSpeed;
         else
             playerSpeed = walkSpeed;
    }
}
