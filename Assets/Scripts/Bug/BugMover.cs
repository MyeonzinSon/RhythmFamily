using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMover : MonoBehaviour {

	float oneBeat = 0.491803279f;
	float initTime;
	
	Vector2 preDisp;
	float preDistance = 1f;
	public Vector2 midPosition;
	Vector2 postDisp;
	float postDistance = 1f;

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
		preDisp = new Vector2(preDistance*Mathf.Cos(preAngle), preDistance*Mathf.Sin(preAngle));
		float postAngle = 2f * Mathf.PI * Random.value;
		postDisp = new Vector2(preDistance*Mathf.Cos(preAngle), preDistance*Mathf.Sin(preAngle));

		preDuration = oneBeat *	preBeats;
		midDuration = oneBeat * midBeats;
		postDuration = oneBeat * postBeats;

		SetPos(midPosition - preDisp);
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
		Vector2 vec;
		bool isFlying;
		if(GetTime() < preDuration)
		{
			vec = midPosition - preDisp + preDisp * (GetTime()/preDuration);
			isFlying = true;
		}
		else if (GetTime() < preDuration + midDuration)
		{
			vec = midPosition;
			isFlying = false;
		}
		else if (GetTime() < preDuration + midDuration + postDuration)
		{
			vec = midPosition + postDisp * ((GetTime()-preDuration-midDuration)/postDuration);
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
