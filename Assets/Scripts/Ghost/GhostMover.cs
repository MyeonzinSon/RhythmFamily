using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMover : MonoBehaviour {

	float oneBeat = GhostManager.oneBeat;
	float initTime;
	float spawnTime = 1.5f*GhostManager.oneBeat;
	float startTime = 0.5f*GhostManager.oneBeat;
	float boostTime = 4*GhostManager.oneBeat;
	Vector2 velocity;
	Vector2 accel;
	Vector2 startPoint, boostPoint;

	void Start()
	{
		
	}
	public void SetVariables(float spawn, Vector2 startPos, Vector2 boostPos, float time)
	{
		spawnTime = spawn;
		startPoint = startPos;
		boostPoint = boostPos;
		initTime = time;

		velocity = Time.fixedDeltaTime * (boostPoint - startPoint) / boostTime;
		accel = 30 * velocity;
		Debug.Log(spawnTime/oneBeat);
	}
	float GetTime()
	{
		return Time.fixedTime - initTime - spawnTime;
	}
	void FixedUpdate()
	{
		Vector2 vel;
		if (GetTime() <= 0)
		{
			transform.position = 2*startPoint - boostPoint;
			vel = new Vector2(0,0);
			if(GhostManager.failed)
			{
				Destroy(gameObject);
			}
		}
		else if (GetTime() <= startTime)
		{
			vel = velocity + accel*(startTime - GetTime())/oneBeat;
		}
		else if (GetTime() <= startTime + boostTime)
		{
			vel = velocity;
		}
		else
		{
			vel = velocity + accel * (GetTime() - startTime - boostTime)/oneBeat;
		}

		transform.position = new Vector2(transform.position.x, transform.position.y) + vel;
		//Debug.Log(transform.position.x + ", " + transform.position.y + " : "+ vel.x + "," + vel.y);

		if (transform.position.y < -6)
		{
			FindObjectOfType<GhostManager>().SubHeart();
			Destroy(gameObject);
		}
	}
}