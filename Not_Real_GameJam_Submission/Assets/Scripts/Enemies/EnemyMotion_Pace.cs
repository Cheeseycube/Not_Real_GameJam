using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion_Pace : MonoBehaviour
{
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(-6f, 0);
    }
}
