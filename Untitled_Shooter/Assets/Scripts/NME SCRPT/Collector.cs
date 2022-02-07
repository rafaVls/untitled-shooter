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

        HandleMovement();
        HandleAttack();
    }

    void HandleMovement()
    {
        Vector3 playerPos = playerTransform.position;
        bool farFromPlayer = Vector2.Distance(transform.position, playerPos) <= stoppingDistance;
        bool withinRetreat = Vector2.Distance(transform.position, playerPos) <= retreatDistance;

        // this is equivalent to not moving
        if (farFromPlayer && !withinRetreat) return;
        if (!farFromPlayer) ChasePlayer();
        if (withinRetreat) RetreatFromPlayer();
    }

    void HandleAttack()
    {
        if (timeBetweenAttack > 0) 
        {
            timeBetweenAttack -= Time.deltaTime;
            return;
        }

        Instantiate(limb, transform.position, Quaternion.identity);
        timeBetweenAttack = startTimeBetweenAttack;
    }
}
