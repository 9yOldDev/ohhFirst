using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour {

	public float offset = 0.0f;
	public GameObject bullet;
	public Transform shotPoint;
	public float fireRate;
	private float actTime = 0f;

	void Start () {
		
	}
	void FixedUpdate () {
		if (Input.GetMouseButtonDown(0) && actTime<=0) 
		{
			shoot ();
			actTime = fireRate;
		}

		if (actTime>0) 
		{
			actTime -= Time.deltaTime;
		} 

	}

	public void shoot()
	{
		Instantiate(bullet, shotPoint.position, transform.rotation);
	}
}
