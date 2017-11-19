using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 효과 : MonoBehaviour {

    public float speed;
    public float maxX;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + new Vector3(speed*Time.deltaTime,0,0);

        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(-1 * maxX,transform.position.y,0);
        }
	}
}
