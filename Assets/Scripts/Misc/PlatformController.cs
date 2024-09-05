using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform posA, posB;
    public int speed;
    private Vector2 targetpos;

    private void Start()
    {
        targetpos = posB.position;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, posA.position)<0.01f) targetpos = posB.position;
        if(Vector2.Distance(transform.position, posB.position)<0.01f) targetpos = posA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(posA.position, posB.position);
    }
}
