using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFinn : MonoBehaviour
{

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
    [Header("Attack")]
    public bool isAttacking;

    [Header("Animations")]
    public bool isDead;
    public bool isHitted;

    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");


    }

    void FixedUpdate()
    {
        
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
    }
}
