using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpCollider : MonoBehaviour
{

    public static bool isGrounded = false;    

    void Start()
    {
        isGrounded = false;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

