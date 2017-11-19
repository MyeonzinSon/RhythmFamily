using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click : MonoBehaviour
{
    public AudioClip btnsound = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Replay()
    {
        //1
        GetComponent<AudioSource>().clip = btnsound;
        //2
        GetComponent<AudioSource>().Play();

    }
}