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
    float dashTimer;
    [SerializeField] public static float health = 100f;

    // integers

    // booleans
    public static bool PlayerDead = false;
    public static bool Paused = false;
    private bool isJumping = false;
    private bool mayDash = true;
    private bool mayDamage = true;
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
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (transform.position.y < -2.8f)
            {
                transform.Translate(0, 0.2f, 0);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) && mayDash)
            {
                transform.Translate(rb.velocity.x, 0, 0);
                dashTimer = Time.time;
                mayDash = false;
            }
            if (Time.time - dashTimer >= 1f)
            {
                mayDash = true;
            }
        }
        HazardDetection();
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        Jump();
        if ((Mathf.Abs(rb.velocity.x) >= 4.9f) || PlayerAttack.attacking)
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

    public void DamageKick()
    {
        rb.velocity = new Vector2(0f, 30f);
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

    private void HazardDetection()
    {
        if (BodyCollider.IsTouchingLayers(LayerMask.GetMask("Hazards")) || FeetCollider.IsTouchingLayers(LayerMask.GetMask("Hazards")))
        {
            TakeDamage(100f);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            if (FeetCollider.IsTouchingLayers(LayerMask.GetMask("Birds")) )
            {
                //TakeDamage(25f);
                DamageKick();
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            if (FeetCollider.IsTouchingLayers(LayerMask.GetMask("Boss")))
            {
                if (mayDamage)
                {
                    health += 25;
                    FindObjectOfType<BossLogic>().DamageBoss();
                    DamageKick();
                    mayDamage = false;
                }

                //Destroy(collision.gameObject);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            mayDamage = true;
        }
    }
}
