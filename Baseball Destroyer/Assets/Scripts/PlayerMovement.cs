using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float xSpeed = 10f;
    public float XSpeed => xSpeed;
    [SerializeField] private float jumpForce = 880f;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;

    private float xMoveInput;
    private bool isGrounded;
    public bool IsGrounded => isGrounded;

    private bool shouldJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xMoveInput = Input.GetAxis("Horizontal") * xSpeed;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shouldJump = true;
        }
    }

    private void FixedUpdate()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
        isGrounded = collider != null;
        rb.velocity = new Vector2(xMoveInput, rb.velocity.y);
        if (shouldJump)
        {
            if (isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce);
            }
            
            shouldJump = false;
        }
    }
}
