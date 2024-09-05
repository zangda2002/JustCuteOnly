using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simplemove : MonoBehaviour
{
    public int speed;
    Vector2 move;

    private void Start()
    { 

    }

    private void Update()
    {
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //transform.position += new Vector3(move.x, move.y) * speed * Time.deltaTime;
        
        transform.Translate(move*speed*Time.deltaTime, Space.World);
        flip();
    }
    private void flip()
    {
        if (move.x < -0.01f) transform.localScale = new Vector3(-1.25f, 1.25f, 1);
        if (move.x > 0.01f) transform.localScale = new Vector3(1.25f, 1.25f, 1);
    }
}
