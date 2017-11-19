using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugmove : MonoBehaviour {

    public float startTime;
    public float checkTime;
	// Use this for initialization
	void Awake ()
    {
    }

    // Update is called once per frame
    void Update () {
        StartTime(startTime);
    }
    void StartTime(float time)
    {
        if (Time.time > time)
        {
        transform.position = new Vector3(transform.position.x, transform.position.y, -4);

        GetComponent<AudioSource>().Play();
        }
       
      
        CheckTime(checkTime);
	}
    void CheckTime(float time)
    {
        if (Time.time > time)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1);
         
        }
    }
}
