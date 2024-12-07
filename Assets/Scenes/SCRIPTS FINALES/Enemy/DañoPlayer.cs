using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoPlayer : MonoBehaviour
{
    public int damagePlayer = 10;
    //public GameObject Player;
    public float activeTime = 1.0f; // Tiempo en que el prefab puede causar daño tras ser disparado
    private bool isActive = true;

    private void Start()
    {
        // Desactiva el daño después del tiempo definido
        Invoke("DesactivateDamage", activeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.CompareTag("Player"))
        {
            // Accede al script "VidaPlayer" del Player y resta vida
            collision.gameObject.GetComponent<VidaPlayer>().vidaPlayer -= damagePlayer;
        }*/
        if (isActive && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<VidaPlayer>().vidaPlayer -= damagePlayer;
            isActive = false; // Desactiva el prefab tras causar daño
        }
    }

    private void DesactivateDamage()
    {
        isActive = false; // Desactiva el daño después del tiempo
    }

}
