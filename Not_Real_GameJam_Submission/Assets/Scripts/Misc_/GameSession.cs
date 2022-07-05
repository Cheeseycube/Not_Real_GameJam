using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public static bool firstBossFight = true;
    public static bool bossDead = false;

    public GameObject healthBar;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bossDead)
        {
            SceneManager.LoadScene(6);
        }

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            healthBar.SetActive(false);
        }
        else
        {
            healthBar.SetActive(true);
        }

    }

    
}
