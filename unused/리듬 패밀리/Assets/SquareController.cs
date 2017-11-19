using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    public KeyCode inputKey;
    public float speed = 0.1f;
    public float x = 2f;
    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(3, 4, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, -1 * speed,0);

        

    }
    void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(inputKey))
        {
            transform.position = new Vector3(x, 2, 0);
        }
    }  
}

