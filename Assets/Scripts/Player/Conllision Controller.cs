using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ConllisionController : MonoBehaviour
{
    public GameObject main;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(main);
        };
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "box") Debug.Log("stay");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "box") Debug.Log("leave");
    }
}
