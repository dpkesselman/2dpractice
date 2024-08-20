using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jump : MonoBehaviour
{
    private float speed = 8f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float JumpForce = 8f;


    void Update ()
    {
        float h = Input.GetAxis("Horizontal");

        rb.transform.Translate(new Vector2(h, 0) * Time.deltaTime * speed);
        
        if (Input.GetKeyDown(KeyCode.Space) && PlayerJumpCollider.isGrounded == true)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
