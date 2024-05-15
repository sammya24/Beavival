using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaver_Behavior : MonoBehaviour
{
    private bool canMove = true;
    private Rigidbody2D rb;
    public float moveSpeed = 8f; // Adjust this value for desired movement speed.
    private SpriteRenderer spriteRenderer;

    public Vector2 lastPos;
    private void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // FixedUpdate is used for physics calculations
    void FixedUpdate()
    {
        if (canMove)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed;

            rb.velocity = movement;
            if (horizontalInput != 0 || verticalInput != 0)
            {
                lastPos = new Vector2(horizontalInput, verticalInput).normalized;
            }
                // Flip the sprite horizontally if moving left
                if (horizontalInput < 0)
            {
                spriteRenderer.flipX = false;
            }
            // Flip the sprite horizontally if moving right
            else if (horizontalInput > 0)
            {
                spriteRenderer.flipX = true;
            }

        }
        
    }
}