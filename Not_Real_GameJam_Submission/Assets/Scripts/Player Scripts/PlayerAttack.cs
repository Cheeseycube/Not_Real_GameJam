using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator myAnim;
    public static bool attacking = false;
    private bool mayAttack = true;
    
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            attacking = true;
            if (mayAttack)
            {
                StartCoroutine(Attack());
                StartCoroutine(AttackWait());
                mayAttack = false;
            }
        }*/
    }

    IEnumerator Attack()
    {
        mayAttack = false;
        myAnim.SetBool("Player attacking", true);
        
        yield return new WaitForSeconds(0.3f);
        myAnim.SetBool("Player attacking", false);
        attacking = false;
        //mayAttack = true;
    }

    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(1f);
        mayAttack = true;
    }
}
