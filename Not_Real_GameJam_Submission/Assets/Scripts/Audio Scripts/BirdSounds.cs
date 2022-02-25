using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSounds : MonoBehaviour
{
    [SerializeField] AudioClip cliffSound;
    [SerializeField] float cliffSoundVol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCliffAudio()
    {
        GameObject AudioListener = GameObject.FindWithTag("AudioListener");
        AudioSource.PlayClipAtPoint(cliffSound, AudioListener.transform.position, cliffSoundVol);
    }
}
