using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOven : MonoBehaviour
{
    public GameObject visualEffect; // Assign your visual effect GameObject in the Inspector
    private Vector3 originalPosition;
    public float buttonPressDepth = 0.1f; // How far the button "presses"
    public float pressDuration = 0.2f;   // How long the button stays pressed

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
            StartCoroutine(PressButton());
        }
    }

    private System.Collections.IEnumerator PressButton()
    {
        // Move the button down to simulate a press
        transform.position = originalPosition - new Vector3(0, buttonPressDepth, 0);

        // Show the visual effect
        if (visualEffect != null)
        {
            visualEffect.SetActive(true);

            // Automatically disable the visual effect after a delay
            StartCoroutine(HideEffectAfterDelay(0.5f)); // Adjust duration if needed
        }

        yield return new WaitForSeconds(pressDuration);

        // Reset the button position
        transform.position = originalPosition;

        isPressed = false;
    }

    private System.Collections.IEnumerator HideEffectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (visualEffect != null)
        {
            visualEffect.SetActive(false);
        }
    }
}
