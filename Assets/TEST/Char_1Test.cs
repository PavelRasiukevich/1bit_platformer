using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_1Test : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public bool isGrounded;
    private int jumpsAmmount;
    public int extraJumps;
    public float jumpForce;
    public float  horizontal;
    public float velocity;


    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundCheckMask;

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");

        rigidbody2d.velocity = new Vector2(horizontal * Time.deltaTime * velocity, rigidbody2d.velocity.y);
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckMask);

        if (isGrounded)
        {
            jumpsAmmount = extraJumps;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody2d.velocity = Vector2.up * jumpForce * Time.deltaTime;
            
        }

        else if (Input.GetKeyDown(KeyCode.Space) && jumpsAmmount > 0 && !isGrounded)
        {
            rigidbody2d.velocity = Vector2.up * jumpForce * Time.deltaTime;
           
            jumpsAmmount--;
        }
    }
}
