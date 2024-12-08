using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveOnFall : MonoBehaviour
{
    //public float delayBeforeDissolve = 4.0f; // Tiempo de espera antes de disolver
    //public Material dissolveMaterial; // Material que tiene el shader de disoluci�n

    //private bool hasLanded = false; // Indica si el objeto ya cay� al suelo
    //private float timer = 0f; // Temporizador para controlar el retraso
    //private Renderer objectRenderer; // Renderer del objeto

    //void Start()
    //{
    //    // Obt�n el renderer del objeto
    //    objectRenderer = GetComponent<Renderer>();
    //}

    //void OnCollisionEnter(Collision collision)
    //{
    //    // Verifica si el objeto toca el suelo
    //    if (collision.gameObject.CompareTag("Ground")) // Aseg�rate de que el suelo tiene el tag "Ground"
    //    {
    //        hasLanded = true;
    //    }
    //}

    //void Update()
    //{
    //    // Si el objeto ha ca�do, empieza el temporizador
    //    if (hasLanded)
    //    {
    //        timer += Time.deltaTime;

    //        if (timer >= delayBeforeDissolve)
    //        {
    //            // Cambia el material al shader de disoluci�n
    //            objectRenderer.material = dissolveMaterial;

    //            // Controla el progreso de la disoluci�n
    //            float dissolveAmount = Mathf.Min((timer - delayBeforeDissolve) / 2.0f, 1.0f); // Ajusta la velocidad de disoluci�n
    //            objectRenderer.material.SetFloat("_DissolveAmount", dissolveAmount);

    //            // Si la disoluci�n est� completa, destruye el objeto
    //            if (dissolveAmount >= 1.0f)
    //            {
    //                Destroy(gameObject);
    //            }
    //        }
    //    }
    //}
    public Material dissolveMaterial; // Material con el shader de disoluci�n.
    public string dissolveProperty = "_Dissolve"; // Nombre del par�metro en el shader de disoluci�n.
    public float dissolveSpeed = 1f; // Velocidad del efecto dissolve.

    private Material originalMaterial; // Material inicial del objeto.
    private bool isOnGround = false;
    private float groundTime = 0f;
    private bool dissolving = false;
    private Renderer objRenderer;

    void Start()
    {
        // Obt�n el Renderer del objeto para acceder a su material.
        objRenderer = GetComponent<Renderer>();

        // Guarda autom�ticamente el material inicial asignado al objeto.
        if (objRenderer != null)
        {
            originalMaterial = objRenderer.material;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Detectar si el objeto toca el suelo (puedes ajustar esta l�gica seg�n tu proyecto).
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    void Update()
    {
        // Si el objeto est� en el suelo, empieza a contar el tiempo.
        if (isOnGround && !dissolving)
        {
            groundTime += Time.deltaTime;

            // Si han pasado 4 segundos, comienza el efecto de disoluci�n.
            if (groundTime >= 4f)
            {
                StartCoroutine(StartDissolve());
                dissolving = true;
            }
        }
    }

    private System.Collections.IEnumerator StartDissolve()
    {
        // Cambia el material al de disoluci�n.
        objRenderer.material = dissolveMaterial;

        // Inicializa el valor de disoluci�n a 0.
        dissolveMaterial.SetFloat(dissolveProperty, 0f);

        float dissolveValue = 0f;

        // Incrementar gradualmente el valor de Dissolve.
        while (dissolveValue < 1f)
        {
            dissolveValue += Time.deltaTime * dissolveSpeed;
            dissolveMaterial.SetFloat(dissolveProperty, dissolveValue);
            yield return null; // Esperar hasta el siguiente frame.
        }

        // Destruir el objeto despu�s de que se haya disuelto por completo.
        Destroy(gameObject);
    }
}
