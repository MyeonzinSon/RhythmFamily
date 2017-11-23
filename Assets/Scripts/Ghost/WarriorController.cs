using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour {

	public Player player;
	public KeyCode inputKey;
	Vector2 initPos;
	public Sprite idleSprite, attackSprite;
	public float yMotionDisp = -0.25f;
	public float motionDuration = 0.25f;
	public float attackDuration = 0.25f;
	float oneBeat = GhostManager.oneBeat;
	float initTime, nextMotionTime, lastMotionTime, lastAttackTime;
	bool isMoving, isBashing;
	SpriteRenderer spriteRenderer;
	void Start () 
	{
		initTime = Time.time;
		nextMotionTime = initTime;
		isMoving = false;
		isBashing = false;

		initPos = transform.position;
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = idleSprite;
	}
	float GetTime()
	{
		return Time.time - initTime;
	}
	void Update () 
	{
		if(!isBashing)
		{
			if(GetTime() >= nextMotionTime)
			{
				isMoving = true;
				lastMotionTime = nextMotionTime;
				nextMotionTime += oneBeat;
			}
			else if(GetTime() - lastMotionTime > motionDuration * oneBeat)
			{
				isMoving = false;
			}

			if (Input.GetKeyDown(inputKey))
			{
				StartBash();
			}

			if (isMoving)
			{
				transform.position = new Vector2(initPos.x,initPos.y + yMotionDisp);
			}
			else
			{
				transform.position = initPos;
			}
		}
		else
		{
			if(GetTime() - lastAttackTime >= attackDuration*oneBeat)
			{
				isBashing = false;
				spriteRenderer.sprite = idleSprite;
			}
		}
	}
	void StartBash()
	{
		isBashing = true;
		isMoving = false;
		lastAttackTime = GetTime();
		spriteRenderer.sprite = attackSprite;
	}
}
