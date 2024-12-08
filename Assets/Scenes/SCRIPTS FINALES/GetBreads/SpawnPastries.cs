using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPastries : MonoBehaviour
{
    public GameObject[] pastries;
    public GameObject NoPastrie;
    public Transform[] _spawnPastries;
    public Transform[] _spawnHater;

    public void spawnFood()
    {
        int randomIndex = Random.Range(0, pastries.Length);
        int randomSpawn = Random.Range(0, _spawnPastries.Length);
        if( pastries[randomIndex] != null && _spawnPastries != null)
        {
            Instantiate(pastries[randomIndex], _spawnPastries[randomSpawn].position, _spawnPastries[randomSpawn].rotation);
        }

    }

    public void spawnHater()
    {
        //int randomIndex = Random.Range(0, NoPastrie.Length);
        int randomSpawn = Random.Range(0, _spawnHater.Length);
        if (NoPastrie != null && _spawnPastries != null)
        {
            Instantiate(NoPastrie, _spawnHater[randomSpawn].position, _spawnHater[randomSpawn].rotation);

        }
    }


}
