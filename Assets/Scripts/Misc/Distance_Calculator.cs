using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance_Calculator : MonoBehaviour
{
    public GameObject main;
    public GameObject enemy;

    private Rigidbody2D mainrb;
    private Rigidbody2D enemyrb;

    private float distance;
    public Text t;

    public int speed;
    private void Start()
    {
        mainrb = GetComponent<Rigidbody2D>();
        enemyrb = enemy.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        distance = Vector2.Distance(main.transform.position, enemy.transform.position);
        t.text = "Distance: " + Math.Round(distance, 2);

        if (distance > 4)
        {
            enemyrb.velocity = (main.transform.position - enemy.transform.position).normalized*speed;
        }
        else
        {   
            enemyrb.velocity = Vector2.zero;
        }
    }

    
}
