using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SprayTransform
{
	public Vector2 pos;
	public float zRot;
}
public class SprayController : MonoBehaviour {

	public Player player;
	public float[] zRotations;
	public KeyCode inputKey;
	public BugSpawner bugSpawner;

	Vector2 pos;
	public Vector2 initPos;
	int posNum;
	float movedTime;
	float returnTime;
	bool isMoved;
	float oneBeat = 0.491803279f;

	GameManager gameManager;
	AudioSource audio;
	void Start () 
	{
		gameManager = FindObjectOfType<GameManager>();
		audio = GetComponent<AudioSource>();
		pos = transform.position;
		returnTime = oneBeat / 4f;
		isMoved = false;
		posNum = 0;

		transform.position = initPos;
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(inputKey))
		{
			transform.position = pos;
			transform.rotation = Quaternion.Euler(0,0,zRotations[posNum]);
			posNum++;
			if (posNum >= zRotations.Length)
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
		if (other.tag == "BigBug")
		{
			gameManager.AddScore(player, other.GetComponent<BugMover>().GetScore(), other.transform.position);
			audio.Play();
			Destroy(other.gameObject);
		}
	}
}
