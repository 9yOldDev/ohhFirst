using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerGUIController : MonoBehaviour {

    public GameObject player;
    private playerMovement playerScript;
    public GameObject healthBar;
    public Text hpText;
    private Vector3 scaleByDamage;
    private int maxHp;
    private int hp; //from player

    void Start()
    {
        playerScript = player.GetComponent<playerMovement>();
        maxHp = playerScript.hp;
        this.hp = playerScript.hp;
        scaleByDamage = new Vector3(transform.localScale.x / hp, 0f, 0f);
        refreshBar(0);
    }

    public void refreshBar(int damage)
    {
        string hpShow;
        hpShow = playerScript.hp.ToString() + "/" + maxHp.ToString();
        transform.localScale -= scaleByDamage * damage;
        hpText.text = hpShow;
        
    }
}
