using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaEnemigo = 100;
    public Slider barraVidaEnemigo;
    public Puerta puerta; // Referencia al script de la puerta

    private bool enemigoMuerto = false; // Para evitar múltiples llamadas

    void Start()
    {
        if (barraVidaEnemigo != null)
            barraVidaEnemigo.maxValue = vidaEnemigo; // Configura el valor máximo de la barra
    }


    /*void Update()
    {
        barraVidaEnemigo.value = vidaEnemigo;
        //barraVidaPlayer.GetComponent<Slider>().value = vidaPlayer;

        if (vidaEnemigo <= 0)
        {
            MatarEnemigo();
        }
    }
    void MatarEnemigo()
    {
        puerta.AbrirPuerta(); // Llama a la función de apertura de la puerta
        Destroy(gameObject); // Destruye al enemigo

    }*/
    void Update()
    {
        if (barraVidaEnemigo != null)
            barraVidaEnemigo.value = vidaEnemigo;

        if (vidaEnemigo <= 0 && !enemigoMuerto)
        {
            MatarEnemigo();
        }
    }

    void MatarEnemigo()
    {
        enemigoMuerto = true; // Marca que el enemigo está muerto

        if (puerta != null)
        {
            puerta.AbrirPuerta(); // Llama al método para abrir la puerta
        }

        Destroy(gameObject); // Destruye al enemigo
    }
}

