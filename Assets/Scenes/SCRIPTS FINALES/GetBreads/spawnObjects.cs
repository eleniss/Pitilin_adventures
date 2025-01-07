using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObjects : MonoBehaviour
{
    public GameObject[] pastries;
    public Transform[] _spawnPastries;
    public GameObject NoPastrie;
    public Transform[] _spawnHater;

    private List<GameObject> spawnedPastries = new List<GameObject>();
    private List<GameObject> spawnedHaters = new List<GameObject>();

    public void spawnFood()
    {
        int randomIndex = Random.Range(0, pastries.Length);
        int randomSpawn = Random.Range(0, _spawnPastries.Length);
        if (pastries[randomIndex] != null && _spawnPastries[randomSpawn] != null)
        {
            GameObject newPastry = Instantiate(pastries[randomIndex], _spawnPastries[randomSpawn].position, _spawnPastries[randomSpawn].rotation);
            spawnedPastries.Add(newPastry);
        }
    }

    public void spawnHater()
    {
        int randomSpawn = Random.Range(0, _spawnHater.Length);
        if (NoPastrie != null && _spawnHater[randomSpawn] != null)
        {
            GameObject newHater = Instantiate(NoPastrie, _spawnHater[randomSpawn].position, _spawnHater[randomSpawn].rotation);
            spawnedHaters.Add(newHater); 
        }
    }

    public void RemoveAllHaters()
    {
        foreach (GameObject hater in spawnedHaters)
        {
            if (hater != null)
            {
                Destroy(hater);
            }
        }
        spawnedHaters.Clear(); 
    }

    public void RemoveAllPastries()
    {
        foreach (GameObject pastry in spawnedPastries)
        {
            if (pastry != null)
            {
                Destroy(pastry);
            }
        }
        spawnedPastries.Clear(); 
    }
}
