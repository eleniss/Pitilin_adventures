using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasAyuntamiento : MonoBehaviour
{
    public Transform leftDoor, rightDoor; // Referencias a las puertas
    public float openAngle = 90f; // Ángulo de apertura
    public float speed = 2f; // Velocidad de apertura y cierre
    private bool hasOpenedOnce = false; // Controla si las puertas ya se han abierto
    private Coroutine doorCoroutine; // Referencia al coroutine actual

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasOpenedOnce)
        {
            if (doorCoroutine != null) StopCoroutine(doorCoroutine); // Detiene cualquier animación en curso
            doorCoroutine = StartCoroutine(MoveDoors(-openAngle, openAngle)); // Abre las puertas
            hasOpenedOnce = true; // Marca que ya se han abierto una vez
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (doorCoroutine != null) StopCoroutine(doorCoroutine); // Detiene cualquier animación en curso
            doorCoroutine = StartCoroutine(MoveDoors(0, 0)); // Cierra las puertas
        }
    }

    private System.Collections.IEnumerator MoveDoors(float leftTargetAngle, float rightTargetAngle)
    {
        // Calcula las rotaciones objetivo
        Quaternion leftTarget = Quaternion.Euler(0, leftTargetAngle, 0);
        Quaternion rightTarget = Quaternion.Euler(0, rightTargetAngle, 0);

        while (Quaternion.Angle(leftDoor.localRotation, leftTarget) > 0.1f ||
               Quaternion.Angle(rightDoor.localRotation, rightTarget) > 0.1f)
        {
            leftDoor.localRotation = Quaternion.Lerp(leftDoor.localRotation, leftTarget, Time.deltaTime * speed);
            rightDoor.localRotation = Quaternion.Lerp(rightDoor.localRotation, rightTarget, Time.deltaTime * speed);
            yield return null;
        }

        // Ajusta las rotaciones finales
        leftDoor.localRotation = leftTarget;
        rightDoor.localRotation = rightTarget;

        doorCoroutine = null; // Resetea la referencia al coroutine actual
    }
}
