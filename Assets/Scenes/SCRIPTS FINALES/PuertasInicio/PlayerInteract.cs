using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour //script detecta elementos interactuables
{
    private Camera cam;

    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private PlayerUI playerUI;
    [SerializeField]
    private InputManager inputManager;
    private Weapon equippedWeapon;
    public Transform weaponPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
        
    }

    // Update is called once per frame
    void Update() 
    {//el Ray detecta colisiones y almacena info de la colisión. Es un rayo que va recto, por eso el transform y forward: estamos creando el rayo que detecta las colisiones (infinito si se deja tal cual)
        playerUI.UpdateText(string.Empty); //cuando no apunte a lo que es interactuable, no hay texto
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitInfo; //variable que almacena info de la colision
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        { //dentro verificamos si tenemos delante un objeto interactivo (layer de interactable)
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                
                playerUI.UpdateText(interactable.mensaje); //cuando tengamos delante un objeto interactivo aparecerá el mensaje "E para abrir" o lo que sea
                if (inputManager.gameplay.Interact.triggered)
                {
                    interactable.BaseInteract();
                    //if (interactable is Weapon weapon)
                    //{
                    //    EquipWeapon(weapon);
                    //}
                }
            }

        }
    }
    private void EquipWeapon(Weapon weapon)
    {
        if (equippedWeapon != null) return;

        equippedWeapon = weapon;
        weapon.weaponPos = transform; // Mano del jugador como referencia
        Debug.Log("Arma recogida.");
    }
}
