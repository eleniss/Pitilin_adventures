using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Vector3 posicionAbierta; // Posición a la que se moverá la puerta
    public float velocidadApertura = 50.0f; // Velocidad del deslizamiento
    private bool abrirPuerta = false; // Controla si la puerta debe abrirse

    void Update()
    {
        if (abrirPuerta)
        {
            // Mueve la puerta hacia la posición abierta
            transform.position = Vector3.MoveTowards(transform.position, posicionAbierta, velocidadApertura * Time.deltaTime);

            // Verifica si la puerta ha llegado a la posición abierta
            if (Vector3.Distance(transform.position, posicionAbierta) < 0.01f)
            {
                abrirPuerta = false; // Detiene el movimiento
            }
        }
    }

    public void AbrirPuerta()
    {
        abrirPuerta = true; // Indica que la puerta debe abrirse
    }

    public bool EstaAbierta()
    {
        // Verifica si la puerta está completamente abierta o en proceso de abrirse
        return abrirPuerta || Vector3.Distance(transform.position, posicionAbierta) < 0.01f;
    }
}
