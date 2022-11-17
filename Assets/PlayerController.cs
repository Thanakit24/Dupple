using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : StateMachine
{
    [HideInInspector] public Rigidbody2D rb;
    public float moveSpeed;
    Vector2 moveDirection; 

    [Header("Jump")]
    //public float yVel;
    public float jumpHeight;
    public bool isJumping = false;

    [Header("GroundCheck")]
    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayerMask;

    protected override void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayerMask);
        ProcessInputs();
        //Debug.Log(isJumping);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

    void ProcessInputs()
    {
        float horizontal = Input.GetAxis("Horizontal");
        moveDirection = new Vector2(horizontal, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpHeight;
    }
}
