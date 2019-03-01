using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    Rigidbody2D rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        FlipSprite();
        Jump();
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
        if (Input.GetButtonDown("Jump"))
        {
            float newY = jumpForce;
            rb.velocity += new Vector2(0, newY);
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
}
