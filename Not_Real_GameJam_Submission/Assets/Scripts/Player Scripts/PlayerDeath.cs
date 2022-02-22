using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
       // print(Player.PlayerDead);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.PlayerDead)
        {
            Die();
        }
    }

    private void Die()
    {
        // put death logic here
        // use a co routine so it is not instant
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Player.health = 100f;
        Player.PlayerDead = false;
    }
}
