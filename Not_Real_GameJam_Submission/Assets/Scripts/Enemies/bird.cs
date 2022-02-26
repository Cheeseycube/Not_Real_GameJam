using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    // Start is called before the first frame update
    // Components
    PolygonCollider2D birdCollider;

    // Booleans
    private bool CanDamage = true;


    // Start is called before the first frame update
    void Start()
    {
        birdCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DamagePlayer();
    }

    private void DamagePlayer()
    {
        if (birdCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && CanDamage)
        {
            FindObjectOfType<Player>().TakeDamage(25f);
            FindObjectOfType<Player>().DeathKick();
            FindObjectOfType<EnemyMotion_Pace>().changeDirection();
            StartCoroutine(StartDamageIndication());
            CanDamage = false;
        }

        if (!birdCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            CanDamage = true;
        }
    }

    IEnumerator StartDamageIndication()
    {
        FindObjectOfType<Player>().DamageIndicator(true);
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<Player>().DamageIndicator(false);
    }
}

