using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public Light lightSource;      
    public float activationDistance = 5f; 
    public float maxDistance = 10f; 

    private Transform player;      

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        lightSource.enabled = false;

    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, lightSource.transform.position);
        Debug.Log($"Distancia al jugador: {distance}");
        Debug.Log($"Luz antes: {lightSource.enabled}");

        if (distance <= activationDistance)
        {
            lightSource.enabled = true;
            Debug.Log($"Luz en posicion: {lightSource.enabled}");
        }
        else if (distance > maxDistance)
        {
            lightSource.enabled = false; 
        }
        else
        {
            float intensity = Mathf.Lerp(0f, 10000f, (maxDistance - distance) / maxDistance);
            lightSource.intensity = intensity;
        }
    }
}
