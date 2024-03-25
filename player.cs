using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
     public float Speed = 5f;
    public Transform groundCheck;
    public float jumpForce = 10f;
    private float groundCheckRadius = 0.2f;
    private LayerMask groundLayer;

    private bool isGrounded;
    private Rigidbody2D rb;
    private float moveInput;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius, groundLayer);
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity =new Vector2(moveInput * Speed, rb.velocity.y);
    }

    private void Jump()
    {
        if (isGrounded == true)
        { 

           if(Input.GetButtonDown("Jump"))
           {
                rb.velocity = Vector2.up * jumpForce;
           }
        }
    }
}