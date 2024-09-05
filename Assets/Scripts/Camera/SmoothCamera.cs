using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float smooth;
    public Vector3 PosOffset;
     Transform target;

    Vector3 velocity;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(target.position+PosOffset, transform.position, smooth*Time.deltaTime);

        transform.position = Vector3.SmoothDamp(transform.position, target.position + PosOffset, ref velocity, smooth);
    }
}
