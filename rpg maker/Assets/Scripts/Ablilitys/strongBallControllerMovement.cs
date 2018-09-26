using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strongBallControllerMovement : MonoBehaviour {

    public float speed;
    public float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

	void FixedUpdate()
    {
        transform.Translate(Vector2.up*speed);
    }
}
