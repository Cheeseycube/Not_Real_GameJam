using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamageEnemy : MonoBehaviour
{
    BoxCollider2D damageCollider;
    GameObject playerGameObject;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        // Get the player object
        playerGameObject = GameObject.Find("Player");
        if (playerGameObject != null)
        {
            player = playerGameObject.GetComponent<Player>();
        }
        else
        {
            Debug.Log("eeeeeeeee");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (damageCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            player.TakeDamage(25f);
        }
    }

}
