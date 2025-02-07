using UnityEngine;

public class Speec_Start : MonoBehaviour
{
    public Canvas canvas; 

    void Start()
    {
        if (canvas == null)
        {
            canvas = GetComponent<Canvas>();
            if (canvas == null)
            {
                Debug.LogError("Canvas is missing on " + gameObject.name);
            }
        }
    }
    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Player"))
            Debug.Log("Finish");
        if (canvas != null)
        {
            canvas.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Canvas reference is NULL. Assign it in the Inspector.");
        }
    }
}
