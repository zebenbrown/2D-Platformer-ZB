using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;
    private bool facingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
   
    // Update is called once per frame
    void Update()
    {
        if (facingRight && rb.velocity.x < -0.1)
        {
            Flip();
        }
        else if (!facingRight && rb.velocity.x > 0.1)
        {
            Flip();
        }

        animator.SetFloat("MoveSpeedX", Mathf.Abs(rb.velocity.x) / playerMovement.XSpeed);
        animator.SetBool("Grounded", playerMovement.IsGrounded);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
