using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    Vector3 targetpos;

    MovementController moveControl;
    Rigidbody2D rb;
    Vector3 moveDirect;

    Rigidbody2D playerRb;

    public GameObject ways;
    public Transform[] wayPoints;
    int pointIndex;
    int poitnCount;
    int direction = 1;

    private void Awake()
    {
        moveControl = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent <Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();

        wayPoints = new Transform[ways.transform.childCount];
        for(int i =0; i< ways.gameObject.transform.childCount; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i).gameObject.transform;
        }
    }
    private void Start()
    {
        pointIndex = 1;
        poitnCount = wayPoints.Length;
        targetpos = wayPoints[1].transform.position;  
        directCal();
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, targetpos) < 0.1f)
        {
            NextPoint();
        }
    }

    public void NextPoint()
    {
        if(pointIndex == poitnCount-1)
        {
            direction = -1;
        }

        if(pointIndex == 0)
        {
            direction = 1;
        }

        pointIndex += direction;
        targetpos = wayPoints[pointIndex].transform.position;
        directCal();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirect * speed;
    }

    private void directCal()
    {
        moveDirect = (targetpos-transform.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moveControl.isOnPlatform = true;
            moveControl.Platformrb = rb;
            playerRb.gravityScale = playerRb.gravityScale*50;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moveControl.isOnPlatform = false;
            playerRb.gravityScale = playerRb.gravityScale / 50;
        }
    }

}
