﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	public float speed;
	bool isMap;
    public int hp;
    public GameObject guiController;
    public playerGUIController guiScript;
    public Animator animator;
    private Vector3 pos;

	public float interactiveDist;
    public Transform originPoint;
    public Vector2 dir;
    public LayerMask interactiveObjects;

	void Start () 
	{
        dir = new Vector2();
        guiScript = guiController.GetComponent<playerGUIController>();
        animator.SetFloat("health", hp);
	}

	void FixedUpdate () 
	{
        pos = transform.position;
		//Movement
			if (Input.GetKey (KeyCode.A)) {
				transform.eulerAngles = new Vector3 (0f,0f,90);
				Vector2 translate = new Vector2 (transform.position.x - 1 * speed, transform.position.y);
				this.transform.position = translate;
                dir = Vector2.left;
            }
			if (Input.GetKey (KeyCode.D)) {
				transform.eulerAngles = new Vector3 (0f,0f,-90);
				Vector2 translate = new Vector2 (transform.position.x + 1 * speed, transform.position.y);
				this.transform.position = translate;
                dir = Vector2.right;
			}
			if (Input.GetKey (KeyCode.W)) {
				transform.eulerAngles = new Vector3 (0f,0f,0f);
				Vector2 translate = new Vector2 (transform.position.x, transform.position.y + 1 * speed);
				this.transform.position = translate;
                dir = Vector2.up;
			}
			if (Input.GetKey (KeyCode.S)) {
				transform.eulerAngles = new Vector3 (0f,0f,180f);
				Vector2 translate = new Vector2 (transform.position.x, transform.position.y - 1 * speed);
				this.transform.position = translate;
                dir = Vector2.down;
			}
            //Interaction
            RaycastHit2D intHit = Physics2D.Raycast(originPoint.position, dir, interactiveDist, interactiveObjects);
            if (intHit==true)
            {
                
            }

    }

    void LateUpdate()
    {
        if (pos != transform.position)
        {
            animator.SetBool("isWalking", true);
        }

        else
        {
            animator.SetBool("isWalking", false);
        }
    }

	void OnTriggerEnter2D(Collider2D other)
	{	
			Debug.Log ("WDEPLES WWW GOWNO");	
	}

    public void TakeDamage(int damage)
    {
        hp -= damage;
        guiScript.refreshBar(damage);
        if (hp<=0)
        {
           // Destroy(gameObject);
            GetComponent<Collider2D>().enabled = false;
            speed = 0;
        }
        animator.SetFloat("health", hp);
        Debug.Log(hp);
    }
		
}
