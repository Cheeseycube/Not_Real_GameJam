using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpeech : MonoBehaviour
{
    public GameObject speechBubble1;

    private int CurrScene = 0;
    public static bool PlayerTalking = false;

    private void Awake()
    {
        CurrScene = SceneManager.GetActiveScene().buildIndex;
    }
    // Start is called before the first frame update
    void Start()
    {
        speechBubble1.SetActive(false);
        switch (CurrScene) {
            case 1:
                StartCoroutine(SpeechWait1());
                break;

            case 3:
                StartCoroutine(SpeechWait1());
                break;
            case 5:
                if (GameSession.firstBossFight)
                {
                    StartCoroutine(SpeechWait2());
                }
                else
                {
                    break;
                }
                break;

            default:
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }

   IEnumerator SpeechWait1()
    {
        yield return new WaitForSecondsRealtime(1f);
        speechBubble1.SetActive(true);
        StartCoroutine(SpeechClose1());
    }

    IEnumerator SpeechClose1()
    {
        yield return new WaitForSecondsRealtime(4f);
        speechBubble1.SetActive(false);
    }

    IEnumerator SpeechWait2()
    {
        Player.Paused = true;
        yield return new WaitForSecondsRealtime(3f);
        PlayerTalking = true;
        speechBubble1.SetActive(true);
        StartCoroutine(SpeechClose2());
    }

    IEnumerator SpeechClose2()
    {
        yield return new WaitForSecondsRealtime(4f);
        PlayerTalking = false;
        speechBubble1.SetActive(false);
        PlayerSpeech2.maydisplay = true;
    }

}
