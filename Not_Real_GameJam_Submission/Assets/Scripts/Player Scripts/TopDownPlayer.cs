using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontalInput;
    float verticalInput;
    [SerializeField] float movementSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        rb.velocity = new Vector2(horizontalInput * movementSpeed, verticalInput * movementSpeed);
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
}
