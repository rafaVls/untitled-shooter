using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy properties
    public float spawnChance { get; set; }
    public float speed { get; set; }
    public int health { get; set; }

    // Player references
    public GameObject playerRef
    {
        get => GameObject.FindWithTag("Player");
    }
    public Player playerInstance
    {
        get => playerRef?.GetComponent<Player>();
    }
    public Transform playerTransform
    {
        get => playerRef?.GetComponent<Transform>();
    }

    public Enemy()
    {
        health = 2;
        speed = 5f;
        spawnChance = 0.45f;
    }

    void Update() 
    {
        if (!playerTransform) return;
        if (health <= 0) Destroy(gameObject);

        Vector3 playerPos = playerTransform.position;
        ChasePlayer();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            playerInstance.health--;
            Destroy(gameObject);

            if (playerInstance.health <= 0) Destroy(other.gameObject);
        }

        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // this belongs in bullet.cs I think
            Destroy(gameObject);
        }
    }

    public void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, 
            playerTransform.position, 
            speed * Time.deltaTime);
    }

    public void RetreatFromPlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            playerTransform.position,
            -speed * Time.deltaTime
        );
    }
}
