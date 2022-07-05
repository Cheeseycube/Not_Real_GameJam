using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuStuff : MonoBehaviour
{
    private float fadeSpeed = 2f;
    public TextMeshProUGUI startText;
    Color32 startColor;
    // Start is called before the first frame update
    void Start()
    {
        startColor = startText.color;
        startColor = new Color32(startColor.r, startColor.g, startColor.b, 0);
        startText.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 2f)
        {
            fadeIn();
        }
    }

    private void fadeIn()
    {
        if (startColor.a <= 250)
        {
            startColor = new Color32(startColor.r, startColor.g, startColor.b, (byte)(startColor.a + fadeSpeed));
            startText.color = startColor;
        }
        
    }
}
