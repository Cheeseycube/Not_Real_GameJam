using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Physics : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currWaypointIndex = 0;

    [SerializeField] private float speed = 3f;


    private void Start()
    {
        
    }
    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoints[currWaypointIndex].transform.position, transform.position) < .1f)
        {
            ++currWaypointIndex;
            //myRenderer.flipX = !myRenderer.flipX;
            gameObject.transform.localScale = new Vector2(-gameObject.transform.localScale.x, gameObject.transform.localScale.y);
            if (currWaypointIndex >= waypoints.Length)
            {
                currWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currWaypointIndex].transform.position, Time.deltaTime * speed);
    }

    public void changeDirection()
    {
        ++currWaypointIndex;
        if (currWaypointIndex >= waypoints.Length)
        {
            currWaypointIndex = 0;
        }
    }
}
