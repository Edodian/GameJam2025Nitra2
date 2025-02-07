using UnityEngine;
using Cinemachine;

public class ThirdPersonCamController : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public float cameraRotationSpeed = 100f;
    public Transform player;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0)
        {
            freeLookCamera.m_XAxis.Value += horizontalInput * cameraRotationSpeed * Time.deltaTime;
        }
    }
}
