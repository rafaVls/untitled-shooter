using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int health = 10;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;
    Vector2 moveVelocity;

    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 moveInput = getMoveInput();
        moveVelocity = moveInput.normalized * speed;
        triggerRunAnimation(moveInput.x, moveInput.y);
        flipSprite(moveInput.x);
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    Vector2 getMoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        return new Vector2(x, y);
    }

    void triggerRunAnimation(float hor, float vert)
    {
        float playerDir = hor == 0 ? vert : hor;
        animator.SetFloat("Speed", Mathf.Abs(playerDir * speed));
    }

    // investigate if this function can be simplified, I don't like if elses
    void flipSprite(float horizontalDir)
    {
        if (horizontalDir > 0) 
        {
            sr.flipX = false;
        }
        else if (horizontalDir < 0)
        {
            sr.flipX = true;
        }
    }
}
