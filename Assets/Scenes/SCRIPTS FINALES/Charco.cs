using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charco : MonoBehaviour
{
    public float slowSpeed = 40f; // Velocidad reducida en el charco
    public float normalSpeed = 94.4f; // Velocidad normal fuera del charco

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra es el jugador
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.SetSpeed(slowSpeed); // Reduce la velocidad
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el objeto que sale es el jugador
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.SetSpeed(normalSpeed); // Restaura la velocidad
            }
        }
    }
}
