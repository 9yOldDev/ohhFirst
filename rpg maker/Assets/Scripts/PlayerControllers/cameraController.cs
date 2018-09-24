using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

	public Transform player;
	public float deathPlaceY;

	void LateUpdate () 
	{	
			Vector3 camPos = new Vector3 (player.position.x, player.position.y, -10f);
			transform.position = camPos;
	}
		
}
