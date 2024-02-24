using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    float NormalSpeed;
    float horizontalMove;
    Rigidbody2D rb;
    public LayerMask Ground;
    public bool onGrounded;
    public bool facingRight;
    Transform groundCheck;

    public Animator animator;
    void Start()
    {
        groundCheck = transform.Find("GroundCheck");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        TrackFacing();
        onGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.075f, Ground);
    }

    public void Move(int x = 0) {
        rb.velocity = new Vector2(NormalSpeed, rb.velocity.y);
    }

    public void Jump()
    {
        if (onGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

    }
    public void WalkButtonUp() {
        NormalSpeed = 0;
        RunAnimation();
    }
    public void WalkButtonLeftDown() {
        NormalSpeed = -Speed;
        RunAnimation();
    }
    public void WalkButtonRightDown()
    {
        NormalSpeed = Speed;
        RunAnimation();
    }

    public void TrackFacing(){
        if(NormalSpeed > 0 && !facingRight){
            Flip();
        }
        if(NormalSpeed < 0 && facingRight){
            Flip();
        }
    }

    private void RunAnimation(){
        animator.SetFloat("Speed", Mathf.Abs(NormalSpeed));
    }

    public void Flip(){
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}