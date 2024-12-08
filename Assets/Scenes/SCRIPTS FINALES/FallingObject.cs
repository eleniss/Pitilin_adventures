using System.Collections;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private Rigidbody rb;
    /*private Material dissolveMaterial; // Material que controla el dissolve
    private float dissolveStrength = 0f; // Valor inicial del dissolve
    private float dissolveSpeed = 0.5f; // Velocidad de incremento de dissolveStrength
    private bool isDissolving = false; // Controla si el efecto de disolución está activo*/

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Suponemos que el material está en el mismo objeto
        Renderer renderer = GetComponent<Renderer>();
        /*if (renderer != null)
        {
            dissolveMaterial = renderer.sharedMaterial; // Usamos sharedMaterial

            Debug.Log("Material utilizado: " + dissolveMaterial.name);
        }*/
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
            //PREUBA DE HACER DISSOLVE AFTER 5s
            // Inicia el proceso de disolución después de 5 segundos
            //StartCoroutine(StartDissolveAfterDelay(5f));
        }
    }

    /*IEnumerator StartDissolveAfterDelay(float delay)
    {
        // Espera los 5 segundos
        yield return new WaitForSeconds(delay);

        // Comienza la disolución
        isDissolving = true;
    }

    void Update()
    {
        // Si debe empezar a disolverse y el dissolveStrength no ha llegado a 1
        if (isDissolving && dissolveStrength < 1f)
        {
            dissolveStrength += Time.deltaTime * dissolveSpeed;
            //dissolveStrength = Mathf.Clamp01(dissolveStrength); // Asegurarse de que no pase de 1

            // Aplicar el valor de dissolve al material
            if (dissolveMaterial != null)
            {
                dissolveMaterial.SetFloat("_DissolveStrength", dissolveStrength);
            }
        }
    }*/
}

