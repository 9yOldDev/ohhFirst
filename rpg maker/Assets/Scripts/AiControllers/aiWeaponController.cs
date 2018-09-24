using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiWeaponController : MonoBehaviour {

	public GameObject bulletEnemy;
	public Transform shotPoint;

	public void shoot()
	{
		Instantiate (bulletEnemy, shotPoint.position, Quaternion.identity);
	}
}
