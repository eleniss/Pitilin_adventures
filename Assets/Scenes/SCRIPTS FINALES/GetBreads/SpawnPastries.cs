using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPastries : MonoBehaviour//, ITakeBread
{
    public GameObject[] pastries;
    public Vector3 max, min;
    private int Eatenpastrie;
    private int eaten = 0;


    //void Start()
    //{
    //    foreach(GameObject pastrie in pastries)
    //    {
    //       pastrie.SetActive(false);

    //    }

    //}
    //public void EatBread(float amount)
    //{
    //    if (amount > 0)
    //    {
    //        spawnFood();
    //    }
    //}

    public void spawnFood()
    {
        //if (eaten < pastries.Length)
        //{
        //    pastries[eaten].SetActive(true);
        //}
        float x = Random.Range(min.x, max.x);
        float z = Random.Range(-min.z, max.z);  
        int randomIndex = Random.Range(0, pastries.Length);
        Vector3 randomSpawnPos = new Vector3(x, max.y, z);
        Instantiate(pastries[randomIndex], randomSpawnPos, Quaternion.identity);

    }

}
