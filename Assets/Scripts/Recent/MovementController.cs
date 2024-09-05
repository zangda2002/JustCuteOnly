using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] int speed;
    Rigidbody2D rb;
    [Range(1, 10)]
    [SerializeField] float Acceleration;
    float speedMultiplier;

    bool btnPress;

    bool isWallTouch;
    public LayerMask walllayer;
    public Transform Wallcheck;

    Vector2 relativeTransform;

    public bool isOnPlatform;
    public Rigidbody2D Platformrb;

    public ParticleControls pc;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        UpdateRelaTransform();
    }

    private void FixedUpdate()
    {
        UpdateSpeedMultiplier();
        float targetSpeed = speed * speedMultiplier*relativeTransform.x;


        if (isOnPlatform)
        {
            rb.velocity = new Vector2(targetSpeed+Platformrb.velocity.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(targetSpeed, rb.velocity.y);
        }
      

        isWallTouch = Physics2D.OverlapBox(Wallcheck.position, new Vector2(0.01615945f, 0.535753f), 0, walllayer);

        if (isWallTouch)
        {
            flip();     
        }
    }

    public void UpdateRelaTransform()
    {
        relativeTransform = transform.InverseTransformVector(Vector2.one);
    }

    public void flip()
    {
        pc.Touchparticle(Wallcheck.position);
        transform.Rotate(0, 180, 0);
        UpdateRelaTransform();
    }

    public void Move(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            btnPress = true;         
        }
        else if (value.canceled)
        {
            btnPress = false;         
        }
    }

    void UpdateSpeedMultiplier()
    {
        if(btnPress && speedMultiplier < 1)
        {
            speedMultiplier += Time.deltaTime*Acceleration;
        }else if(!btnPress && speedMultiplier > 0)
        {
            speedMultiplier -=Time.deltaTime*Acceleration;
            if (speedMultiplier < 0) speedMultiplier = 0;
        }
    }
}
