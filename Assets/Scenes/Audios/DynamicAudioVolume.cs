using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicAudioVolume : MonoBehaviour
{
    public Transform player; 
    public float maxVolumeDistance = 50f; 
    public float maxDistance = 150f; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
  
    }

    void Update()
    {
        if (audioSource != null && player != null)
        {
            // Calcula la distancia entre el jugador y el objeto.
            float distance = Vector3.Distance(player.position, transform.position);

            // Si el jugador está dentro del rango máximo, ajusta el volumen.
            if (distance < maxDistance)
            {
                // Determine the volume based on the distance thresholds.
                if (distance <= maxVolumeDistance)
                {
                    audioSource.volume = 0.6f; // Full volume within the maxVolumeDistance.
                }
                else
                {
                    // Gradually decrease volume from maxVolumeDistance to maxDistance.
                    float t = (distance - maxVolumeDistance) / (maxDistance - maxVolumeDistance);
                    audioSource.volume = Mathf.Lerp(1f, 0f, t);
                }

                // Ensure the sound is playing.
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else
            {
                // Si está fuera de rango, detén el sonido.
                if (audioSource.isPlaying)
                {
                    audioSource.Pause();
                }
            }
        }
    }
}
