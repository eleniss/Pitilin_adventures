using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Interactable
{
    public Transform weaponPos; // Posicion donde el arma se equipar�
    private bool isEquipped = false; // Estado del arma
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Transform originalParent;

    private void Start()
    {
        // Guarda la posici�n, rotaci�n y padre originales para restaurar si es necesario
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        originalParent = transform.parent;
    }

    protected override void Interact()
    {
        Equip();
    }

    private void Equip()
    {
        if (isEquipped) return;

        isEquipped = true;

        // Mueve el arma al WeaponHand
        transform.SetParent(weaponPos); // Establece el arma como hija del WeaponHand
        transform.localPosition = new Vector3(0.5f, -0.5f, 0f); // Ajusta la posici�n deseada
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f); // Ajusta la rotaci�n deseada
        GetComponent<Rigidbody>().isKinematic = true; // Desactiva f�sicas
        GetComponent<Collider>().enabled = false;    // Desactiva el collider, opcional

        Debug.Log("Arma equipada.");
    }

    public void Unequip()
    {
        if (!isEquipped) return;

        isEquipped = false;

        // Restablece el arma a su posici�n y rotaci�n originales
        transform.SetParent(originalParent);
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        GetComponent<Rigidbody>().isKinematic = false; // Reactiva f�sicas
        GetComponent<Collider>().enabled = true;      // Reactiva el collider

        Debug.Log("Arma desequipada.");
    }
}
