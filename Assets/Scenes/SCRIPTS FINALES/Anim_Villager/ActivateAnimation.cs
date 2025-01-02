using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator AnimationController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AnimationController.SetBool("Entra_trigger", true);
            Debug.Log("Animacion activada");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AnimationController.SetBool("Entra_trigger", false);
            Debug.Log("Animacion desactivada");
        }
    }
}
