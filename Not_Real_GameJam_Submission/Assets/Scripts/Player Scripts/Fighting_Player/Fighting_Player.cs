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
    public GameObject damageLight;

    // Booleans
    public static bool PlayerDead = false;
    private bool Paused = false;
    private bool isJumping = false;
    public static bool Basic_attacking = false;
    public static bool mayAttack = true;
    private bool attack_ending = false;
    private bool facingLeft = false;

    // floats and ints
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 11f;
    [SerializeField] float heldjumpSpeed = 5f;
    [SerializeField] public static float health = 100f;
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
        Animations();
        Jump();
        BasicAttack();
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
            facingLeft = true;
        }
        else if (horizontalInput > 0)
        {
            gameObject.transform.localScale = new Vector2(3, gameObject.transform.localScale.y);
            facingLeft = false;
        }
    }

    private void Jump()
    {
        if (PlayerDead || Player.Paused)
        {
            return;
        }

        mayJump -= Time.deltaTime;

        if (FeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) || FeetCollider.IsTouchingLayers(LayerMask.GetMask("Boss")))
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

     // fighting animation ideas: basically when the attack button is pressed, is attacking becomes true, and while attacking the run animation is not allowed
     // when the attack button is pressed, first set walking to false in animator and set attacking to true in animator
     // then after like 0.5 seconds or so set attack to false and walking to true and turn off the animator

    // alternate idea: have a bug checker that enables walking animation when player is stuck in attack animation for too long

    // new attack ideas: how about we just change the player's sprite to the final frame of the attack.  Also turn off the animator when attacking.  Turn the animator back on after the attack is done?
    private void Animations()
    {
        if ((Mathf.Abs(rb.velocity.x) >= 4.9f) && !Basic_attacking)
        {
            myAnim.enabled = true;
            myAnim.SetBool("Player moving", true);
            myAnim.SetBool("Player attacking", false);
        }
        else if (Basic_attacking)
        {
            myAnim.SetBool("Player moving", false);
            myAnim.SetBool("Player attacking", true);
            myAnim.enabled = true;
        }
        else if (attack_ending)
        {
            //print("attack ending");
            myAnim.SetBool("Player moving", true);
            myAnim.SetBool("Player attacking", false);
            myAnim.enabled = true;
        }
        else
        {
            myAnim.SetBool("Player moving", false);
            myAnim.SetBool("Player attacking", false);
            myAnim.enabled = false;
        }
    }

    // what we need is to add in a little walk animation after the attack, that is considered part of the attack animation as a whole
    private void BasicAttack()
    {
        //print(mayAttack);
        if (Input.GetKeyDown(KeyCode.LeftShift) && mayAttack)
        {
            //print("attacking");
            mayAttack = false;
            Basic_attacking = true;
            //print(Basic_attacking);
            StartCoroutine(AttackRepeatTimer());
            StartCoroutine(AttackTimer());
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

    public void DamageKick()
    {
        if (facingLeft)
        {
            rb.velocity = new Vector2(30f, 5f);
        }
        else
        {
            rb.velocity = new Vector2(-30f, 5f);
        }
    }

    public void DamageIndicator(bool isDamaged)
    {
        damageLight.SetActive(isDamaged);
    }

    IEnumerator AttackRepeatTimer()
    {
        yield return new WaitForSeconds(1f);  // originally 1f, probably can't be less than 0.2f
        mayAttack = true;
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(0.2f);
        Basic_attacking = false;
        StartCoroutine(AttackWalk());
    }

    IEnumerator AttackWalk()
    {
        attack_ending = true;
        yield return new WaitForSeconds(0.3f);
        attack_ending = false;
    }

   
}
