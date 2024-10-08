using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smooth = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    
    void Update()
    {
        Vector3 targetPosistion = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosistion, ref velocity, smooth);
    }
}
