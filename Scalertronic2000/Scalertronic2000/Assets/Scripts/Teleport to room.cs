using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Required for UI components

public class TeleportToRoom : MonoBehaviour
{
    public GameObject target; // Target location for teleportation
    public Camera camera; // Main camera
    public Image fadeImage; // Image for fade effect (set in the Inspector)

    void Start()
    {
        if (fadeImage == null)
        {
            Debug.LogError("Fade Image is not assigned! Please assign it in the Inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Transferring...");
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        // Start fade-out effect
        yield return StartCoroutine(FadeOut());

        // Destroy the player or target object (if needed)
        Destroy(target);

        // Wait for a moment
        yield return new WaitForSeconds(1);

        // Teleport logic can go here (if needed)
        Debug.Log("Teleporting...");

        // Start fade-in effect
        yield return StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float duration = 1f; // Duration of the fade
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / duration);
            SetFadeAlpha(alpha); // Set fade to progress
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        float duration = 1f; // Duration of the fade
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = 1f - Mathf.Clamp01(elapsed / duration);
            SetFadeAlpha(alpha); // Reverse fade
            yield return null;
        }
    }

    private void SetFadeAlpha(float alpha)
    {
        Color color = fadeImage.color;
        color.a = alpha;
        fadeImage.color = color; // Update the alpha channel of the fade image
    }
}
