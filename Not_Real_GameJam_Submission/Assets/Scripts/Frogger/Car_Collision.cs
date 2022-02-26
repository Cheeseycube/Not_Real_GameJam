using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Collision : MonoBehaviour
{
    BoxCollider2D carCollider;

    public bool CanDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        carCollider = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        DamagePlayer();
    }
    private void DamagePlayer()
    {
        if (carCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && CanDamage)
        {
            print("how many");
            FindObjectOfType<TopDownPlayer>().TakeDamage(100f);
            FindObjectOfType<TopDownPlayer>().DamageKick();
            FindObjectOfType<TopDownPlayer>().StartCoroutine(StartDamageIndication());
            CanDamage = false;
        }

        if (!carCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            CanDamage = true;
        }
    }
    IEnumerator StartDamageIndication()
    {
        FindObjectOfType<TopDownPlayer>().DamageIndicator(true);
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<TopDownPlayer>().DamageIndicator(false);
    }

}
