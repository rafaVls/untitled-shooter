using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : Enemy
{
    public float stoppingDistance;
    public float retreatDistance;
    public float startTimeBetweenAttack;
    private float timeBetweenAttack;

    public GameObject limb;

    public Collector()
    {
        spawnChance = 0.15f;
        health = 2;
        speed = 4f;
    }

    void Start()
    {
        timeBetweenAttack = startTimeBetweenAttack;
    }

    void Update()
    {
        if (!playerTransform) return;
        Vector3 playerPos = playerTransform.position;

        // 3 different checks to act on player position
        // gotta clean these up later
        if (Vector2.Distance(transform.position, playerPos) > stoppingDistance)
        {
            //Get closer to player
            transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, playerPos) < stoppingDistance && Vector2.Distance(transform.position, playerPos) > retreatDistance)
        {
            //No movement
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, playerPos) < retreatDistance)
        {
            //retreat from player
            transform.position = Vector2.MoveTowards(transform.position, playerPos, -speed * Time.deltaTime);
        }

        if (timeBetweenAttack <= 0)
        {
            Instantiate(limb, transform.position, Quaternion.identity);
            timeBetweenAttack = startTimeBetweenAttack;
        }
        else 
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }
}
