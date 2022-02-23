using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateCameras : MonoBehaviour
{
    Animator myAnim;
    private int CurrLevel = 0;


    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    private void Awake()
    {
        CurrLevel = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        switch(CurrLevel)
        {
            case 0:
                Level0();
                break;

            default:
                break;
        }
    }

    private void Level0()
    {
        Vector3 Playerpos = gameObject.transform.position;
        if (Playerpos.x > 60)
        {
            myAnim.SetBool("Player bottom", true);
            myAnim.SetBool("Player top", false);
        }
        else
        {
            myAnim.SetBool("Player top", true);
            myAnim.SetBool("Player bottom", false);
        }
    }
}
