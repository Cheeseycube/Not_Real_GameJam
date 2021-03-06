using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    PolygonCollider2D bodyCollider;
    float horizontalInput;
    float verticalInput;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] public static float health = 100f;
    public static bool PlayerDead = false;
    public GameObject damageLight;
    public static bool slowed = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        if (Player.PlayerDead)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }
        move();
        FlipSprite();
    }

    private void move()
    {
        if (slowed)
        {
            rb.velocity = new Vector2(horizontalInput * 3f, verticalInput * 3f);
        }
        else
        {
            rb.velocity = new Vector2(horizontalInput * movementSpeed, verticalInput * movementSpeed);
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            //transform.localScale = new Vector3(Mathf.Sign(myRigidBody.velocity.x), 1f, -10f);  // make this a vector 3 if screen goes blue as a result of camera being parented under player
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x) * 2f, 2f); // was 1f
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
        rb.velocity = new Vector2(0f, 30f);
    }
    public void DamageIndicator(bool isDamaged)
    {
        damageLight.SetActive(isDamaged);
    }

}
