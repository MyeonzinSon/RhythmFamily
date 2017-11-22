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

	void Start ()
	{
		anim = GetComponent<Animator>();

		initTime = Time.time;
		float preAngle = 2f * Mathf.PI * Random.value;
		preDisp = new Vector2(distance*Mathf.Cos(preAngle), distance*Mathf.Sin(preAngle));
		float postAngle = 2f * Mathf.PI * Random.value;
		postDisp = new Vector2(distance*Mathf.Cos(postAngle), distance*Mathf.Sin(postAngle));

		preDuration = oneBeat * preBeats;
		midDuration = oneBeat * midBeats;
		postDuration = oneBeat * postBeats;
	}
	public void SetVariables(float st, Vector2 pos)
	{
		spawnTime = st;
		midPosition = pos;
	}
	float GetTime()
	{
		return Time.time - initTime;
	}
	void SetPos(Vector2 vec)
	{
		transform.position = vec;
	}
	void Update () 
	{
		Vector2 vec = new Vector2(0,10);
		bool isFlying = false;

		if(GetTime() < spawnTime)
		{

		}
		else if(GetTime() < spawnTime + preDuration)
		{
			vec = midPosition - preDisp + preDisp * (GetTime()-spawnTime/preDuration);
			isFlying = true;
		}
		else if (GetTime() < spawnTime + preDuration + midDuration)
		{
			vec = midPosition;
			isFlying = false;
		}
		else if (GetTime() < spawnTime + preDuration + midDuration + postDuration)
		{
			vec = midPosition + postDisp * ((GetTime()-spawnTime-preDuration-midDuration)/postDuration);
			isFlying = true;
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
}
