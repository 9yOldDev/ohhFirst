using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

    //raycast
	public Transform originPoint;	
	Vector2 dir;
	public float rayDist;
    public LayerMask whoShot;
    //weapon variables
    public GameObject weapon;
	public float fireRate;
	private float actTime;
	public aiWeaponController instance;
    public GameObject HealthBar;
    public HealthBarController healthBar;
    //----------------\\
	private int state;
    //0=patrol; 1=combat;
    //patrol variables
    public float rotAngle;
    public float rotSpeed;
    [SerializeField] private bool rotSide;
    //false-left true-rigt
    //itemLoot
    [SerializeField] private GameObject[] items = new GameObject[2];
    //other
    public int hp;

	void Start ()
    {
		instance = weapon.GetComponent<aiWeaponController> ();
        healthBar = HealthBar.GetComponent<HealthBarController>();
        state = 0;
        rotSide = false;
	}

	void FixedUpdate () 
	{
		//raycasting
		RaycastHit2D hit = Physics2D.Raycast (originPoint.position, Vector2.down, rayDist, whoShot);
		if (hit==true) 
		{
			if (hit.collider.tag == "Player") 
			{
				state = 1;	
				Debug.Log (hit.collider.name);
			}
		}

		//combat

		if (state==1) 
		{
			if (actTime<=0) 
			{
				instance.shoot ();	
				actTime = fireRate;
				state = 0;
			}

		}

		if (actTime>0) 
		{
			actTime -= Time.deltaTime;
		}
	}

    public void TakeDamage(int damage)
    {
        hp -= damage;
        healthBar.showDamage(damage);
        if (hp<=0)
        {
            lootItems();
            Destroy(gameObject);
        }
        Debug.Log("DamageTaken");
    }

    private void lootItems()
    {
        int witch = Random.Range(0, items.Length-1);
        Instantiate(items[0], transform.position, Quaternion.identity);
    }
}
