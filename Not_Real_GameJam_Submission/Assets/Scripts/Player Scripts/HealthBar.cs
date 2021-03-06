using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    Image myImage;
    public Sprite fullHealth;
    public Sprite three_quarters_Health;
    public Sprite halfHealth;
    public Sprite quarterHealth;
    public Sprite ZeroHealth;

    List<Sprite> spriteList = new List<Sprite>();
    private int i = 0;

    private float health;

    // Start is called before the first frame update
    void Start()
    {
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
        SetHealthBar(); // possible optimization: only call when taking dmg
    }

    private void SetHealthBar()
    {


        if (SceneManager.GetActiveScene().buildIndex != 5)
        {
            health = Player.health;
        }
        else
        {
            health = Fighting_Player.health;
        }

        myImage.sprite = spriteList[i];
        switch (health)
        {
            case 100:
                i = 0;
                break;

            case 75:
                i = 1;
                break;

            case 50:
                i = 2;
                break;

            case 25:
                i = 3;
                break;

            case 0:
                i = 4;
                break;

            default:
                i = 4;
                break;

        }

    }
}
