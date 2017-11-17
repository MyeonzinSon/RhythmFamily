using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    AudioSource audio;
    public float asdf;
    public GameObject standardFly;
    // Use this for initialization

    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        audio.Play();
    }

    void Start () {
        PlayMusic();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
