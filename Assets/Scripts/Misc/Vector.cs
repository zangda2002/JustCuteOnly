using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Vector : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 vt;
    public int speed;
    private Distance_Calculator dc;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dc = GetComponent<Distance_Calculator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
         //   rb.velocity = vt*speed;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
          //  rb.velocity = Vector2.zero;
        }
    }
}
