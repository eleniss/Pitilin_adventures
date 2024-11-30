using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject FallObject;
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra al trigger es el Player
        if (other.CompareTag("Player"))
        {
            // Instancia y activa el objeto que caer�
            GameObject obj = Instantiate(FallObject, spawnPoint.position, spawnPoint.rotation);
            Rigidbody rb = obj.GetComponent<Rigidbody>();

            // Si tiene un Rigidbody, activa la gravedad para que caiga
            if (rb != null)
            {
                rb.useGravity = true; // Usa gravedad
                rb.AddForce(Vector3.down * 8000f, ForceMode.Acceleration); // Multiplica la aceleraci�n de ca�da
            }
            gameObject.SetActive(false);
        }
    }
    private IEnumerator StartDissolveAfterDelay(DissolveEffect dissolveEffect, float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for 2 seconds
        dissolveEffect.StartDissolve(1f); // Start dissolving over 1 second
    }

}
