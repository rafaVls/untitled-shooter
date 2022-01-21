using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Transform player;

    void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update() 
    {
        Vector3 playerPos = player.position;
        transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
    }



}
