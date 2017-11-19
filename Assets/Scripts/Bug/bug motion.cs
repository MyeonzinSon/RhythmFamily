using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugmotion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, transform.position.y, -4);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
