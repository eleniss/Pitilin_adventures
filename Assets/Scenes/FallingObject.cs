using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si colisionó con el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Detiene el movimiento del objeto
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Opcional: desactiva el Rigidbody para evitar más movimientos
            rb.isKinematic = true;
        }
    }
}
