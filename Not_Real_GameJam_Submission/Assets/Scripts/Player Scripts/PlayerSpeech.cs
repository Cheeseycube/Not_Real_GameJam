using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeech : MonoBehaviour
{
    public GameObject speechBubble1;
    // Start is called before the first frame update
    void Start()
    {
        speechBubble1.SetActive(false);
        StartCoroutine(SpeechWait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   IEnumerator SpeechWait()
    {
        yield return new WaitForSecondsRealtime(1f);
        speechBubble1.SetActive(true);
        StartCoroutine(SpeechClose());
    }

    IEnumerator SpeechClose()
    {
        yield return new WaitForSecondsRealtime(4f);
        speechBubble1.SetActive(false);
    }
}
