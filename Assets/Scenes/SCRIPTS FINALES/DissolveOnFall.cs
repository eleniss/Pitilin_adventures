using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveOnFall : MonoBehaviour
{
    //public float delayBeforeDissolve = 4.0f; // Tiempo de espera antes de disolver
    //public Material dissolveMaterial; // Material que tiene el shader de disolución

    //private bool hasLanded = false; // Indica si el objeto ya cayó al suelo
    //private float timer = 0f; // Temporizador para controlar el retraso
    //private Renderer objectRenderer; // Renderer del objeto

    //void Start()
    //{
    //    // Obtén el renderer del objeto
    //    objectRenderer = GetComponent<Renderer>();
    //}

    //void OnCollisionEnter(Collision collision)
    //{
    //    // Verifica si el objeto toca el suelo
    //    if (collision.gameObject.CompareTag("Ground")) // Asegúrate de que el suelo tiene el tag "Ground"
    //    {
    //        hasLanded = true;
    //    }
    //}

    //void Update()
    //{
    //    // Si el objeto ha caído, empieza el temporizador
    //    if (hasLanded)
    //    {
    //        timer += Time.deltaTime;

    //        if (timer >= delayBeforeDissolve)
    //        {
    //            // Cambia el material al shader de disolución
    //            objectRenderer.material = dissolveMaterial;

    //            // Controla el progreso de la disolución
    //            float dissolveAmount = Mathf.Min((timer - delayBeforeDissolve) / 2.0f, 1.0f); // Ajusta la velocidad de disolución
    //            objectRenderer.material.SetFloat("_DissolveAmount", dissolveAmount);

    //            // Si la disolución está completa, destruye el objeto
    //            if (dissolveAmount >= 1.0f)
    //            {
    //                Destroy(gameObject);
    //            }
    //        }
    //    }
    //}
    public Material dissolveMaterial; // Material con el shader de disolución.
    public string dissolveProperty = "_Dissolve"; // Nombre del parámetro en el shader de disolución.
    public float dissolveSpeed = 1f; // Velocidad del efecto dissolve.

    private Material originalMaterial; // Material inicial del objeto.
    private bool isOnGround = false;
    private float groundTime = 0f;
    private bool dissolving = false;
    private Renderer objRenderer;

    void Start()
    {
        // Obtén el Renderer del objeto para acceder a su material.
        objRenderer = GetComponent<Renderer>();

        // Guarda automáticamente el material inicial asignado al objeto.
        if (objRenderer != null)
        {
            originalMaterial = objRenderer.material;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Detectar si el objeto toca el suelo (puedes ajustar esta lógica según tu proyecto).
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    void Update()
    {
        // Si el objeto está en el suelo, empieza a contar el tiempo.
        if (isOnGround && !dissolving)
        {
            groundTime += Time.deltaTime;

            // Si han pasado 4 segundos, comienza el efecto de disolución.
            if (groundTime >= 4f)
            {
                StartCoroutine(StartDissolve());
                dissolving = true;
            }
        }
    }

    private System.Collections.IEnumerator StartDissolve()
    {
        // Cambia el material al de disolución.
        objRenderer.material = dissolveMaterial;

        // Inicializa el valor de disolución a 0.
        dissolveMaterial.SetFloat(dissolveProperty, 0f);

        float dissolveValue = 0f;

        // Incrementar gradualmente el valor de Dissolve.
        while (dissolveValue < 1f)
        {
            dissolveValue += Time.deltaTime * dissolveSpeed;
            dissolveMaterial.SetFloat(dissolveProperty, dissolveValue);
            yield return null; // Esperar hasta el siguiente frame.
        }

        // Destruir el objeto después de que se haya disuelto por completo.
        Destroy(gameObject);
    }
}
