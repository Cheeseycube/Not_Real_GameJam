using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutscenePlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject speechBubble;
    public GameObject Text1;
    public GameObject Text2;

    private float timer;
    private bool isWalking = false;
    // Start is called before the first frame update
    void Start()
    {
        speechBubble.SetActive(false);
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
            speechBubble.SetActive(true);
            StartCoroutine(ChangeText());
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

    IEnumerator ChangeText()
    {
        yield return new WaitForSeconds(2f);
        Text1.SetActive(false);
        Text2.SetActive(true);
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
