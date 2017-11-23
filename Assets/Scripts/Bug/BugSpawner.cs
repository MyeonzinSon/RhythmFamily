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
	public Vector2[] normalPositionsR;
	[HideInInspector]
	public Vector2[] normalPositionsL;
	public GameObject bigBug;
	public Vector2[] bigPositionsR;
	[HideInInspector]
	public Vector2[] bigPositionsL;
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
		normalPositionsL = new Vector2[normalPositionsR.Length];
		for (int i = 0; i < normalPositionsR.Length; i++)
		{
			normalPositionsL[i] = new Vector2(-1*normalPositionsR[i].x,normalPositionsR[i].y);
		}

		bigPositionsL = new Vector2[bigPositionsR.Length];
		for (int i = 0; i < bigPositionsR.Length; i++)
		{
			bigPositionsL[i] = new Vector2(-1*bigPositionsR[i].x,bigPositionsR[i].y);
		}

		spawnQ = new Queue<GameObject>();
		for (int i = 0; i < patternScore.Length; i++)
		{
			InterpretPattern(patternDic[patternScore[i]], i+1);		
		}
		initTime = Time.time;
		hasPlayed = false;
		GetComponent<BugManager>().SetTime(oneBeat * 4, oneBeat *(patternScore.Length)*4);
	}
	void InterpretPattern(Pattern p, int measureNum)
	{
		for (int i = 0; i < p.notes.Length; i++)
		{
			Vector2 posR;
			Vector2 posL;
			if (p.notes[i].type == BugType.Normal)
			{
				posR = normalPositionsR[normalPosNum];
				posL= normalPositionsL[normalPosNum];
				selectedBug = normalBug;
				normalPosNum++;
			}
			else
			{
				posR = bigPositionsR[bigPosNum];
				posL = bigPositionsL[bigPosNum];
				selectedBug = bigBug;
				bigPosNum++;
			}
			spawnQ.Enqueue(SpawnOne(p.notes[i], posR, measureNum, selectedBug));
			spawnQ.Enqueue(SpawnOne(p.notes[i], posL, measureNum, selectedBug));
			
			if(normalPosNum >= normalPositionsR.Length)
			{
				normalPosNum = 0 ;
			}
			if(bigPosNum >= bigPositionsR.Length)
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
