using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOven : MonoBehaviour
{
    public GameObject visualEffect_Fire;
    public GameObject visualEffect_Firework1;
    public GameObject visualEffect_Firework2;

    private Vector3 originalPosition;
    public float buttonPressDepth = 1f; 
    public float pressDuration = 0.2f;   
    public Transform spawnPoint_Fire;
    public Transform spawnPoint_Firework1;
    public Transform spawnPoint_Firework2;

    private bool isPressed = false;

    private void Start()
    {
        // Store the original position of the button
        originalPosition = transform.position;
    }

    private void Update()
    {
        // Detectar si se presiona la tecla "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Evitar que el botón sea presionado múltiples veces mientras ya está en proceso
            if (!isPressed)
            {
                isPressed = true;
                PressButton();
            }
        }
    }

    //private void OnMouseDown()
    //{
    //    if (!isPressed)
    //    {
    //        isPressed = true;
    //        PressButton();
    //    }
    //}

    private void PressButton()
    {
            // PRESIÓN BOTON
            transform.position = originalPosition - new Vector3(0, buttonPressDepth, 0);

            if (visualEffect_Fire != null && visualEffect_Firework1 != null && visualEffect_Firework2 != null)
            {
                GameObject vfx = Instantiate(visualEffect_Fire, spawnPoint_Fire.position, spawnPoint_Fire.rotation);
                GameObject vfx_fi1 = Instantiate(visualEffect_Firework1, spawnPoint_Firework1.position, spawnPoint_Firework1.rotation);
                GameObject vfx_fi2 = Instantiate(visualEffect_Firework2, spawnPoint_Firework2.position, spawnPoint_Firework2.rotation);
            }

            transform.position = originalPosition;

            isPressed = false;
        

        
    }

    /*private System.Collections.IEnumerator HideEffectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (visualEffect != null)
        {
            visualEffect.SetActive(false);
        }
    }*/
}
