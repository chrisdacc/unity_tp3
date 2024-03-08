using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPosition : MonoBehaviour
{
    private int direction;
    private void Start()
    {
        direction = 0;
        gameObject.transform.position = new Vector3(-12f,1.5f,20f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < 10f && direction == 0)
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime);
            
        }else if (gameObject.transform.position.x >= 10f && direction == 0)
        {
            direction = 1;
        }else if (gameObject.transform.position.x > -10f && direction == 1)
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime);
        }else if (gameObject.transform.position.x <= -10f && direction == 1)
        {
            direction = 0;
        }
    }
}
