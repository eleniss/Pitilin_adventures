using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBreads : MonoBehaviour
{

    public GoodBread foodBar;
    public SpawnPastries spawn;
    public float WithGluten = 20f;
    public float NoGluten = -5f;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("GoodBread"))
        {
            Destroy(other.gameObject);
            foodBar.EatBread(WithGluten); 
            spawn.spawnFood();

        }
        else if (other.CompareTag("BadBread"))
        {
            Destroy(other.gameObject);
            foodBar.EatBread(NoGluten);
        }
    }
}
