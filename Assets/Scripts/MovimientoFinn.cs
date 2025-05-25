using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFinn : MonoBehaviour
{
    public Vector3 t;

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
    public GameObject attackHitboxPrefab;
    public Transform attackPoint;
    public float attackCooldown = 0.5f;

    private float nextAttackTime = 0f;

    [Header("Animations")]
    public bool isDead;
    public bool isHitted;
    public Animator animator;

    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        t = transform.localScale;
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal > 0)
        {
            isMoving = true;
            t.x = 1;
            transform.localScale = t;
        }
        else if (horizontal < 0)
        {
            isMoving = true;
            t.x = -1;
            transform.localScale = t;
        }
        else
        {
            isMoving = false;
        }

            isGrounded = Physics2D.OverlapCircle(groundPos.position, groundRadius, ground);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


        if (Time.time >= nextAttackTime && Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
        animator.SetBool("Moving", isMoving);
        animator.SetBool("Grounded", isGrounded);
    }

    void FixedUpdate()
    {
        
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Instantiate(attackHitboxPrefab, attackPoint.position, attackPoint.rotation);
    }
}
