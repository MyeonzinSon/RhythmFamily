using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditController : MonoBehaviour {

	float initTime;
	Image image;
	void Start () {
		initTime = Time.time;
		image = GetComponent<Image>();
	}

	void Update () {
		float time = Time.time - initTime;
		if(time < 2)
		{
			image.color = new Color(time/2, time/2, time/2,1);
		}
		else if (time < 4)
		{
			image.color = new Color(1,1,1,1);
		}
		else if (time < 6)
		{
			image.color = new Color((6-time)/2,(6-time)/2,(6-time)/2,1);
		}
		else
		{
			SceneMover.MoveSceneStatic("StartScene");
		}
	}
}
