using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Smooth : MonoBehaviour
{
    private Transform target;
    private Vector3 velocity = Vector3.zero;
    [Range(0, 1)]
    public float smooth;
    public Vector3 posOffset;
    public Vector2 limx;
    public Vector2 limy;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 targetposition = target.position+posOffset;
        targetposition = new Vector3(Mathf.Clamp(targetposition.x, limx.x, limx.y), Mathf.Clamp(targetposition.y, limy.x, limy.y), -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smooth);
    }
}
