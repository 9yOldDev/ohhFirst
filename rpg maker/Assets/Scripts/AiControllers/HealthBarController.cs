using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour {

    [SerializeField]enemyController enemyStats;
    private int hpToShow;
    private int hpB;
    public GameObject enemyParent;
    public Transform barSprite;
    private Vector3 scaleByOneDmg;

	void Start ()
    {
        enemyStats = enemyParent.GetComponent<enemyController>();
        hpB = enemyStats.hp;
        scaleByOneDmg = new Vector3(barSprite.localScale.x/hpB/40, 0f, 0f);
	}
	public void showDamage(int scale)
    {
        transform.localScale -= scaleByOneDmg*scale;
	}
}
