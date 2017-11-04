﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    public float speed;
    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(0.45f, 12, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0,-1 * speed);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            float x = -4.5f;
            transform.position = new Vector3(x, 6, 0);
        }
    }
}
   

