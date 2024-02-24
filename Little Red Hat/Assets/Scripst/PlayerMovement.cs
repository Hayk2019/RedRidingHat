using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    float NormalSpeed;
    Rigidbody2D rb;
    public LayerMask Ground;
    public bool onGrounded;
    Transform groundCheck;
    void Start()
    {
        groundCheck = transform.Find("GroundCheck");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        onGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.075f, Ground);
    }

    public void Move(int x = 0) {
        {
            rb.velocity = new Vector2(NormalSpeed, rb.velocity.y);
        }
    }

    public void Jump()
    {
        if (onGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

    }
    public void WalkButtonUp() {
        NormalSpeed = 0;
    }
    public void WalkButtonLeftDown() {
        NormalSpeed = -Speed;
    }
    public void WalkButtonRightDown()
    {
        NormalSpeed = Speed;
    }
}