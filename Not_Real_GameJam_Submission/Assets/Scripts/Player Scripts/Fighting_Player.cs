using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting_Player : MonoBehaviour
{
    // Components
    Rigidbody2D rb;
    PolygonCollider2D bodyCollider;
    Animator myAnim;

    // Booleans
    private bool PlayerDead = false;
    private bool Paused = false;

    // floats and ints
    [SerializeField] float runSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<PolygonCollider2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RunAnimation();
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
