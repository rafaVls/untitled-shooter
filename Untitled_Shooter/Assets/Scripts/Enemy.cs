using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    GameObject playerRef;
    Player playerInstance;
    Transform playerTransform;
    public int health = 2;

    void Start() 
    {
        playerRef = GameObject.FindWithTag("Player");
        playerInstance = playerRef?.GetComponent<Player>();
        playerTransform = playerRef?.GetComponent<Transform>();
    }

    void Update() 
    {
        if (playerTransform)
        {
            Vector3 playerPos = playerTransform.position;
            transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(int meleeDamage)
    {
        health -= meleeDamage;
        Debug.Log("damage taken");
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
        else if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // this belongs in bullet.cs I think
            Destroy(gameObject);
        }
    }
}
