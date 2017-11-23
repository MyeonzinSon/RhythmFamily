using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player {p1, p2}
public class StickController : MonoBehaviour {

	public Player player;
	public Vector2[] positions;
	Vector2 initPos;
	int posNum;
	bool isMoved;
	public KeyCode inputKey;
	public BugSpawner bugSpawner;
	float movedTime;
	float returnTime;
	float oneBeat = 0.491803279f;
	GameManager gameManager;
	AudioSource audio;
	void Start () 
	{
		gameManager = FindObjectOfType<GameManager>();
		audio = GetComponent<AudioSource>();
		initPos = transform.position;
		returnTime = oneBeat / 4f;
		isMoved = false;
		posNum = 0;
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(inputKey))
		{
			transform.position = positions[posNum];
			posNum++;
			if (posNum >= positions.Length)
			{
				posNum = 0;
			}
			SetReturn();
		}
		if(isMoved && Time.time - movedTime >= returnTime)
		{
			transform.position = initPos;
			isMoved = false;
		}
	}
	void SetReturn()
	{
		movedTime = Time.time;
		isMoved = true;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "NormalBug")
		{
			gameManager.AddScore(player, other.GetComponent<BugMover>().GetScore(), other.transform.position);
			audio.Play();
			Destroy(other.gameObject);
		}
	}
}
