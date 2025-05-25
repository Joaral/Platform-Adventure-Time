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
    private bool wasGrounded;
    public float jumpTimer;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.1f;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        jumpTimer = timeBetweenJumps;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Solo frenamos si acaba de tocar suelo
        if (isGrounded && !wasGrounded)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        if (isGrounded)
        {
            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0f)
            {
                Jump();
                jumpTimer = timeBetweenJumps;
            }
        }

        wasGrounded = isGrounded; // actualizar para el siguiente frame
    }

    void Jump()
    {
        animator.SetTrigger("Jump");
        Invoke(nameof(PerformJump), 0.8f);
    }
    void PerformJump()
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

        animator.SetTrigger("Hurt");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PLayerHealth>()?.TakeDamage(1);
        }
    }
}
