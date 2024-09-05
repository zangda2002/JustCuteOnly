using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MoveByForce : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 move;
    [SerializeField] private int speed;

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
        //Affected by Mass(the more Mass the less moblize)
        rb.AddForce(move * speed, ForceMode2D.Impulse);                    //Continius gain Impact Physic(use "ForceMode2D.Impulse" to make this Affect right away)
    }

    private void Flip()
    {
        if (move.x < -0.1f) transform.localScale = new Vector3(-0.05f, 0.05f, 0);
        if (move.x > 0.1f) transform.localScale = new Vector3(0.05f, 0.05f, 0);
    }
}
