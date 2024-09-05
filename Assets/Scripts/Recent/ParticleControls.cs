using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControls : MonoBehaviour
{
    public ParticleSystem moveparticle;
    public ParticleSystem fallparticle;
    public ParticleSystem touchparicle;
    public ParticleSystem deadparticale;

    [Range(0, 10)]
    public int speed;

    [Range(0, 0.2f)]
    public float dustPeriod;

    float counter;
    public Rigidbody2D rb;

    bool isOnGround;

    private void Start()
    {
        touchparicle.transform.parent = null;
    }

    private void Update()
    {
        counter += Time.deltaTime;
        if (isOnGround && Mathf.Abs(rb.velocity.x)>speed)
        {
            if (counter > dustPeriod)
            {
                moveparticle.Play();
                counter = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = true;
            fallparticle.Play();
        }
        if (collision.CompareTag("Trap"))
        {
            deadparticale.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }

    public void Touchparticle(Vector2 pos)
    {
        touchparicle.transform.position = pos;
        touchparicle.Play();    
    }
}
