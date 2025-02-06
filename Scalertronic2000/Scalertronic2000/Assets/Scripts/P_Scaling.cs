using UnityEngine;

public class P_Scaling : MonoBehaviour
{
    public bool isSmall = false;
    public float ScaleMultiplier = 1.5f;
    public float ScaleJumpnig = 1.5f;
    public bool canScale = true;

    private Vector3 originalScale; // Store the initial scale
    private P_Movement p_Movement;
    private float originalspeed;

    void Start()
    {
        // Assign P_Movement dynamically
        p_Movement = GetComponent<P_Movement>();
        
        if (p_Movement == null)
        {
            Debug.LogError("P_Movement script is missing!");
            return;
        }

        originalScale = transform.localScale;
        originalspeed = p_Movement.movementSpeed; // Now correctly references movementSpeed
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && p_Movement.isGrounded) // Example key for scaling up
        {
            if (isSmall )
            {
                ScaleDown();
            }
            else
            {
                if (canScale)
                {
                    ScaleUp();
                }
                else
                {
                    Debug.Log("Can't scale up, something is above!");
                }
            }
        }
    }

    private void ScaleUp()
    {
        transform.localScale = originalScale * ScaleMultiplier; 
        Debug.Log("Scaled Up!");
        isSmall = true;
        p_Movement.movementSpeed = originalspeed; // Restore movementSpeed
    }

    private void ScaleDown()
    {
        transform.localScale = originalScale; // Reset to original size
        Debug.Log("Scaled Down!");
        isSmall = false;
        p_Movement.movementSpeed = originalspeed * (ScaleMultiplier/4); 
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
