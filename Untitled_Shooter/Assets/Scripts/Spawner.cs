using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnSpots;
    public float timeBetweenSpawns;
    public float startTimeBetweenSpawns;

    void Start() 
    {
        timeBetweenSpawns = startTimeBetweenSpawns;
    }

    void Update() 
    {
        if(timeBetweenSpawns <= 0) 
        {
            int randomPosition = Random.Range(0, spawnSpots.Length - 1);
            Instantiate(enemy, spawnSpots[randomPosition].position, Quaternion.identity);
            timeBetweenSpawns = startTimeBetweenSpawns;
        }
        else 
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }

}
