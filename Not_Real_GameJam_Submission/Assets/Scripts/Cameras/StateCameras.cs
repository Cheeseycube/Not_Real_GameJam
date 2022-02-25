using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateCameras : MonoBehaviour
{
    Animator myAnim;
    private int CurrLevel = 0;
    private bool onStairs = false;
    private bool may_play_cliff_sound = true;

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
        Vector3 Playerpos = playerObj.transform.position;

        if (Playerpos.x > 60 && !onStairs)
        {
            myAnim.SetBool("First stairs", true);
            myAnim.SetBool("Player top", false);
            myAnim.SetBool("Player on stairs", false);
            onStairs = true;
        }
        else if (Playerpos.x > 60 && onStairs)
        {
            if (may_play_cliff_sound)
            {
                StartCoroutine(DelayScreech());
                may_play_cliff_sound = false;
            }
            StartCoroutine(CameraSwap());
        }
        else
        {
            myAnim.SetBool("Player top", true);
            myAnim.SetBool("Player on stairs", false);
            myAnim.SetBool("First stairs", false);
        }
        
    }

    IEnumerator CameraSwap()
    {
        // may pause game here or something
        yield return new WaitForSecondsRealtime(3f);
        myAnim.SetBool("Player top", false);
        myAnim.SetBool("First stairs", false);
        myAnim.SetBool("Player on stairs", true);
    }

    IEnumerator DelayScreech()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        FindObjectOfType<BirdSounds>().PlayCliffAudio();
    }
}
