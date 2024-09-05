using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWithWASD : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed;
    public int jumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

    }
}
