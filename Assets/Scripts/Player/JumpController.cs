using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [Header("-----------Input----------")]
    private Rigidbody2D rb;
    public int jumpForce;
    public float fallForce;
    public float jumptime;
    public float jumpMultipler;

    public LayerMask groundlayer;
    public Transform groundcheck;
    Vector2 Gravity;
    bool isJumping;
    float jumpCounter;

    private void Start()
    {
        Gravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
    
        if (Input.GetButtonDown("Jump")&&isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
            jumpCounter = 0;
        }

        if(rb.velocity.y>0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if(jumpCounter>jumptime) isJumping = false;
            rb.velocity += Gravity * jumpMultipler * Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpCounter = 0;

            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity -= Gravity*fallForce*Time.deltaTime;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundcheck.position, new Vector2(2.827573f, 0.9651513f), CapsuleDirection2D.Horizontal, 0, groundlayer); //angle la goc quay
    }
}
