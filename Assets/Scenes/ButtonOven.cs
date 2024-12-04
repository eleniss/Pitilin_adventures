using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOven : MonoBehaviour
{
    public GameObject visualEffect; // Assign your visual effect GameObject in the Inspector
    private Vector3 originalPosition;
    public float buttonPressDepth = 1f; // How far the button "presses"
    public float pressDuration = 0.2f;   // How long the button stays pressed
    public Transform spawnPoint;
    private bool isPressed = false;

    private void Start()
    {
        // Store the original position of the button
        originalPosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (!isPressed)
        {
            isPressed = true;
            PressButton();
        }
    }

    private void PressButton()
    {
        // PRESIÓN BOTON
        transform.position = originalPosition - new Vector3(0, buttonPressDepth, 0);

       
        if (visualEffect != null)
        {
            GameObject vfx = Instantiate(visualEffect, spawnPoint.position, spawnPoint.rotation);
            
        }
        // Reset button position
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
