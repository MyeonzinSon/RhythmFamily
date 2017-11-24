using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostManager : MonoBehaviour {

	public static float oneBeat = 0.5f;
	public static bool failed;

	public Image[] hearts = new Image[4];
	public Slider slider;
	public GameObject startMessage, clearMessage, failMessage;
	int currentHeart;
	float time;
	float initTime;
	float startTime;
	float musicLength;
	bool isFinished;
	void Start () 
	{
		GhostManager.failed = false;
		int i = 0;
		for (; i < hearts.Length; i++)
		{
			hearts[i].enabled = true;
		}	
		currentHeart = i;

		MusicPlayer.StopMusic();
		isFinished = false;
		initTime = Time.time;
		slider.value = 0;

		startMessage.SetActive(true);
		clearMessage.SetActive(false);
		failMessage.SetActive(false);
	}
	
	public void SubHeart()
	{
		if (!isFinished && currentHeart > 0)
		{
			hearts[currentHeart-1].enabled = false;
			currentHeart--;
		}
		else if(currentHeart <= 0)
		{
			Failed();
		}
	}
	public void SetTime(float start, float length)
	{
		startTime = start;
		musicLength = length;
	}
	float MusicTime()
    {
        return Time.time - initTime - startTime;
    }
    void Update()
    {
		if(startMessage.active && MusicTime() >= 0)
		{
			startMessage.SetActive(false);
		}
        if (!isFinished && (MusicTime() >= 0 && MusicTime() <= musicLength))
        {
            slider.value = MusicTime()/musicLength;
        }
        else if(!isFinished && MusicTime() >= musicLength)
        {
            Cleared();
        }  
        else if(isFinished)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneMover.MoveSceneStatic("StartScene");
            }
        }
    }
	void Cleared()
	{
		isFinished = true;
		clearMessage.SetActive(true);
	}
	void Failed()
	{
		Debug.Log("Failed");
		isFinished = true;
		failMessage.SetActive(true);
		GhostManager.failed = true;
	}
}
