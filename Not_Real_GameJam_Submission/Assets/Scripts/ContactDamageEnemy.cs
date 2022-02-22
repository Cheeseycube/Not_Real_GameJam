using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamageEnemy : MonoBehaviour
{
    // Components
    BoxCollider2D damageCollider;

    // Booleans
    private bool CanDamage = true;
    

    // Start is called before the first frame update
    void Start()
    {
        damageCollider = GetComponent<BoxCollider2D>();
        // Get the player object
        /*playerGameObject = GameObject.Find("Player");
        if (playerGameObject != null)
        {
            player = playerGameObject.GetComponent<Player>();
        }
        else
        {
            Debug.Log("eeeeeeeee");
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        DamagePlayer();
    }

    private void DamagePlayer()
    {
        if (damageCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && CanDamage)
        {
            FindObjectOfType<Player>().TakeDamage(25f);
            CanDamage = false;
        }

        if (!damageCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            CanDamage = true;
        }
    }

}
