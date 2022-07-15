using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    Animator myAnim;
    Rigidbody2D rb;
    BoxCollider2D BodyCollider;
    CapsuleCollider2D attackCollider;

    private float timer = 0;
    private float attackTimer = 2.5f; // was 4 seconds
    public static float bossHealth = 100f;
    private bool CanDamage = true;

    public Rigidbody2D playerMovement;
    public GameObject playerObj;
    public GameObject damageLight;
    private static float speed = 3f;    // idk I had to make this static for some reason
    private bool CanJump = true;
    Vector2 DefaultMove = new Vector2(speed * -1, 0);

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        BodyCollider = GetComponent<BoxCollider2D>();
        attackCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(bossHealth);
        /*if (playerMovement.velocity.x < 0)
        {
            rb.velocity = new Vector2(speed * -1, 0);
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
        }*/
        if (PlayerSpeech2.FightStarted)
        {
            //RBMove();
            //Move();
            BetterMovement();
            Attack();
            DamagePlayer();
        }

        // teleports boss down if they get pushed into the air
        if (transform.position.y > -0.78f)
        {
            transform.Translate(0, -0.2f, 0);
        }

    }

    private void Attack()
    {
       /* if ((transform.position.x - playerObj.transform.position.x < 10))
        {
            myAnim.SetBool("BossAttacking", true);
            attackCollider.enabled = true;
            StartCoroutine(AttackTimer());
        }*/

        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0f)
        {
            myAnim.SetBool("BossAttacking", true);
            attackCollider.enabled = true;
            StartCoroutine(AttackTimer());
            attackTimer = 2.5f;  // was 4 seconds
        }
        
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerObj.transform.position, speed * Time.deltaTime);
        if (playerObj.transform.position.x > transform.position.x)
        {
            //spriteRenderer.flipX = true;
            gameObject.transform.localScale = new Vector2(-3, gameObject.transform.localScale.y);
        }
        else if (playerObj.transform.position.x < transform.position.x)
        {
            gameObject.transform.localScale = new Vector2(3, gameObject.transform.localScale.y);
        }
    }

    private void RBMove()
    {
        if (!myAnim.GetBool("BossAttacking"))
        {
            if (playerMovement.velocity.x < 0)
            {
                rb.velocity = new Vector2(speed * -1, 0);
                DefaultMove = new Vector2(speed * -1, 0);
            }
            else if (playerMovement.velocity.x > 0)
            {
                rb.velocity = new Vector2(speed, 0);
                DefaultMove = new Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            transform.position = Vector2.MoveTowards(transform.position, playerObj.transform.position, speed * Time.deltaTime);
        }
    }

    private void BetterMovement()
    {
        if (!myAnim.GetBool("BossAttacking"))
        {
            if (playerObj.transform.position.x < transform.position.x)
            {
                gameObject.transform.localScale = new Vector2(3, gameObject.transform.localScale.y);
                rb.velocity = new Vector2(speed * -1, 0);
            }
            else if (playerObj.transform.position.x > transform.position.x)
            {
                gameObject.transform.localScale = new Vector2(-3, gameObject.transform.localScale.y);
                rb.velocity = new Vector2(speed, 0);
            }
            /*if (playerMovement.velocity.x < 0)
            {
                rb.velocity = new Vector2(speed * -1, 0);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
            }*/
        }
        else
        {
            rb.velocity = Vector2.zero;
            transform.position = Vector2.MoveTowards(transform.position, playerObj.transform.position, speed * Time.deltaTime);
        }
    }

    private void DamagePlayer()
    {
        if (attackCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && CanDamage)
        {
            FindObjectOfType<Fighting_Player>().TakeDamage(25f);
            FindObjectOfType<Fighting_Player>().DamageKick();
            StartCoroutine(StartDamageIndication());
            CanDamage = false;
        }

        if (!attackCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && attackCollider.enabled == false)
        {
            CanDamage = true;
        }
    }

    public void DamageBoss()
    {
        bossHealth -= 12.5f;  // was 25
        StartCoroutine(BossStartDamageIndication());
        if (bossHealth <= 0)
        {
            GameSession.bossDead = true;
            Destroy(gameObject);
        }
    }

    private void BossDamageIndicator(bool isDamaged)
    {
        damageLight.SetActive(isDamaged);
    }
    IEnumerator StartDamageIndication()
    {
        FindObjectOfType<Fighting_Player>().DamageIndicator(true);
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<Fighting_Player>().DamageIndicator(false);
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(1f); // originally 2 seconds
        myAnim.SetBool("BossAttacking", false);
        attackCollider.enabled = false;
    }

    IEnumerator BossStartDamageIndication()
    {
        BossDamageIndicator(true);
        yield return new WaitForSeconds(0.5f);
        BossDamageIndicator(false);
    }

}
