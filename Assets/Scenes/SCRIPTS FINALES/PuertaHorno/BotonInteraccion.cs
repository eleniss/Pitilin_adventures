using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotonInteraccion : MonoBehaviour
{
    public GameObject enemigo; // Referencia al enemigo
    public Puerta puerta; // Referencia al script de la puerta
    public TMPro.TextMeshProUGUI textoInteraccion; // Para TextMeshPro
    public GameObject barraVidaPlayer; // Referencia a la barra de vida del jugador
    private bool jugadorDentro = false; // Indica si el jugador está dentro del trigger

    void Start()
    {
        if (enemigo != null)
            enemigo.SetActive(false); // Asegura que el enemigo esté desactivado al inicio

        if (barraVidaPlayer != null)
            barraVidaPlayer.SetActive(false); // Asegura que la barra de vida esté desactivada al inicio

        if (textoInteraccion != null)
            textoInteraccion.gameObject.SetActive(false); // Oculta el texto al inicio
    }

    void Update()
    {
        if (jugadorDentro && Input.GetKeyDown(KeyCode.P) && !puerta.EstaAbierta())
        {
            ActivarEnemigo();
        }
    }

    void ActivarEnemigo()
    {
        if (enemigo != null)
            enemigo.SetActive(true); // Activa al enemigo

        if (barraVidaPlayer != null)
            barraVidaPlayer.SetActive(true); // Activa la barra de vida del jugador

        if (textoInteraccion != null)
            textoInteraccion.gameObject.SetActive(false); // Oculta el texto

        jugadorDentro = false; // Desactiva la posibilidad de interacción
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !puerta.EstaAbierta())
        {
            jugadorDentro = true;

            if (textoInteraccion != null)
                textoInteraccion.gameObject.SetActive(true); // Muestra el texto
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;

            if (textoInteraccion != null)
                textoInteraccion.gameObject.SetActive(false); // Oculta el texto
        }
    }
}