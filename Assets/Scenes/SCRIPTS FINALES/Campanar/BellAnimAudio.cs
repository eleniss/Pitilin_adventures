using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellAnimAudio : MonoBehaviour
{
    public Animator animator;
    public GameObject bell;
    public AudioSource audioSource; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("isBell");
            audioSource.Play(); 

        }
    }
}
