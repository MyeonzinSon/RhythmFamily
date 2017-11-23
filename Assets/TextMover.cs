using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMover : MonoBehaviour {

	public float lifetime = 0.491803279f;
	public float yDisp;
	Vector2 initPos;
	
	float initTime;
	string scoreText;
	void Start () 
	{
		initTime = Time.time;
	}
	public void SetVariables(Vector2 pos, int score)
	{
		initPos = pos;
		GetComponent<TextMesh>().text = "+"+score;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time - initTime < lifetime)
		{
			transform.position = new Vector2(initPos.x, initPos.y + yDisp *(Time.time - initTime)/lifetime);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
