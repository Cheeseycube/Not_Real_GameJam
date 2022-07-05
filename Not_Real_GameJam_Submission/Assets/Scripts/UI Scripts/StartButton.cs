using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    //public GameObject buttonText;
    private float FlashingTimer = 1f;
    private bool buttonActive = false;
    private float fadeSpeed = 2f;
    private bool fadingOut = true;

    public TextMeshProUGUI startText;

    Color32 startColor;
    TextMeshPro textmeshPro;


    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = GetComponent<TextMeshPro>();
        startColor = startText.color;
        //TMPro.TextMeshProUGUI.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingOut)
        {
            fadeOut();
        }
        else
        {
            fadeIn();
        }
       
        //print(startColor.a);
    }

    private void fadeOut()
    {
        if ((startColor.a > 5) && fadingOut)
        {
            startColor = new Color32(startColor.r, startColor.g, startColor.b, (byte)(startColor.a - fadeSpeed));
            startText.color = startColor;
        }
        else
        {
            //fadingOut = false;
            StartCoroutine(FadeTimer());
        }
    }

    private void fadeIn()
    {
        if ((startColor.a <= 250) && !fadingOut)
        {
            startColor = new Color32(startColor.r, startColor.g, startColor.b, (byte)(startColor.a + fadeSpeed));
            startText.color = startColor;
        }
        else
        {
            //fadingOut = true;
            StartCoroutine(FadeTimer());
        }
    }
    
    IEnumerator FadeTimer()
    {
        yield return new WaitForSeconds(0.5f);
        fadingOut = !fadingOut;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

}
