using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int health = 10;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    private Vector2 moveVelocity;

    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 moveInput = GetMoveInput();
        moveVelocity = moveInput.normalized * speed;

        // "Dash" mechanic still needs: Smoother transition, cooldown, and particle/sprite effect
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.AddForce(moveInput.normalized * 10000);
        }

        TriggerRunAnimation(moveInput.x, moveInput.y);
        FlipSprite(moveInput.x);
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    Vector2 GetMoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        return new Vector2(x, y);
    }

    void TriggerRunAnimation(float hor, float vert)
    {
        float playerDir = hor == 0 ? vert : hor;
        animator.SetFloat("Speed", Mathf.Abs(playerDir * speed));
    }

    // investigate if this function can be simplified, I don't like if elses
    // if elses are a part of the c# lifestyle baby
    void FlipSprite(float horizontalDir)
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
