using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : Enemy
{
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public GameObject limb;
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBetweenAttack = startTimeBetweenAttack;
    }

    void Update()
    {
        // 3 different checks to act on player position
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            //Get closer to player
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            //No movement
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            //retreat from player
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
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
