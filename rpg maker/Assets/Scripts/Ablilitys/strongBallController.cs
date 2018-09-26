using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strongBallController : MonoBehaviour
{

    [SerializeField] private float multiplier;

    public void spawnBall(Vector3 playerPos, float chargLevel)
    {
        Instantiate(gameObject, playerPos, Quaternion.identity);
        Vector3 scaling;
        scaling = new Vector3(transform.localScale.x*multiplier,
        transform.localScale.y * multiplier, 0f);
        GameObject ballInstant = GameObject.FindGameObjectWithTag("powerBall");
        ballInstant.transform.localScale = scaling;
    }

}
