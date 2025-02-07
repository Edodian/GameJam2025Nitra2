using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class P_Movement : MonoBehaviour
{
    public float jumpHeight = 2.4f;
    public float movementSpeed = 3.0f;
    public float sprintSpeed = 6.0f;
    public float gravity = 9.81f;
    public string WalkSFXTitle1;
    public string WalkSFXTitle2;
    public string JumpSFX;
    public float WalkSFXInterval = 0.6f;

    private CharacterController myController;
    private Vector3 velocity;
    public bool isGrounded, isRunning, isJumped;
    private bool isSFXPlaying, stepturn;

    void Start()
    {
        myController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = myController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            //Debug.Log("Grounded!");
        }

        float movementY = Input.GetAxis("Vertical");
        float movementX = Input.GetAxis("Horizontal");

        isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        Vector3 move = transform.right * movementX + transform.forward * movementY;
        myController.Move(move * (!isRunning ? sprintSpeed : movementSpeed) * Time.deltaTime);

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2 * gravity);
            isJumped = true;
        }

        velocity.y -= gravity * Time.deltaTime;
        myController.Move(velocity * Time.deltaTime);
        if (isGrounded && (movementY != 0 || movementX != 0) && !isSFXPlaying && SoundManager.sndm != null)
        {
            StartCoroutine(PlayStep());
        }
        if (isJumped && !isGrounded)
        {
            SoundManager.sndm.Play(JumpSFX);
            isJumped = false;
        }
    }
    private IEnumerator PlayStep()
    {
        isSFXPlaying = true;
        SoundManager.sndm.Play(stepturn ? WalkSFXTitle1 : WalkSFXTitle2);

        stepturn = !stepturn;
        if (!isRunning)
        {
            yield return new WaitForSeconds(WalkSFXInterval);
        }
        else
        {
            yield return new WaitForSeconds(WalkSFXInterval / 2);
        }
        isSFXPlaying = false;
    }



}