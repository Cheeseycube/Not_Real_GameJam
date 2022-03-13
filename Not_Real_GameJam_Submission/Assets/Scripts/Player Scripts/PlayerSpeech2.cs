using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpeech2 : MonoBehaviour
{
    public GameObject speechBubble2;
    public GameObject bossCanvas;

    private int CurrScene = 0;
    public static bool maydisplay = false;
    public static bool BossTalking = false;
    public static bool FightStarted = false;

    private void Awake()
    {
        CurrScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Start is called before the first frame update
    void Start()
    {
        speechBubble2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrScene)
        {
            case 1:
                Scene1();
                break;

            case 5:
                Scene2();
                break;

            default:
                break;
        }
    }

    private void Scene1()
    {
        if (maydisplay)
        {
            StartCoroutine(SpeechWait1());
            maydisplay=false;
        }
    }

    private void Scene2()
    {
        if (maydisplay)
        {
            StartCoroutine(SpeechWait2());
            maydisplay = false;
        }
    }

    IEnumerator SpeechWait1()
    {
        yield return new WaitForSecondsRealtime(2f);
        speechBubble2.SetActive(true);
        StartCoroutine(SpeechClose1());
    }

    IEnumerator SpeechClose1()
    {
        yield return new WaitForSecondsRealtime(10f);  // 6?
        speechBubble2.SetActive(false);
    }

    IEnumerator SpeechWait2()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        BossTalking = true;
        speechBubble2.SetActive(true);
        StartCoroutine(SpeechClose2());
    }

    IEnumerator SpeechClose2()
    {
        yield return new WaitForSecondsRealtime(3f);
        FindObjectOfType<FightCanvas>().DisplayText();
       // FindObjectOfType<Mushroom>().Spawn();
        BossTalking = false;
        speechBubble2.SetActive(false);
        Player.Paused = false;
        FightStarted = true;
        bossCanvas.SetActive(true);
    }
}
