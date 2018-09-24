using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemyController : MonoBehaviour {

	public float speed;
	public float bulletLifeTime;
    public int bulletEnemyDmg;

	void Start () 
	{
		Destroy (gameObject, bulletLifeTime);
	}

	void FixedUpdate () 
	{
		transform.Translate (Vector2.down*speed);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
            other.GetComponent<playerMovement>().TakeDamage(bulletEnemyDmg);
			Destroy (gameObject);
		}
	}
}
