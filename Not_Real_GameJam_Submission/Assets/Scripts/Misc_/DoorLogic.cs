using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    Animator myAnim;
    SpriteRenderer myRenderer;
    BoxCollider2D doorCollider;

    public Sprite doorOpen;
    public Sprite doorClosed;
    public GameObject doorCanvas;

    private bool door_open = true;
    private bool player_near_door = false;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myRenderer = GetComponent<SpriteRenderer>();
        doorCollider = GetComponent<BoxCollider2D>();
        myRenderer.sprite = doorOpen;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_near_door)
        {
            doorCanvas.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                DoorInteract();
            }
        }
        else
        {
            doorCanvas.SetActive(false);
        }
        /*if (Input.GetKeyDown("e"))
        {
            DoorInteract();
        }*/
    }

    public void DoorInteract()
    {
        if (!door_open)
        {
            
            myAnim.SetBool("Door opening", true);
            StartCoroutine(stopOpening());
            door_open = true;
            doorCollider.enabled = true;
            //myRenderer.sprite = doorOpen;
        }
        else
        {
            myAnim.SetBool("Door closing", true);
            StartCoroutine(stopClosing());
            door_open = false;
            doorCollider.enabled = false;
            //myRenderer.sprite = doorClosed;
        }
    }


    IEnumerator stopOpening()
    {
        yield return new WaitForSeconds(1f);
        myAnim.SetBool("Door opening", false);
    }

    IEnumerator stopClosing()
    {
        yield return new WaitForSeconds(1f);
        myAnim.SetBool("Door closing", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player_near_door = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player_near_door = false;
        }
    }

}


