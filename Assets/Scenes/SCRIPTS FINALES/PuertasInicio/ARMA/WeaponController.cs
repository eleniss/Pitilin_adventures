using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour //va a encargarse de disparar y apuntar
{
    public Camera playerCamera;      // Cámara del jugador
    public Transform firePoint;      // Punto de disparo
    public GameObject bulletPrefab;  // Prefab de la bala
    public float bulletSpeed = 20f;  // Velocidad de la bala
    public float fireRate = 0.5f;    // Tiempo entre disparos

    private float nextFireTime = 0f; // Marca de tiempo para controlar el rate de disparo
    private bool isAiming = false;   // Indica si el jugador está apuntando

    void Update()
    {
        Aim();   // Controla si el jugador está apuntando
        Shoot(); // Maneja el disparo
    }

    private void Aim()
    {
        if (Input.GetMouseButton(1)) // Click derecho para apuntar
        {
            isAiming = true;
            playerCamera.fieldOfView = 40f; // Reducir FOV al apuntar
        }
        else
        {
            isAiming = false;
            playerCamera.fieldOfView = 60f; // Restaurar FOV normal
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime) // Click izquierdo para disparar
        {
            nextFireTime = Time.time + fireRate; // Actualizar el tiempo para el próximo disparo

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Crear la bala
            Rigidbody rb = bullet.GetComponent<Rigidbody>(); // Obtener el Rigidbody de la bala
            rb.velocity = firePoint.forward * bulletSpeed;   // Aplicar velocidad a la bala

            Debug.Log("Disparo realizado.");
            Destroy(bullet, 5f); // Eliminar la bala tras 5 segundos
        }
    }
}
