using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BasePlayer : StateMachine
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Vector2 moveDirection;
    public float moveSpeed;

    [Header("Jump")]
    //public float yVel;
    public int airJump;
    public int amountOfAirJumps;
    //public bool canAirJump = false;
    public float jumpHeight;
    public bool isJumping;

    [Header("GroundCheck")]
    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayerMask;

    [Header("Indicator")]
    public GameObject arrowSprite;
    public override BaseState DefaultState()
    {
        return new GroundMoveState(this);
    }
    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();

    }
    protected override void Start()
    {
        base.Start();
        airJump = amountOfAirJumps;
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayerMask);
        
        ProcessInputs();
    }
    void ProcessInputs()
    {
        float horizontal = Input.GetAxis("Horizontal");
        moveDirection = new Vector2(horizontal, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentState is GroundMoveState)
                ChangeState(new JumpState(this));

            if (currentState is FallState && airJump > 0)
            {
                ChangeState(new JumpState(this));
                airJump--;
            }
        }

    }

}
