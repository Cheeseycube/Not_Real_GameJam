using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpeech : MonoBehaviour
{
    public GameObject speechBubble1;

    private int CurrLevel = 0;

    private void Awake()
    {
        CurrLevel = SceneManager.GetActiveScene().buildIndex;
    }
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
