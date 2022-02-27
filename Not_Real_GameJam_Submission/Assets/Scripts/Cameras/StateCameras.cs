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

            case 2:
                Level1_5();
                break;

            case 5:
                BossLevel();
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
            //onStairs = true;
            Player.Paused = true;
            PlayerSpeech2.maydisplay = true;
            if (may_play_cliff_sound)
            {
                StartCoroutine(DelayScreech());
                may_play_cliff_sound = false;
            }
            StartCoroutine(CameraSwap());
        }
        else if (Playerpos.x > 60 && onStairs && (Playerpos.x <= 70))
        {
            myAnim.SetBool("First stairs", false);
            myAnim.SetBool("Player top", false);
            myAnim.SetBool("Player on stairs", true);
            myAnim.SetBool("Stairs2", false);
        }
        else if (Playerpos.x < 60)
        {
            myAnim.SetBool("Player top", true);
            myAnim.SetBool("Player on stairs", false);
            myAnim.SetBool("First stairs", false);
        }
        else if ((Playerpos.x > 70) && (Playerpos.x < 83))
        {
            myAnim.SetBool("Player top", false);
            myAnim.SetBool("Player on stairs", false);
            myAnim.SetBool("First stairs", false);
            myAnim.SetBool("Stairs2", true);
            myAnim.SetBool("Stairs3", false);
        }
        else if ((Playerpos.x >= 83) && (Playerpos.x < 115.67f))
        {
            myAnim.SetBool("Stairs2", false);
            myAnim.SetBool("Stairs4", false);
            myAnim.SetBool("Stairs3", true);
        }
        else  if ((Playerpos.x >= 116) && Playerpos.x < 138.68f)
        {
            myAnim.SetBool("Stairs3", false);
            myAnim.SetBool("Stairs5", false);
            myAnim.SetBool("Stairs4", true);
        }

        else if (Playerpos.x >= 138.68f)
        {
            myAnim.SetBool("Stairs4", false);
            myAnim.SetBool("Stairs5", true);
        }
         
    }

    private void Level1_5()
    {
        Vector3 Playerpos = playerObj.transform.position;
        if ((Playerpos.x > 60) && Playerpos.x <= 70)
        {
            myAnim.SetBool("Player on stairs", true);
            myAnim.SetBool("Player top", false);
        }
        else if ((Playerpos.x > 70) && (Playerpos.x < 83))
        {
            myAnim.SetBool("Player on stairs", false);
            myAnim.SetBool("Stairs2", true);
            myAnim.SetBool("Stairs3", false);
        }
        else if ((Playerpos.x >= 83) && (Playerpos.x < 115.67f))
        {
            myAnim.SetBool("Stairs2", false);
            myAnim.SetBool("Stairs3", true);
            myAnim.SetBool("Stairs4", false);
        }
        else if ((Playerpos.x >= 116) && Playerpos.x < 136.68f)
        {
            myAnim.SetBool("Stairs3", false);
            myAnim.SetBool("Stairs4", true);
            myAnim.SetBool("Stairs5", false);
        }
        else if (Playerpos.x >= 136.68f)
        {
            myAnim.SetBool("Stairs4", false);
            myAnim.SetBool("Stairs5", true);
        }
        else
        {
            myAnim.SetBool("Player on stairs", false);
            myAnim.SetBool("Player top", true);
        }
    }

    private void BossLevel()
    {
        if (GameSession.firstBossFight)
        {
            myAnim.SetBool("Player talking", PlayerSpeech.PlayerTalking);
            myAnim.SetBool("Boss talking", PlayerSpeech2.BossTalking);
            myAnim.SetBool("Fight Started", PlayerSpeech2.FightStarted);
        }
        else
        {
            myAnim.SetBool("Player talking", false);
            myAnim.SetBool("Boss talking", false);
            myAnim.SetBool("Fight Started", true);
        }
    }

    IEnumerator CameraSwap()
    {
        // may pause game here or something
        yield return new WaitForSecondsRealtime(2.5f);
        myAnim.SetBool("Player top", false);
        myAnim.SetBool("First stairs", false);
        myAnim.SetBool("Player on stairs", true);
        Player.Paused = false;
        onStairs = true;
    }

    IEnumerator DelayScreech()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        FindObjectOfType<BirdSounds>().PlayCliffAudio();
    }
}
