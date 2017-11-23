using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MusicType { Bug, Ghost, Menu }
public class MusicPlayer : MonoBehaviour {

	public static GameObject instanceGO;
	public static MusicPlayer instance;
	static GameObject soundPlayer;
	
	AudioSource audio;
	public AudioClip bugMusic;
	public AudioClip ghostMusic;
	public AudioClip menuMusic;
	
	public GameObject standardSoundPlayer;

	void Awake()
	{
		if(instanceGO == null)
		{
			instanceGO = this.gameObject;
			instance = this;
			instance.audio = instanceGO.GetComponent<AudioSource>();
			soundPlayer = Instantiate(standardSoundPlayer, transform);
			DontDestroyOnLoad(instanceGO);
		}
		else if(instanceGO != this.gameObject)
		{
			Destroy(gameObject);
		}
	}
	void Start()
	{
		MusicPlayer.PlayMusic(MusicType.Menu);
	}
	public static void PlayMusic(MusicType mt)
	{
		AudioClip clip;
		switch(mt)
		{
			case MusicType.Bug:
			{
				clip = instance.bugMusic; break;
			}
			case MusicType.Ghost:
			{
				clip = instance.ghostMusic; break;
			}
			default:
			{
				clip = instance.menuMusic; break;
			}
		}
		if (instance != null)
		{
			instance.audio.Stop();
			instance.audio.clip = clip;
			instance.audio.Play();
		}
	}
	public static void StopMusic()
	{
		if (instance != null)
		{
			instance.audio.Stop();
		}
	}
	public static void PlaySound()
	{
		if (soundPlayer != null)
		{
			soundPlayer.GetComponent<AudioSource>().Play();
		}
		if(FindObjectOfType<BugManager>() != null)
		{
			StopMusic();
		}
	}
}
