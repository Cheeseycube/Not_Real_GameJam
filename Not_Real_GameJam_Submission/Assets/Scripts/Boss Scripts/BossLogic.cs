using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    Animator myAnim;
    Rigidbody2D rb;
    BoxCollider2D BodyCollider;

    private float timer = 0;
    public static float bossHealth = 100f;
    private bool CanDamage = true;

    public Rigidbody2D playerMovement;
    public GameObject playerObj;
    private float speed = 5f;
    private bool CanJump = true;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        BodyCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
            Move();
            Attack();
        }
        DamagePlayer();
    }

    private void Attack()
    {
        //timer = 0;
        if (Time.time - timer > 2f)
        {
            rb.velocity = new Vector2(rb.velocity.x, 30f);
            timer = Time.time;
        }
        /*if ((transform.position.x - playerObj.transform.position.x < 10))
        {
            if (CanJump)
            {
                //print("attacking");
                rb.velocity = new Vector2(rb.velocity.x, 30f);
                //transform.Translate(0, 5, 0);
                CanJump = false;
            }
        }
        else
        {
            print("jump again");
            CanJump = true;
        }*/
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerObj.transform.position, speed * Time.deltaTime);
    }

    private void DamagePlayer()
    {
        if (BodyCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && CanDamage)
        {
            FindObjectOfType<Player>().TakeDamage(25f);
            FindObjectOfType<Player>().DamageKick();
            StartCoroutine(StartDamageIndication());
            CanDamage = false;
        }

        if (!BodyCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            CanDamage = true;
        }
    }

    public void DamageBoss()
    {
        bossHealth -= 25f;
        if (bossHealth < 0)
        {
            GameSession.bossDead = true;
            Destroy(gameObject);
        }
    }

    IEnumerator StartDamageIndication()
    {
        FindObjectOfType<Player>().DamageIndicator(true);
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<Player>().DamageIndicator(false);
    }

}
