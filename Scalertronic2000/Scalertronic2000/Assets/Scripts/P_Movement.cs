using UnityEngine;

public class P_Movement : MonoBehaviour
{
 public float jumpHeight = 2.4f;
    public float movementSpeed = 3.0f;
    public float sprintSpeed = 6.0f;
    public float gravity = 9.81f;

    private CharacterController myController;
    private Vector3 velocity;

    private Wires wires;
    public bool isGrounded;

    void Start()
    {
        myController = GetComponent<CharacterController>();
        wires = GetComponent<Wires>();

    }

    void Update()
    {
        // Correct ground detection using CharacterController
        isGrounded = myController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small downward force to ensure it sticks to the ground
            //Debug.Log("Grounded!");
        }

        float movementY = Input.GetAxis("Vertical");
        float movementX = Input.GetAxis("Horizontal");

        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        Vector3 move = transform.right * movementX + transform.forward * movementY;
        myController.Move(move * (!isRunning ? sprintSpeed : movementSpeed) * Time.deltaTime);

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2 * gravity);
        }

        if (Input.GetKey(KeyCode.F ) && wires.CanWire)
        {
        if (wires == null)
        {
            Debug.LogError("Wires reference is NULL! Make sure the Wires script is attached.");
            return; // Prevent further errors
        }

        if (wires.CanWire)
        {
            wires.wired();
        }
    }

        // Apply gravity
        velocity.y -= gravity * Time.deltaTime;
        myController.Move(velocity * Time.deltaTime);
    }



}