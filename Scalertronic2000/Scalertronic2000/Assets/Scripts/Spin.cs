using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public GameObject target;   // The object to be rotated
    public float spinSpeed = 100f;  // Speed of the rotation

    void Update()
    {
        if (target != null)
        {
            // Rotate the target around its Y-axis (you can change the axis if needed)
            target.transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
        }
    }
}
