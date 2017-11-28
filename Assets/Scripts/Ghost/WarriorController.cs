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
	public float beatCheckDuration = 0.25f;
	float oneBeat = GhostManager.oneBeat;
	float initTime, nextMotionTime, lastMotionTime, lastAttackTime;
	float attackDelay, beatChecker;
	bool isMoving, isBashing;
	SpriteRenderer spriteRenderer;
	Collider2D collider;
	void Start () 
	{
		collider = GetComponent<Collider2D>();
		collider.enabled = false;
		initTime = Time.time;
		lastMotionTime = GetTime();
		lastAttackTime = GetTime();
		nextMotionTime = GetTime();
		beatChecker = GetTime();
		isMoving = false;
		isBashing = false;

		initPos = transform.position;
		spriteRenderer = GetComponent<SpriteRenderer>();
		collider = GetComponent<Collider2D>();
		spriteRenderer.sprite = idleSprite;
	}
	float GetTime()
	{
		return Time.time - initTime;
	}
	void Update () 
	{
		if(collider.enabled)
		{
			collider.enabled = false;
		}	
		if(!isBashing)
		{
			if(GetTime() >= beatChecker)
			{
				spriteRenderer.sprite = idleSprite;
			}

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
			if(GetTime() - lastAttackTime >= attackDelay && GetTime() >= beatChecker)
			{
				isBashing=false;
			}
		}
		if (GetTime() >= beatChecker)
		{
			beatChecker += oneBeat *beatCheckDuration;
		}
	}
	void StartBash()
	{
		isBashing = true;
		isMoving = false;
		lastAttackTime = GetTime();
		collider.enabled = true;
		spriteRenderer.sprite = attackSprite;
		attackDelay = attackDuration*oneBeat;
	}
	void EndBash()
	{
		isBashing = false;
		spriteRenderer.sprite = idleSprite;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Ghost")
		{
			attackDelay = beatCheckDuration*oneBeat;
			Destroy(other.gameObject);
			GetComponent<AudioSource>().Play();
		}
	}
}
