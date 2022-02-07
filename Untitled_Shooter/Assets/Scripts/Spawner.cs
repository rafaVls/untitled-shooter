using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float startTimeBetweenSpawns;
    public float timeBetweenSpawns;
    public int numberOfEnemies = 10;

    public GameObject[] enemyTypes;
    private List<Transform> spawnSpots = new();
    private List<Enemy> enemyScripts = new();
    private List<GameObject> enemies = new();

    void Start() 
    {
        // Adding all children and removing the spawner (which gets added for some reason)
        spawnSpots.AddRange(GetComponentsInChildren<Transform>());
        spawnSpots.Remove(spawnSpots[0]);
        timeBetweenSpawns = startTimeBetweenSpawns;

        foreach (GameObject type in enemyTypes)
        {
            Enemy script = type.GetComponent<Enemy>();
            enemyScripts.Add(script);
        }

        for (int i = 0; i < numberOfEnemies; i++)
        {
            int randomNumber = CalculateSpawn(enemyScripts);
            enemies.Add(enemyTypes[randomNumber]);
        }
    }

    void Update() 
    {
        if (enemies.Count <= 0) return;
        if (timeBetweenSpawns > 0)
        {
            timeBetweenSpawns -= Time.deltaTime;
            return;
        }
        timeBetweenSpawns = startTimeBetweenSpawns;

        int randomPosition = Random.Range(0, spawnSpots.Count - 1);
        Vector3 spawnerPos = spawnSpots[randomPosition].position;
        SpawnRandom(enemies, spawnerPos);
    }
    
    int CalculateSpawn(List<Enemy> enemyList)
    {
        float total = 0;

        foreach (Enemy enemy in enemyList)
        {
            total += enemy.spawnChance;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < enemyList.Count; i++)
        {
            float sc = enemyScripts[i].spawnChance;

            if (randomPoint < sc) return i;
            else randomPoint = sc;
        }
        return enemyTypes.Length - 1;
    }

    void SpawnRandom(List<GameObject> toSpawn, Vector3 spawnPos)
    {
        int randomIndex = Random.Range(0, toSpawn.Count);

        Instantiate(toSpawn[randomIndex], spawnPos, Quaternion.identity);
        toSpawn.RemoveAt(randomIndex);
    }
}
