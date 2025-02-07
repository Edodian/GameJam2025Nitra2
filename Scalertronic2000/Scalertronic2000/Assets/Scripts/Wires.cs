using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wires : MonoBehaviour
{
    // Start is called before the first frame update
    public bool CanWire = false;

    public bool FungueW = false;

    public GameObject undone;
    public GameObject done;
    private GameObject gs;

    public ParticleSystem particles;
    void Start()
    {
        if (particles == null)
        {
            particles = GetComponentInChildren<ParticleSystem>();
            if (particles == null)
            {
                Debug.LogError("No ParticleSystem found in children of " + gameObject.name);
            }
        }
        gs = GameObject.FindWithTag("GameController");
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            Debug.Log("Can wire!");
            CanWire = true;
        }
    }
    private void OnTriggerExit(Collider target)
    {
        if (target.tag == "Player")
        {
            Debug.Log("Cann't wire!");
            CanWire = false;
        }
    }

    public void wired()
    {
        done.SetActive(true);
        undone.SetActive(false);
        particles.Play();
    }
    void Update()
    {
        if (CanWire = true & Input.GetKeyDown(KeyCode.F))
        {
            wired();
            FungueW = true;
            gs.GetComponent<GameController>().wiresfixed=true;
            Debug.Log("Wired!");
        }
    }
}