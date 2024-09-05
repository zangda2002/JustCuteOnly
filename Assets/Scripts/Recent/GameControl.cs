using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    Vector2 checkpointPos;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        checkpointPos = transform.position;  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap")) 
        {
            Die();
        }
    }
    
    public void updateCheckpoint(Vector2 pos) 
    {
        checkpointPos = new Vector2(pos.x, pos.y+0.5f);
    }

    void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {     
        rb.simulated = false;
        rb.velocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        transform.localScale = new Vector3(1, 1, 1);
        rb.simulated = true;
    }
}
