using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private float horizontal;
    private bool isFacingRight = true;
    public bool canMove;
    private enum MovementState { idle, running, jump, fall }

    public float speed = 6f;
    public float jumpingPower = 8f;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private void Start()
    {
        canMove = true;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (canMove && Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        FlipCharacter();
        AnimationState();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FlipCharacter()
    {
        if (canMove && isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) 
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void AnimationState()
    {
        MovementState state;

        if (canMove && horizontal < 0f)
        {
            state = MovementState.running;
        }
        else if (canMove && horizontal > 0f)
        {
            state = MovementState.running;
        }
        else 
        {
            state = MovementState.idle;
        }

        if (canMove && rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (canMove && rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }

        anim.SetInteger("State", (int)state);
    }

}
