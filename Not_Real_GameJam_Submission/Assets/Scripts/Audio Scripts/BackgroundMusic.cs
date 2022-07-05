using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public static AudioSource myAudio;
    public static bool muted = false;
    public AudioClip mainTheme;
    public AudioClip bossTheme;
    bool mayplay = true;

    private void Awake()
    {

        int numMusic = FindObjectsOfType<BackgroundMusic>().Length;
        if (numMusic > 1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        /*if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            myAudio.clip = bossTheme;
            print("boss time!");
        }
        else
        {
            myAudio.clip = mainTheme;
        }*/
    }

    public static void AudioToggle()
    {
        AudioListener.pause = !AudioListener.pause;

    }

    // Update is called once per frame
    void Update()
    {
        if ((SceneManager.GetActiveScene().buildIndex == 5) && mayplay)
        {
            // should play boss music
            myAudio.clip = bossTheme;
            if (PlayerSpeech2.FightStarted)
            {
                //print("playing boss music");
                myAudio.Play();
                mayplay = false;
            }
        }
    }
}
