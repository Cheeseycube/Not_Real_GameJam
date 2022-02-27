using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCanvas : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayText()
    {
        text.SetActive(true);
    }
}
