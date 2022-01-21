using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float timeBetweenSpawns;
    public float startTimeBetweenSpawns;
    List<Transform> spawnSpots = new();

    void Start() 
    {
        // Adding all children and removing the spawner (which gets added for some reason)
        spawnSpots.AddRange(GetComponentsInChildren<Transform>());
        spawnSpots.Remove(spawnSpots[0]);
        timeBetweenSpawns = startTimeBetweenSpawns;
    }

    void Update() 
    {
        if(timeBetweenSpawns <= 0) 
        {
            int randomPosition = Random.Range(0, spawnSpots.Count - 1);
            Instantiate(enemy, spawnSpots[randomPosition].position, Quaternion.identity);
            timeBetweenSpawns = startTimeBetweenSpawns;
        }
        else 
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }
}
