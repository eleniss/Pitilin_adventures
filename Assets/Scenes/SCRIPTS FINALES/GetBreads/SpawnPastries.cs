using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPastries : MonoBehaviour
{
    public GameObject[] pastries;
    private int Eatenpastrie;
    private int eaten = 0;
    void Start()
    {
        foreach(GameObject pastrie in pastries)
        {
           pastrie.SetActive(false);

        }
        
    }

    public void spawnFood()
    {
        if(eaten < pastries.Length)
        {
            pastries[eaten].SetActive(true);
        }
    }

}
