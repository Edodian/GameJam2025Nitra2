
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject paint_fragment;
    private GameObject gs;
    private void Start()
    {
        paint_fragment.SetActive(false);
        gs = GameObject.FindWithTag("GameController");
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            Debug.Log("Got point!");
            paint_fragment.SetActive(true);
            Destroy(gameObject);
        if (gs != null){
            gs.GetComponent<GameController>().PickUpPicked();
            Debug.Log("pickup triggered");
        }
        }
    }
}