using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHealth : MonoBehaviour
{
    Canvas canvas;
    public GameObject playerObj;
    Image myImage;
    public Sprite fullHealth;
    public Sprite three_quarters_Health;
    public Sprite halfHealth;
    public Sprite quarterHealth;
    public Sprite ZeroHealth;

    List<Sprite> spriteList = new List<Sprite>();
    private int i = 0;
    private int previousHealth = 0;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        myImage = GetComponent<Image>();
        spriteList.Add(fullHealth);
        spriteList.Add(three_quarters_Health);
        spriteList.Add(halfHealth);
        spriteList.Add(quarterHealth);
        spriteList.Add(ZeroHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerSpeech2.FightStarted) {
            canvas.enabled = false;
        }
        else
        {
            canvas.enabled = true;
        }
        gameObject.transform.position = new Vector2(playerObj.transform.position.x, playerObj.transform.position.y + 4f);

        SetHealthBar();
    }

    private void SetHealthBar()
    {
        myImage.sprite = spriteList[i];
        switch (BossLogic.bossHealth)
        {
            case 100:
                i = 0;
                previousHealth = 0;
                break;

            case 75:
                i = 1;
                previousHealth = 1;
                break;

            case 50:
                i = 2;
                previousHealth = 2;
                break;

            case 25:
                i = 3;
                previousHealth = 3;
                break;

            case 0:
                i = 4;
                previousHealth = 4;
                break;

            default:
                i = previousHealth;
                break;

        }

    }
}
