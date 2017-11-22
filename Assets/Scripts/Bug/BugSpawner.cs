using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum BugType{Normal, Big}
[System.Serializable]
public class Note
{
	public float beat;
	public BugType type;
}
[System.Serializable]
public class Pattern
{
	public Note[] notes;
}

public class BugSpawner : MonoBehaviour {

	Queue<GameObject> spawnQ;

	public GameObject normalBug;
	public Vector2[] normalPositions;
	public GameObject bigBug;
	public Vector2[] bigPositions;
	GameObject selectedBug;

	public Pattern[] patternDic;
	public int[] patternScore;
	

	float oneBeat = 0.491803279f;
	float initTime;
	bool hasPlayed;
	int normalPosNum = 0;
	int bigPosNum = 0;
	void Start () 
	{
		spawnQ = new Queue<GameObject>();
		for (int i = 0; i < patternScore.Length; i++)
		{
			InterpretPattern(patternDic[patternScore[i]], i+1);		
		}
		initTime = Time.time;
		hasPlayed = false;
	}
	void InterpretPattern(Pattern p, int measureNum)
	{
		for (int i = 0; i < p.notes.Length; i++)
		{
			Vector2 pos;
			if (p.notes[i].type == BugType.Normal)
			{
				pos = normalPositions[normalPosNum];
				selectedBug = normalBug;
			}
			else
			{
				pos = bigPositions[bigPosNum];
				selectedBug = bigBug;
			}
			spawnQ.Enqueue(SpawnOne(p.notes[i], pos, measureNum, selectedBug));
			spawnQ.Enqueue(SpawnOne(p.notes[i], new Vector2(-1*pos.x, pos.y), measureNum, selectedBug));
			normalPosNum++;
			bigPosNum++;
			if(normalPosNum >= normalPositions.Length)
			{
				normalPosNum = 0 ;
			}
			if(bigPosNum >= bigPositions.Length)
			{
				bigPosNum = 0 ;
			}
		}
	}
	GameObject SpawnOne(Note note, Vector2 spawnPos, int measureNum, GameObject selectedBug)
	{
		float spawnTime = (measureNum * 4 + note.beat - 1 - 2.5f) * oneBeat;
		GameObject go = Instantiate(selectedBug,transform);
		go.GetComponent<BugMover>().SetVariables(spawnTime, spawnPos,Time.fixedTime);
		return go;
	}
	void Update () 
	{
		if (!hasPlayed && Time.time - initTime >= 4f * oneBeat)
		{
			GetComponent<AudioSource>().Play();
			hasPlayed = true;
		}
	}
	
}
