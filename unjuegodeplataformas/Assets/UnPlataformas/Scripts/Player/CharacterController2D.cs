using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerAnimations animations;
    public bool isGrounded;
    public float JumpForce;
    public float Acceleration;
    public float AirAcceleration;
    public float MaxSpeed;
    public float AirMaxSpeed;

    public bool jumpDown;
    public bool jumpHeld;
    public float movement;
    private float lastTimeJump;
    private float _time;
    public float jumpCooldown;

    public Transform GroundCheck;
    public TrailRenderer trail;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animations = GetComponent<PlayerAnimations>();
        trail.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        UpdateAnimations();
    }

    private void FixedUpdate()
    {
        CheckGround();
        HandleJump();
        HandleMovement();
    }

    private void GetInputs() {
        movement = Input.GetAxisRaw("Horizontal");
        jumpDown = Input.GetKeyDown(KeyCode.Space);
        jumpHeld = Input.GetKey(KeyCode.Space);

        if(jumpDown)lastTimeJump = Time.time;  
    }

    private void HandleMovement() {
        float currentMaxSpeed = isGrounded ? MaxSpeed : AirMaxSpeed;
        float currentAcceleration = isGrounded ? Acceleration : AirAcceleration;
        
        if (Mathf.Abs(rb.velocity.x) < currentMaxSpeed)
        {
            rb.AddForce(Vector2.right * movement * currentAcceleration);
        }
        else
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * currentMaxSpeed, rb.velocity.y);
        }

        if (rb.velocity.x >= 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else {
            transform.eulerAngles = new Vector3(0, -180, 0);

        }
    }
    private void HandleJump() {
        if (isGrounded && CanJump()) {
            Jump();
        }
    }


    private void Jump() {
        animations.OnJump();
        isGrounded = false;
        Vector2 v = Vector2.up;
        rb.AddForce(v * JumpForce, ForceMode2D.Impulse);
    }
    private bool CanJump()
    {
        return ((lastTimeJump - Time.time < jumpCooldown) && (jumpHeld || jumpDown)) ;
    }

    private void CheckGround()
    {
        float checkRadius = 0.1f; 
        int groundLayer = LayerMask.GetMask("Ground"); 

        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, checkRadius, groundLayer);
        isGrounded = colliders.Length > 0;
    }

    private void UpdateAnimations() {
        animations.UpdateAirSpeed(rb.velocity.y);

        int state = (Mathf.Abs(rb.velocity.x) > 0.02) ? 1 : 0;
        animations.UpdateAnimState(state);

        animations.UpdateGrounded(isGrounded);

        trail.emitting = !isGrounded;
    }
}
