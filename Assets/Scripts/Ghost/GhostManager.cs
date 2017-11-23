using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour {

	public static float oneBeat = 0.5f;

	float time;
	float startTime;
	float musicLength;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static void SubHeart()
	{
		
	}
	public void SetTime(float start, float length)
	{
		startTime = start;
		musicLength = length;
	}
}
