using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MoveByRigid : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed;

    private Vector2 move;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Flip();
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position+ move * speed * Time.deltaTime); // Non-physic(Kinematic) Only
        //rb.velocity = move * speed;                                  // Low-affected by Physic
        rb.velocity = new Vector2(move.x*speed, rb.velocity.y);        // Interact well with Physic
    }

    private void Flip()
    {
        if (move.x < -0.1f) transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0);
        if (move.x > 0.1f) transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 0);
    }
}