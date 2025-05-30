using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement2 : MonoBehaviour
{
    private float speed = 8f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float JumpForce = 8f;

    // Doble salto
    private bool canDoubleJump;

    // Variables que utilizaremos para fijar límites
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float bottomLimit;
    [SerializeField] private float topLimit;

    // Climb
    [SerializeField] private float climbSpeed;
    private CircleCollider2D cCollider;
    private bool isClimbing;
    float v;
    float initialGravity;

    //Animation
    private Animator animator;

    //Llamar al sound manager
    SoundManager soundManager;

    //Trail
    [SerializeField] private GameObject trail;

    //Flip
    private bool flippedLeft;
    public bool facingRight;


    void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }


    void Start()
    {
        cCollider = GetComponent<CircleCollider2D>();
        initialGravity = rb.gravityScale;
        canDoubleJump = true;
        animator = GetComponent<Animator>();
        facingRight = true;
    }
    
    void FixedUpdate() // Estamos trabajando toqueteando físicas del Player, entonces usamos el Fixed Update
    {
        float h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        rb.transform.Translate(new Vector2(h, 0) * Time.deltaTime * speed);
        
        rb.transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), Mathf.Clamp(transform.position.y, bottomLimit, topLimit), transform.position.z); // Delimita los movimientos del player en la escecna


        // Flip
        if (h > 0)
        {
            facingRight = true;
            Flip(true);
        }

        if (h < 0)
        {
            facingRight = false;
            Flip(false);
        }
        
        //Animación caminar
        animator.SetFloat("floatX", Mathf.Abs(h)); //Mathf.Abs nos va ayudar a conseguir siempre valores positivos y tener mejor control de la animación
        
        DoubleJump();
        
        Climb();
        
    }

    void Flip(bool facingRight)
    {
        if(flippedLeft && facingRight)
        {
            rb.transform.localScale = new Vector3(5,5,1);
            flippedLeft = false;
        }
        if(!flippedLeft && !facingRight)
        {
            rb.transform.localScale = new Vector3(-5,5,1);
            flippedLeft = true;
        }
    }

    private void DoubleJump() // Función para salto doble
    {
        animator.SetBool("isGrounded", PlayerJumpCollider.isGrounded);
        animator.SetFloat("velocityY", rb.velocity.y);
               
        if (PlayerJumpCollider.isGrounded) 
        {
            canDoubleJump = true;
            trail.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (PlayerJumpCollider.isGrounded)
            {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            soundManager.PlaySFX(soundManager.jump);
            }     
            
            else if (canDoubleJump) 
            {
                rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                soundManager.PlaySFX(soundManager.jump);
                trail.SetActive(true);
                canDoubleJump = false;
            }
        }
     
    }

    private void Climb() // Función para escalar
    // Si el input vertical es distinto de 0 o si isClimbin es verdadero, y si el Collider del Player está tocando la layer Stairs...
    {
        if ((v != 0 || isClimbing) && (cCollider.IsTouchingLayers(LayerMask.GetMask("Stairs"))))
        {
            Vector2 rateOfClimb = new Vector3(rb.velocity.x, v * climbSpeed);
            rb.velocity = rateOfClimb;
            rb.gravityScale = 0;
            isClimbing = true;
            animator.SetBool("isClimbing", isClimbing);
            animator.SetFloat("velocityY", rb.velocity.y);
            
        }
        else
        {
            rb.gravityScale = initialGravity;
            isClimbing = false;
        }

        if (PlayerJumpCollider.isGrounded) // Llamo a una variable de otro código
        {
            isClimbing = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SceneChanger")
        {
            SceneManager.LoadScene("scene3");
        }
    }
}

