using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveOnFall : MonoBehaviour
{
    public float delayBeforeDissolve = 4.0f; // Tiempo de espera antes de disolver
    public Material dissolveMaterial; // Material que tiene el shader de disolución

    private bool hasLanded = false; // Indica si el objeto ya cayó al suelo
    private float timer = 0f; // Temporizador para controlar el retraso
    private Renderer objectRenderer; // Renderer del objeto

    void Start()
    {
        // Obtén el renderer del objeto
        objectRenderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto toca el suelo
        if (collision.gameObject.CompareTag("Ground")) // Asegúrate de que el suelo tiene el tag "Ground"
        {
            hasLanded = true;
        }
    }

    void Update()
    {
        // Si el objeto ha caído, empieza el temporizador
        if (hasLanded)
        {
            timer += Time.deltaTime;

            if (timer >= delayBeforeDissolve)
            {
                // Cambia el material al shader de disolución
                objectRenderer.material = dissolveMaterial;

                // Controla el progreso de la disolución
                float dissolveAmount = Mathf.Min((timer - delayBeforeDissolve) / 2.0f, 1.0f); // Ajusta la velocidad de disolución
                objectRenderer.material.SetFloat("_DissolveAmount", dissolveAmount);

                // Si la disolución está completa, destruye el objeto
                if (dissolveAmount >= 1.0f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
