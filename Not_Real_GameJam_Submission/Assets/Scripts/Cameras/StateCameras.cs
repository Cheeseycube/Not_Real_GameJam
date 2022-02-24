using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateCameras : MonoBehaviour
{
    Animator myAnim;
    private int CurrLevel = 0;

    public GameObject playerObj;


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
            case 1:
                Level1();
                break;

            default:
                break;
        }
    }

    private void Level1()
    {
        Vector3 Playerpos = playerObj.transform.position;  // player bottom is actually the wide cam right now, and should only be used for a second or two
        if (Playerpos.x > 60) // was 60
        {
            print("cam move");
            myAnim.SetBool("Player bottom", true);
            myAnim.SetBool("Player top", false);
        }
        else
        {
            print("not good");
            myAnim.SetBool("Player top", true);
            myAnim.SetBool("Player bottom", false);
        }
    }
}
