using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private int CurrLevel = 0;

    private void Awake()
    {
        CurrLevel = SceneManager.GetActiveScene().buildIndex;
    }
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
        switch (CurrLevel)
        {
            case 1:
                Level1();
                break;

            default:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Player.health = 100f;
                Player.PlayerDead = false;
                break;
        }

    }

    private void Level1()
    {
        SceneManager.LoadScene(2);
        Player.health = 100f;
        Player.PlayerDead = false;
    }
}
