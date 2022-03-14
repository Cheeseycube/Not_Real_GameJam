using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting_Player : MonoBehaviour
{
    // Components
    Rigidbody2D rb;
    PolygonCollider2D bodyCollider;
    BoxCollider2D FeetCollider;
    Animator myAnim;

    // Booleans
    private bool PlayerDead = false;
    private bool Paused = false;
    private bool isJumping = false;

    // floats and ints
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 11f;
    [SerializeField] float heldjumpSpeed = 5f;
    private float mayJump = 0.1f;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<PolygonCollider2D>();
        FeetCollider = GetComponent<BoxCollider2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // teleports player up if they get pushed under the ground
        if (transform.position.y < -2.8f)
        {
            transform.Translate(0, 0.2f, 0);
        }
        RunAnimation();
        Jump();
    }

    private void FixedUpdate()
    {
        Run();
    }

    // Functions
    private void Run()
    {
        if (PlayerDead || Player.Paused)
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
        if (PlayerDead || Player.Paused)
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

    private void RunAnimation()
    {
        if ((Mathf.Abs(rb.velocity.x) >= 4.9f) /*|| PlayerAttack.attacking*/)
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
}
