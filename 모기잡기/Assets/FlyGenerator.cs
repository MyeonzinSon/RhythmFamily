using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyGenerator : MonoBehaviour {

    public GameObject standardFly;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Instantiate(standardFly);
	}
    
}
