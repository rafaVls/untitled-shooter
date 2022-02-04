using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health = 2;

    GameObject playerRef;
    Player playerInstance;
    Transform playerTransform;

    void Start() 
    {
        playerRef = GameObject.FindWithTag("Player");
        playerInstance = playerRef?.GetComponent<Player>();
        playerTransform = playerRef?.GetComponent<Transform>();
    }

    void Update() 
    {
        if (!playerTransform) return;
        if (health <= 0) Destroy(gameObject);

        Vector3 playerPos = playerTransform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
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
            
            if (playerInstance.health == 0) 
            {
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // this belongs in bullet.cs I think
            Destroy(gameObject);
        }
    }
}
