using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour
{
    public float bounceForce = 10f; // Fuerza del salto
    private AudioSource audioSource; // Referencia al componente AudioSource

    void Start()
    {
        // Obtener el componente AudioSource del objeto
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que colisionó tiene un Rigidbody
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Aplica una fuerza hacia arriba
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Resetea la velocidad vertical
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }


}
