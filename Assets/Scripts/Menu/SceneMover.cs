using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour {
    	
	public string sceneToGo;
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			MoveScene(sceneToGo);
		}
	}
	
	public void MoveScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
		MusicPlayer.PlaySound();
	}
	public static void MoveSceneStatic(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
