using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GhostNote
{
	public float beat;
	public Player player;
}
[System.Serializable]
public class GhostPattern
{
	public GhostNote[] notes;
}
public class GhostSpawner : MonoBehaviour {

	Queue<GameObject> spawnQ;

	public GameObject ghost;
	public Vector2 startPoint, boostPoint1, boostPoint2;


	public GhostPattern[] patternDic;
	public int[] patternScore;
	

	float oneBeat = GhostManager.oneBeat;
	float initTime;
	bool hasPlayed;
	void Start () 
	{
		spawnQ = new Queue<GameObject>();
		for (int i = 0; i < patternScore.Length; i++)
		{
			InterpretPattern(patternDic[patternScore[i]], i+2);		
		}
		initTime = Time.time;
		hasPlayed = false;
		GetComponent<GhostManager>().SetTime(oneBeat * 8, oneBeat *(patternScore.Length)*4);
	}
	void InterpretPattern(GhostPattern p, int measureNum)
	{
		for (int i = 0; i < p.notes.Length; i++)
		{
			Vector2 boostPos;
			if (p.notes[i].player == Player.p1)
			{
				boostPos = boostPoint1;
			}
			else
			{
				boostPos = boostPoint2;
			}
			spawnQ.Enqueue(SpawnOne(p.notes[i], startPoint, boostPos, measureNum));
		}
	}
	GameObject SpawnOne(GhostNote note, Vector2 startPos, Vector2 boostPos, int measureNum)
	{
		float spawnTime = (measureNum * 4 + note.beat - 1 - 4.75f) * oneBeat;
		GameObject go = Instantiate(ghost,transform);
		go.GetComponent<GhostMover>().SetVariables(spawnTime, startPos, boostPos);
		return go;
	}
	void Update () 
	{
		if (!hasPlayed && Time.time - initTime >= 8f * oneBeat)
		{
			GetComponent<AudioSource>().Play();
			hasPlayed = true;
		}
	}
}
