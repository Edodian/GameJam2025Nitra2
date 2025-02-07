using System.Collections;
using UnityEngine;

public class P_Scaling : MonoBehaviour
{
    public bool isSmall = false;
    public float ScaleMultiplier = 1.5f;
    public float ScaleJumpnig = 1.5f;
    public bool canScale = true;
    public float scaleDuration = 3f; // Duration for scaling transition

    private Vector3 originalScale; // Store the initial scale
    private P_Movement p_Movement;
    private float originalspeed;
    private Coroutine scalingCoroutine; // To keep track of the active scaling coroutine
    public stateHandler stateHandler;


    void Start()
    {
        // Assign P_Movement dynamically
        p_Movement = GetComponent<P_Movement>();

        if (p_Movement == null)
        {
            Debug.LogError("P_Movement script is missing!");
            return;
        }
        if (stateHandler == null)
        {
            Debug.LogError("ADD STATEHANDLER!!! Assets/Ui/StateHandler");
        }
        originalScale = transform.localScale;
        originalspeed = p_Movement.movementSpeed; // Now correctly references movementSpeed
                                                  //     audioSource = gameObject.GetComponent<AudioSource>();
    //ScaleUp();

    }

    void Update()
    {
        if (!(stateHandler.isPaused || stateHandler.isCompleted))
        {
            if (Input.GetKeyDown(KeyCode.E) && p_Movement.isGrounded)
            {
                if (scalingCoroutine != null)
                {
                    StopCoroutine(scalingCoroutine);
                }

                if (isSmall)
                {
                    scalingCoroutine = StartCoroutine(SmoothScale(originalScale));
                    p_Movement.movementSpeed = originalspeed / 2;
                    //   audioSource.PlayOneShot(scaleDown, 1);
                    if (SoundManager.sndm != null)
                    {
                        SoundManager.sndm.Play("ScaleDown");
                    }
                }
                else
                {
                    if (canScale)
                    {
                        Vector3 targetScale = originalScale * ScaleMultiplier;
                        scalingCoroutine = StartCoroutine(SmoothScale(targetScale)); // Smooth scale up
                        p_Movement.movementSpeed = originalspeed;
                        //      audioSource.PlayOneShot(scaleUp, 1);
                        if (SoundManager.sndm != null)
                        {
                            SoundManager.sndm.Play("ScaleUp");
                        }
                    }
                    else
                    {
                        Debug.Log("Can't scale up, something is above!");
                    }
                }

            }
        }
    }

    private IEnumerator SmoothScale(Vector3 targetScale)
    {
        float elapsed = 0f;
        Vector3 startingScale = transform.localScale;

        while (elapsed < scaleDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / scaleDuration);
            transform.localScale = Vector3.Lerp(startingScale, targetScale, t);
            yield return null;
        }

        transform.localScale = targetScale; // Ensure the final scale is set
        Debug.Log("Scaling complete!");
        isSmall = !isSmall;

    }

    private void OnTriggerEnter(Collider target)
    {
        canScale = false;
    }

    private void OnTriggerExit(Collider target)
    {
        canScale = true;
    }
}
