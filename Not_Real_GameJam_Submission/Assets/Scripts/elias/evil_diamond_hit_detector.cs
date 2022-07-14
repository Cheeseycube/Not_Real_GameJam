using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evil_diamond_hit_detector : MonoBehaviour
{
    // Start is called before the first frame update
    PolygonCollider2D polygonCollider;
    void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // when collider touching player display a message
        if (polygonCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            // do nothing
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
            public_attributes.score++;
            // print("your score is: " + public_attributes.score.ToString());
            print("your score is: " + public_attributes.score);
            //public_attributes.printSomething(collision.gameObject.name);
            collision.gameObject.GetComponent<public_attributes>().printSomething("some kinda message");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
