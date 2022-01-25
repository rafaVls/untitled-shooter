using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Vector2 moveVelocity;
    Animator animator;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 moveInput = new Vector2(x, y);
        
        moveVelocity = moveInput.normalized * speed;
        triggerRunAnimation(x, y);
        flipSprite(x);
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
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
