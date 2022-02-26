using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeech2 : MonoBehaviour
{
    public GameObject speechBubble2;

    public static bool maydisplay = false;
    // Start is called before the first frame update
    void Start()
    {
        speechBubble2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (maydisplay)
        {
            StartCoroutine(SpeechWait());
            maydisplay = false;
        }
    }

    IEnumerator SpeechWait()
    {
        yield return new WaitForSecondsRealtime(2f);
        speechBubble2.SetActive(true);
        StartCoroutine(SpeechClose());
    }

    IEnumerator SpeechClose()
    {
        yield return new WaitForSecondsRealtime(10f);
        speechBubble2.SetActive(false);
    }
}
