using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMover : MonoBehaviour {

	public float speed;
    public float maxX;
    
    void Start()
    {
        MusicPlayer.PlayMusic(MusicType.Menu);
    }
	void Update () {
        transform.position = transform.position + new Vector3(speed*Time.deltaTime,0,0);

        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(-1 * maxX,transform.position.y,transform.position.z);
        }
	}
}
