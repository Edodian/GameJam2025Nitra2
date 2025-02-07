using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wires : MonoBehaviour
{
    // Start is called before the first frame update
    public bool CanWire = false;

    public GameObject undone;
    public GameObject done;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }

            private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player"){
            Debug.Log("Can wire!");
            CanWire = true;
        }
    }
                private void OnTriggerExit(Collider target)
    {
        if (target.tag == "Player"){
            Debug.Log("Cann't wire!");
            CanWire = false;
        }
    }

    public void wired()
    {
        done.SetActive(true);
        undone.SetActive(false);
    }
}
