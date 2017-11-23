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
		initTime = Time.time;
		velocity = Time.fixedDeltaTime * (boostPoint - startPoint) / boostTime;
		accel = 30 * velocity;
	}
	public void SetVariables(float spawn, Vector2 startPos, Vector2 boostPos)
	{
		spawnTime = spawn;
		startPoint = startPos;
		boostPoint = boostPos;
	}
	float GetTime()
	{
		return Time.time - initTime - spawnTime;
	}
	void FixedUpdate()
	{
		Vector2 vel;
		if (GetTime() < 0)
		{
			transform.position = 2*startPoint - boostPoint;
			vel = new Vector2(0,0);
		}
		else if (GetTime() < startTime)
		{
			vel = velocity + accel*(startTime - GetTime())/oneBeat;
		}
		else if (GetTime() < startTime + boostTime)
		{
			vel = velocity;
		}
		else
		{
			vel = velocity + accel * (GetTime() - startTime - boostTime)/oneBeat;
		}

		transform.position = new Vector2(transform.position.x, transform.position.y) + vel;
		Debug.Log(transform.position.x + ", " + transform.position.y + " : "+ vel.x + "," + vel.y);

		if (transform.position.y < -6)
		{
			GhostManager.SubHeart();
			Destroy(gameObject);
		}
	}
}