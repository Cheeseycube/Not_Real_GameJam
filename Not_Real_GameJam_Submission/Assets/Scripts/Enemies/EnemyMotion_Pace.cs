using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion_Pace : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currWaypointIndex = 0;

    [SerializeField] private float speed = 3f;

    SpriteRenderer myRenderer;

    private void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoints[currWaypointIndex].transform.position, transform.position) < .1f)
        {
            ++currWaypointIndex;
            myRenderer.flipX = !myRenderer.flipX;
            if (currWaypointIndex >= waypoints.Length)
            {
                currWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currWaypointIndex].transform.position, Time.deltaTime * speed);
        //myRenderer.flipX = !myRenderer.flipX;
    }
}