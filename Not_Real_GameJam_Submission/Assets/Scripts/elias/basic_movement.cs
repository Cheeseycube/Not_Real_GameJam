using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic_movement : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D boxCollider;
    Rigidbody2D body;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] float movementSpeed = 5f;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        body.velocity = new Vector2 (horizontalInput * movementSpeed, verticalInput * movementSpeed);
    }
}
