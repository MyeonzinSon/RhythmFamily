using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMover : MonoBehaviour {

	float oneBeat = GhostManager.oneBeat;
	float initTime;
	float spawnTime = 1.5f*GhostManager.oneBeat;
	Vector2 velocity;
	public Vector2 startPoint, boostPoint, endPoint;
}