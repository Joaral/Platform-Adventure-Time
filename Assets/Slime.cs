using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float jumpForce = 5f;
    public float moveDirection = 1f;
    public float timeBetweenJumps = 1.5f;
    public int health = 3;

    public Rigidbody2D rb;
    public bool isGrounded = false;
    public float jumpTimer;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimer = timeBetweenJumps;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            // Al tocar suelo, detener el movimiento horizontal
            rb.velocity = new Vector2(0f, rb.velocity.y);

            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0f)
            {
                Jump();
                jumpTimer = timeBetweenJumps;
            }
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(moveDirection * 2f, jumpForce);

        // Cambia dirección
        moveDirection *= -1;

        // Voltea sprite
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
