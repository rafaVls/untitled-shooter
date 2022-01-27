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

    // Variables for possible dash mechanic code in Update()
    private float activeSpeed;
    public float dashSpeed;
    public float dashLength = .5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCooldownCounter;

    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        activeSpeed = speed;
    }

    void Update()
    {
        Vector2 moveInput = getMoveInput();
        moveVelocity = moveInput.normalized * speed;

        // I have tried over (i kid you not) dozen different iterations of a dash mechanic
        // This is the only code I've gotten to work that SOMEWHAT resembles a dash
        // ...except it's more like a teleport, but this is what I have for now
        // "Dash" mechanic still needs: Smoother transition, cooldown, and particle/sprite effect
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.AddForce(moveInput.normalized * 10000);
        }

        // Possible dash script, but non-functioning, needs tinkering, otherwise, scrap

        // if (Input.GetKeyDown(KeyCode.LeftShift))
        // {
        //     if (dashCooldownCounter <=0 && dashCounter <= 0)
        //     {
        //         activeSpeed = dashSpeed;
        //         dashCounter = dashLength;
        //     }
        // }

        // if (dashCounter > 0)
        // {
        //     dashCounter -= Time.deltaTime;

        //     if (dashCounter <= 0)
        //     {
        //         activeSpeed = speed;
        //         dashCooldownCounter = dashCooldown;
        //     }
        // }

        // if (dashCooldownCounter > 0)
        // {
        //     dashCooldownCounter -= Time.deltaTime;
        // }

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
    // if elses are a part of the c# lifestyle baby
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
