using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorAttack : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyLimb();
            // Needs to be more like the player bullet, and not be destroyed after reaching player's last targeted position
        }
    }

    void DestroyLimb()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            DestroyLimb();
        }
    }
}
