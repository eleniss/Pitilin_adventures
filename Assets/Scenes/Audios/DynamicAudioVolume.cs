using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicAudioVolume : MonoBehaviour
{
    public Transform player;
    public float maxVolumeDistance = 50f;
    public float maxDistance = 150f;
    public float maxVolume = 1f; // Volumen máximo, ahora es una variable pública.
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.volume = maxVolume; // Configurar el volumen inicial.
        }
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
                // Determine el volumen basado en los umbrales de distancia.
                if (distance <= maxVolumeDistance)
                {
                    audioSource.volume = maxVolume; // Volumen máximo dentro del rango cercano.
                }
                else
                {
                    // Disminuir gradualmente el volumen desde maxVolumeDistance a maxDistance.
                    float t = (distance - maxVolumeDistance) / (maxDistance - maxVolumeDistance);
                    audioSource.volume = Mathf.Lerp(maxVolume, 0f, t);
                }

                // Asegurarse de que el sonido se esté reproduciendo.
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
