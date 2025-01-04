using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto colisionó con el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Detiene el movimiento del objeto
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true; // Hace que el objeto no sea afectado por la física
        }
    }
}


