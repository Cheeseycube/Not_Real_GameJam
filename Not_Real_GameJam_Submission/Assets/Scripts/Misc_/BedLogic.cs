using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedLogic : MonoBehaviour
{
    public GameObject bedCanvas;
    private bool player_near_bed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player_near_bed)
        {
            bedCanvas.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                bedInteract();
            }
        }
        else
        {
            bedCanvas.SetActive(false);
        }
    }

    private void bedInteract()
    {
        SceneManager.LoadScene(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player_near_bed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player_near_bed = false;
        }
    }
}
