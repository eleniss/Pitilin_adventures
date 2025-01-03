using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public Light lightSource;      // Reference to the Light component
    public float activationDistance = 5f; // Distance at which the light turns on
    public float maxDistance = 10f; // Maximum distance for the light to stay on

    private Transform player;      // Reference to the player transform

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // Assuming player has the "Player" tag
    }

    void Update()
    {
        // Get the distance between the player and the light source
        float distance = Vector3.Distance(player.position, lightSource.transform.position);

        // If the player is within the activation range, turn on the light
        if (distance <= activationDistance)
        {
            lightSource.enabled = true; // Turn on the light
        }
        // If the player is farther than maxDistance, turn off the light
        else if (distance > maxDistance)
        {
            lightSource.enabled = false; // Turn off the light
        }
        else
        {
            // Optionally, fade light intensity based on distance
            float intensity = Mathf.Lerp(0f, 1f, (maxDistance - distance) / maxDistance);
            lightSource.intensity = intensity;
        }
    }
}
