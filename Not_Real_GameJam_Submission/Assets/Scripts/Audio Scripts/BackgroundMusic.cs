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
        /*if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            myAudio.clip = bossTheme;
            print("boss time!");
            //myAudio.Play();
        }*/

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

    // Update is called once per frame
    void Update()
    {
        if ((SceneManager.GetActiveScene().buildIndex == 5) && mayplay)
        {
            myAudio.clip = bossTheme;
            //print("boss time!");
            if (PlayerSpeech2.FightStarted)
            {
                myAudio.Play();
                mayplay = false;
            }
        }
    }
}
