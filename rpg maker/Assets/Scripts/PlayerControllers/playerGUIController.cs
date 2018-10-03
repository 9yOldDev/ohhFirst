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

    public Text coinsText;
    public int coins;

    private int maxHp;
    private int hp; //from player

    void Start()
    {
        coins = 0;
        coinsText.text = coins.ToString();
        playerScript = player.GetComponent<playerMovement>();
        maxHp = playerScript.hp;
        this.hp = playerScript.hp;
        scaleByDamage = new Vector3(transform.localScale.x / hp, 0f, 0f);
        refreshBar(0);
    }

    public void refreshBar(int damage)
    {
        if (hp>0)
        {
            string hpShow;
            hpShow = playerScript.hp.ToString() + "/" + maxHp.ToString();
            transform.localScale -= scaleByDamage * damage;
            hpText.text = hpShow;
        }              
    }

    public void addHealth(int healValue)
    {
        if (playerScript.hp  + healValue <= maxHp) //hp -> 2 maxHp -> 5 healValue -> 2
        {
            Debug.Log("Dodano max");
            playerScript.hp += healValue;
            refreshBar(-healValue);
        }

        else if(playerScript.hp + healValue > maxHp)
        {
            Debug.Log("Dodano mniej niz max");
            int howMuch = maxHp - playerScript.hp;
            playerScript.hp += howMuch;
            refreshBar(-howMuch);
        }
    }

    public void addCoin(int value)
    {
        coins += value;
        coinsText.text = coins.ToString();
    }

}
