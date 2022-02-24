using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePlayer : MonoBehaviour
{
    Rigidbody2D rb;

    private float timer;
    private bool isWalking = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 1f;
        StartCoroutine(Walking());
    }

    private void Awake()
    {
        //timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timer < 3.2f)
        {
            StartCoroutine(Walking());
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }

    IEnumerator Walking()
    {
        yield return new WaitForSeconds(2f);
        if (!isWalking)
        {
            rb.velocity = new Vector2(3.5f, 0f);
            isWalking = true;
        }
    }
}
