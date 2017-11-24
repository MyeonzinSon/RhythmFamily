using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditController : MonoBehaviour {

	float initTime;
	public Image gc;
	public Image black;

	void Start () {
		initTime = Time.time;
	}

	void Update () {
		float time = Time.time - initTime;
		if(time < 2)
		{
			gc.color = new Color(time/2, time/2, time/2,1);
		}
		else if (time < 4)
		{
			gc.color = new Color(1,1,1,1);
		}
		else if (time < 6)
		{
			gc.color = new Color(1,1,1,(6-time)/2);
		}
		else if (time < 8)
		{
			black.color = new Color(0,0,0,(8-time)/2);
		}
		else if (time < 10)
		{
			black.color = new Color(0,0,0,0);
		}
		else if (time < 12)
		{
			black.color = new Color(0,0,0,(time-10)/2);
		}
		else
		{
			SceneMover.MoveSceneStatic("StartScene");
		}
	}
}
