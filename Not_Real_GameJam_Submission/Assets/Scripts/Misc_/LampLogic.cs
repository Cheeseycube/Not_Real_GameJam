using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLogic : MonoBehaviour
{
    SpriteRenderer myRenderer;
    public GameObject lampCanvas;
    public GameObject lampLight;

    private bool player_near_lamp = false;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player_near_lamp)
        {
            lampCanvas.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                lampInteract();
            }
        }
        else
        {
            lampCanvas.SetActive(false);
        }
    }

    private void lampInteract()
    {
        lampLight.SetActive(!lampLight.activeSelf);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player_near_lamp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player_near_lamp = false;
        }
    }
}
