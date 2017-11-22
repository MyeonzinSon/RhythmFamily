using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMover : MonoBehaviour {

	float oneBeat = 0.491803279f;
	float initTime;
	float spawnTime = 0.7377049185f;
	
	Vector2 preDisp;
	Vector2 midPosition;
	Vector2 postDisp;

	float distance = 1f;

	public float preBeats = 2f;
	public float midBeats = 1f;
	public float postBeats = 2f;

	float preDuration;
	float midDuration;
	float postDuration;

	Animator anim;
	int state;

	void Start ()
	{
		state = 0;
		anim = GetComponent<Animator>();

		float preAngle = 2f * Mathf.PI * Random.value;
		preDisp = new Vector2(distance*Mathf.Cos(preAngle), distance*Mathf.Sin(preAngle));
		float postAngle = 2f * Mathf.PI * Random.value;
		postDisp = new Vector2(distance*Mathf.Cos(postAngle), distance*Mathf.Sin(postAngle));

		preDuration = oneBeat * preBeats;
		midDuration = oneBeat * midBeats;
		postDuration = oneBeat * postBeats;
	}
	public void SetVariables(float st, Vector2 pos, float time)
	{
		spawnTime = st;
		midPosition = pos;
		initTime = time;
	}
	float GetTime()
	{
		return Time.fixedTime - initTime;
	}
	void SetPos(Vector2 vec)
	{
		transform.position = vec;
	}
	void FixedUpdate () 
	{
		Vector2 vec = new Vector2(0,10);
		bool isFlying = false;

		if(GetTime() < spawnTime)
		{

		}
		else if(GetTime() < spawnTime + preDuration)
		{
			vec = midPosition - preDisp + preDisp * ((GetTime()-spawnTime)/preDuration);
			isFlying = true;
			state = 1;
		}
		else if (GetTime() < spawnTime + preDuration + midDuration)
		{
			vec = midPosition;
			isFlying = false;
			state = 2;
		}
		else if (GetTime() < spawnTime + preDuration + midDuration + postDuration)
		{
			vec = midPosition + postDisp * ((GetTime()-spawnTime-preDuration-midDuration)/postDuration);
			isFlying = true;
			state = 3;
		}
		else
		{
			vec = new Vector2();
			isFlying = false;
			Destroy(gameObject);
		}

		anim.SetBool("isFlying", isFlying);
		SetPos(vec);
	}
	public int GetScore()
	{
		if (state == 2)
		{
			return 100;
		}
		else if (state == 1)
		{
			return (int)(100*(GetTime()-spawnTime)/preDuration);
		}
		else if (state == 3)
		{
			return (int)(100*(1-(GetTime()-spawnTime-preDuration-midDuration)/postDuration));
		}
		else
		{
			return 0;
		}
	}
}
