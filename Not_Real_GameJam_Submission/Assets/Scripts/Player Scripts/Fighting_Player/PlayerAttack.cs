using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    CircleCollider2D attackZone;
    private bool mayDamageBoss = true;
    
    // Start is called before the first frame update
    void Start()
    {
        attackZone = GetComponent<CircleCollider2D>();
        attackZone.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        attackZone.enabled = Fighting_Player.Basic_attacking;
        if (attackZone.enabled == false)
        {
            mayDamageBoss = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boss") && mayDamageBoss)
        {
            mayDamageBoss = false;
            print("attacked boss!");
            FindObjectOfType<BossLogic>().DamageBoss();
        }
    }

}
