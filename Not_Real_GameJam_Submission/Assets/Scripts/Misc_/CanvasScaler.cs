using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector2(0.3333333333f, 0.3333333333f);
    }
}
