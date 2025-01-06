using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBreads : MonoBehaviour
{

    public GoodBread foodBar;
    public ChangeSaturation _changeSaturation;
    public spawnObjects spawn;
    public GameObject[] pastries;
    public float WithGluten = 20f;
    public float NoGluten = -5f;
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
            _changeSaturation.CambiarSaturacion();
            spawn.spawnFood();
            foodBar.EatBread(WithGluten); 

        }
        else if (other.CompareTag("BadBread"))
        {
            Destroy(other.gameObject);
            foodBar.EatBread(NoGluten);
            _changeSaturation.ResetSat();
            spawn.spawnHater();

        }
    }

}
