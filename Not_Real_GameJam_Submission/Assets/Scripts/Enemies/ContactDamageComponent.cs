using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamageComponent : MonoBehaviour
{
    // Components
    BoxCollider2D damageCollider;

    // Booleans
    private bool CanDamage = true;


    // Start is called before the first frame update
    void Start()
    {
        damageCollider = GetComponent<BoxCollider2D>();

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
