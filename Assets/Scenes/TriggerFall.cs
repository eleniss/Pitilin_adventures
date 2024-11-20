using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFall : MonoBehaviour
{
    public Transform TriggerFallObj;
    public GameObject FallObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ObjectFall();
        }
    }

    void ObjectFall()
    {
        // Instancia el objeto en la posición de caída
        GameObject objetoInstanciado = Instantiate(FallObject, TriggerFallObj.position, Quaternion.identity);

        // Si el objeto tiene un Rigidbody, se aplica fuerza para que caiga
        Rigidbody rb = objetoInstanciado.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false; // Asegura que el Rigidbody no esté cinemático
            //Fuerza de caida
            rb.AddForce(Vector3.down * 10f, ForceMode.Impulse); // Aplica una fuerza hacia abajo (puedes ajustar la magnitud)
        }
    }
}
