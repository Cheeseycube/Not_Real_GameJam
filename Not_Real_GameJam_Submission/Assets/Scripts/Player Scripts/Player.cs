using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Components
    Rigidbody2D rb;
    PolygonCollider2D BodyCollider;
    BoxCollider2D FeetCollider;
    SpriteRenderer spriteRenderer;
    Animator myAnim;
    public GameObject damageLight;

    // Serialized Fields
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 11f;
    [SerializeField] float heldjumpSpeed = 5f;

    // floats
    float mayJump = 0.1f;
    float timer;
    [SerializeField] public static float health = 100f;

    // integers

    // booleans
    public static bool PlayerDead = false;
    public static bool Paused = false;
    private bool isJumping = false;
    //private bool isFlipped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BodyCollider = GetComponent<PolygonCollider2D>();
        FeetCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();

    }


    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        Jump();
        if (Mathf.Abs(rb.velocity.x) >= 4.9f)
        {
            myAnim.enabled = true;
            myAnim.SetBool("Player moving", true);
        }
        else
        {
            myAnim.SetBool("Player moving", false);
            myAnim.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        Run();
    }

    public void DamageIndicator(bool isDamaged)
    {
        damageLight.SetActive(isDamaged);
    }

    public void DeathKick()
    {
        rb.velocity = new Vector2(0f, 50f);
    }
    private void Run()
    {
        if (PlayerDead || Paused)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // value between -1 and +1
        rb.velocity = new Vector2(horizontalInput * runSpeed, rb.velocity.y);

        if (horizontalInput < 0)
        {
            //spriteRenderer.flipX = true;
            gameObject.transform.localScale = new Vector2(-3, gameObject.transform.localScale.y);
        }
        else if (horizontalInput > 0)
        {
            gameObject.transform.localScale = new Vector2(3, gameObject.transform.localScale.y);
        }
    }

    private void Jump()
    {
        if (PlayerDead || Paused)
        {
            return;
        }

        mayJump -= Time.deltaTime;

        if (FeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            mayJump = 0.1f;
        }

        if (Input.GetButtonDown("Jump") && (mayJump > 0f))
        {
            timer = Time.time;
            isJumping = true;
            rb.velocity = new Vector2(0f, jumpSpeed);
        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if (Time.time - timer > 0.15) // make 0.15 bigger for longer time needed to hold down jump
            {
                timer = float.PositiveInfinity;
                rb.velocity += new Vector2(0f, heldjumpSpeed);
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }

    public void TakeDamage(float damageDealt)
    {
        health -= damageDealt;
        if (health <= 0f)
        {
            PlayerDead = true;
        }
    }
}
