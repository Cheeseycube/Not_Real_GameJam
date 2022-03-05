using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHealth : MonoBehaviour
{
    Canvas canvas;
    public GameObject playerObj;
    [SerializeField] TextMeshProUGUI fullHealth;
    [SerializeField] TextMeshProUGUI ThreeQuarterHealth;
    [SerializeField] TextMeshProUGUI HalfHealth;
    [SerializeField] TextMeshProUGUI LowHealth;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
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
        gameObject.transform.position = new Vector2(playerObj.transform.position.x, playerObj.transform.position.y);
        if (BossLogic.bossHealth == 100)
        {
            fullHealth.enabled = true;
        }
        else
        {
            fullHealth.enabled = false;
        }

        if (BossLogic.bossHealth == 75)
        {
            ThreeQuarterHealth.enabled = true;
        }
        else
        {
            ThreeQuarterHealth.enabled = false;
        }

        if (BossLogic.bossHealth == 50)
        {
            HalfHealth.enabled = true;
        }
        else
        {
            HalfHealth.enabled = false;
        }

        if (BossLogic.bossHealth == 25)
        {
            LowHealth.enabled = true;
        }
        else
        {
            LowHealth.enabled = false;
        }

    }
}
