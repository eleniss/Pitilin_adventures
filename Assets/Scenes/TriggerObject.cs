using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject FallObject;
    private Rigidbody rb;



    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra al trigger es el Player
        if (other.CompareTag("Player"))
        {
            // Instancia y activa el objeto que caerá
            GameObject obj = Instantiate(FallObject, spawnPoint.position, spawnPoint.rotation);
             rb = obj.GetComponent<Rigidbody>();

            // Si tiene un Rigidbody, activa la gravedad para que caiga
            if (rb != null)
            {
                rb.useGravity = true; // Usa gravedad
                rb.AddForce(Vector3.down * 10000f, ForceMode.Acceleration); // Multiplica la aceleración de caída
            }
           gameObject.SetActive(false);
        }

    }

}
