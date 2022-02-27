using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float speed = 10f;
    public GameObject WayPoint;
    public Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveForward();
        //transform.position = Vector2.MoveTowards(transform.position, WayPoint.transform.position, Time.deltaTime * speed);
    }

    private void moveForward()
    {
        transform.position = Vector2.MoveTowards(transform.position, WayPoint.transform.position, Time.deltaTime * speed);
        if (transform.position == WayPoint.transform.position)
        {
            transform.position = startPos;
        }
    }
}
