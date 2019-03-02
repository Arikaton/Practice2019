using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float secondJumpForce = 2f;
    Rigidbody2D rb;
    Animator animator;
    CapsuleCollider2D capsuleCollider;
    BoxCollider2D boxCollider;
    bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (!isAlive) { return; }
        MovePlayer();
        FlipSprite();
        Jump();
        ClimbLadder();
        Death();  
    }

    private void MovePlayer()
    {
        float newX = Input.GetAxis("Horizontal") * movementSpeed;
        Vector2 newVelocity = new Vector2(newX, rb.velocity.y);
        rb.velocity = newVelocity;
        bool hasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            animator.SetBool("Running", true);
        }
        else { animator.SetBool("Running", false); }
    }

    void Jump()
    {
        if (!boxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if (Input.GetButtonDown("Jump"))
            {
                rb.velocity += new Vector2(0, jumpForce);
            }
    }

    void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector3(Mathf.Sign(rb.velocity.x), 1, 1);
        } 
    }

    void ClimbLadder()
    {
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ladder"))) 
        { 
            animator.SetBool("Climbing", false);
            rb.gravityScale = 1;
            return;
        }

        rb.gravityScale = 0;
        animator.SetBool("Climbing", true);
        rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * movementSpeed);
    }

    void Death()
    {
        if (capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            rb.velocity = Vector2.zero;
            isAlive = false;
            animator.SetTrigger("Death");
        }
    }
}
