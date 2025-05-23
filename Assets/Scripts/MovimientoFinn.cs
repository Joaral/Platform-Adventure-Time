using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFinn : MonoBehaviour
{
    public SpriteRenderer sr;

    [Header("Movement")]
    public float speed;
    public float horizontal;
    public bool isMoving;
    public Rigidbody2D rb;
    
    [Header("Jump")]
    public bool isGrounded;
    public LayerMask ground;
    public Transform groundPos;
    public float groundRadius;
    public float jumpForce;

    public float gravedadExtraCaida;
    public float gravedadSaltoCorto;

    [Header("Attack")]
    public bool isAttacking;

    [Header("Animations")]
    public bool isDead;
    public bool isHitted;
    public Animator animator;

    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal > 0)
        {
            isMoving = true;
            sr.flipX = false;
        }
        else if (horizontal < 0)
        {
            isMoving = true;
            sr.flipX = true;
        }
        else
        {
            isMoving = false;
        }

            isGrounded = Physics2D.OverlapCircle(groundPos.position, groundRadius, ground);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        animator.SetBool("Moving", isMoving);
        animator.SetBool("Grounded", isGrounded);
    }

    void FixedUpdate()
    {
        
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
    }
}
