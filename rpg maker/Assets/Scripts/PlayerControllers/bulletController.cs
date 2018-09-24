using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {

	public float bulletSpeed;
	public float bulletLife;
    public int bulletDmg;
	public ParticleSystem particleEnemy;

	void Start () 
	{
		Destroy (gameObject, bulletLife);
	}

	void FixedUpdate () 
	{
		transform.Translate (Vector2.up*bulletSpeed);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "enemy") 
		{
			Instantiate (particleEnemy, transform.position, Quaternion.identity);
            other.GetComponent<enemyController>().TakeDamage(bulletDmg);
			Destroy (gameObject);
		}
	}
}
