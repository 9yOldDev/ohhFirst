using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour {

	public float speed;
	bool isMap;
    public int hp;
    public GameObject strongBall;
    private strongBallController powerBall;
    public GameObject guiController;
    public Text[] strongBallText = new Text[1];
    public playerGUIController guiScript;
    public Animator animator;
    private Vector3 pos;

    [SerializeField] private float strongBallCooldown;
    private float strongBallActCooldown;
    [SerializeField] private float strongBallMaxCharg;
    private float strongBallActCharg;

	public float interactiveDist;
    public Transform originPoint;
    public Vector2 dir;
    public LayerMask interactiveObjects;

    void Start()
    {
        dir = new Vector2();
        guiScript = guiController.GetComponent<playerGUIController>();
        animator.SetFloat("health", hp);

        strongBallActCooldown = strongBallCooldown;
        strongBallActCharg = 0;
        powerBall = strongBall.GetComponent<strongBallController>();
    }

    void FixedUpdate()
    {
        pos = transform.position;
        //Movement
        if (hp > 0)
        {
            GetComponent<Collider2D>().enabled = true;
            if (Input.GetKey(KeyCode.A))
            {
                transform.eulerAngles = new Vector3(0f, 0f, 90);
                Vector2 translate = new Vector2(transform.position.x - 1 * speed, transform.position.y);
                this.transform.position = translate;
                dir = Vector2.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.eulerAngles = new Vector3(0f, 0f, -90);
                Vector2 translate = new Vector2(transform.position.x + 1 * speed, transform.position.y);
                this.transform.position = translate;
                dir = Vector2.right;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                Vector2 translate = new Vector2(transform.position.x, transform.position.y + 1 * speed);
                this.transform.position = translate;
                dir = Vector2.up;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.eulerAngles = new Vector3(0f, 0f, 180f);
                Vector2 translate = new Vector2(transform.position.x, transform.position.y - 1 * speed);
                this.transform.position = translate;
                dir = Vector2.down;
            }
            //Interaction
            RaycastHit2D intHit = Physics2D.Raycast(originPoint.position, dir, interactiveDist, interactiveObjects);
            if (intHit == true)
            {
                
            }

            //abilitys
                //strongBall
            if (strongBallActCooldown>0)
            {
                strongBallText[0].text =Mathf.Floor(strongBallActCooldown).ToString();
                strongBallActCooldown -= Time.deltaTime;
            }

            else if(strongBallActCooldown<=0)
            {
                bool pressed = false;
                if (Input.GetMouseButton(1))
                {                    
                    strongBallActCharg += Time.deltaTime;
                    pressed = true;
                }

                if (!Input.GetMouseButton(1) && strongBallActCharg>0  || strongBallActCharg>=strongBallMaxCharg)
                {           
                    powerBall.spawnBall(transform.position, strongBallActCharg, this.transform.rotation);
                    strongBallActCharg = 0;
                    strongBallActCooldown = strongBallCooldown;
                }
            }

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
			Debug.Log (oter);	
	}

    public void TakeDamage(int damage)
    {
        hp -= damage;
        guiScript.refreshBar(damage);
        if (hp<=0)
        {
            GetComponent<Collider2D>().enabled = false;
            speed = 0;
        }
        animator.SetFloat("health", hp);
        Debug.Log(hp);
    }
		
}
