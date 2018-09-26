using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strongBallControllerMovement : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public ParticleSystem particle;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

	void FixedUpdate()
    {
        transform.Translate(Vector2.up*speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "enemy")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            other.GetComponent<enemyController>().TakeDamage(Mathf.FloorToInt(speed*30));
            Destroy(gameObject);
        }
    }
}
