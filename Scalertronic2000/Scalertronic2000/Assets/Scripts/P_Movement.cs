using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Mouse : MonoBehaviour
{
  public float moveSpeed = 3.0f; // rýchlosť pohybu
  public float gravity = 9.81f;  // gravitácia, aby dopadol ak je vo vzduchu
  private CharacterController myController; // definovaný char controller
    public Vector3 movement;

  private Rigidbody rb;

  void Start () { // iniciujeme char. controller
   rb = gameObject.GetComponent<Rigidbody>();
  }
	
  void Update () {
    movement = new Vector3(Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));


    }

        void FixedUpdate()
    {
        moveCharacter(movement);
    }


    void moveCharacter(Vector3 direction)
    {
        rb.velocity = direction * moveSpeed;

        Debug.Log("hhh");
    }
}

