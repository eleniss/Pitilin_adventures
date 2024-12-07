using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoEnemigo : MonoBehaviour
{
    public int damageEnemigo = 10;
    public float activeTime = 1.0f; // Tiempo en que el prefab puede causar daño tras ser disparado
    private bool isActive = true;

    private void Start()
    {
        // Desactiva el daño después del tiempo definido
        Invoke("DesactivateDamage", activeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isActive && collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<VidaEnemigo>().vidaEnemigo -= damageEnemigo;
            isActive = false; // Desactiva el prefab tras causar daño
        }
    }

    private void DesactivateDamage()
    {
        isActive = false; // Desactiva el daño después del tiempo
    }
}
