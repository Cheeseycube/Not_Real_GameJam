using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public GameObject mushroom;
    // Start is called before the first frame update
    void Start()
    {
        mushroom.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        mushroom.SetActive(true);
    }
}
