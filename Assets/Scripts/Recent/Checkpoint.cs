using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    SpriteRenderer sp;
    public Sprite passive, active;
    GameControl gc;
    Collider2D coll;
    private void Awake()
    {
        gc = GameObject.FindGameObjectWithTag("Player").GetComponent<GameControl>();
        sp = gameObject.GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gc.updateCheckpoint(transform.position);
            sp.sprite = active;
            coll.enabled = false;
        }
    }
}
