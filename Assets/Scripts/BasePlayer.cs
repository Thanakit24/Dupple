using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Vector2 moveDirection;
    public float moveSpeed;

    [Header("Jump")]
    //public float yVel;
    public int jumpsLeft;
    public int amountOfJumps;
    public float jumpHeight;
    public bool isJumping = false;

    [Header("GroundCheck")]
    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayerMask;

    public virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public virtual void Start()
    {
        jumpsLeft = amountOfJumps;
    }
    // Update is called once per frame
    public virtual void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayerMask);
        if (isGrounded)
        {
            jumpsLeft = amountOfJumps;
            isJumping = false; 
        }

        ProcessInputs();
    }

    public virtual void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }
    void ProcessInputs()
    {
        float horizontal = Input.GetAxis("Horizontal");
        moveDirection = new Vector2(horizontal, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded && jumpsLeft > 0)
        {
            Jump();
            isJumping = true;
        }
        else if (Input.GetButtonDown("Jump") && isJumping && jumpsLeft > 0)
        {
            Jump();
        }

    }
    void Jump()
    {
        rb.velocity = Vector2.up * jumpHeight;
        jumpsLeft--;
    }

}
