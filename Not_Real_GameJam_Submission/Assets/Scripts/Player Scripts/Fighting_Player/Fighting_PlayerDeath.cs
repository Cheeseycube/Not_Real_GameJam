using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fighting_PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Fighting_Player.PlayerDead || Input.GetKeyDown("r"))
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(5);
        Fighting_Player.health = 100f;
        BossLogic.bossHealth = 100f;
        Fighting_Player.PlayerDead = false;
        GameSession.firstBossFight = false;
        Fighting_Player.mayAttack = true;
    }
}
