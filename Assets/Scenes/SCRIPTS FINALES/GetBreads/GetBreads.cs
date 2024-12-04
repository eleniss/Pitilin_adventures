using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBreads : MonoBehaviour
{

    public GoodBread foodBar;
    public ChangeSaturation _changeSaturation;
    private SpawnPastries spawn;
    public float WithGluten = 20f;
    public float NoGluten = -5f;
    public float Saturation = 20f;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("GoodBread"))
        {

            if (audioSource != null)
            {
                audioSource.Play();
            }


            Destroy(other.gameObject);
            _changeSaturation.CambioSaturacion(Saturation);
            foodBar.EatBread(WithGluten); 
            spawn.EatBread(WithGluten);

        }
        else if (other.CompareTag("BadBread"))
        {
            Destroy(other.gameObject);
            foodBar.EatBread(NoGluten);
        }
    }

}
