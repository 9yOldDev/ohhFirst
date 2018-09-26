using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strongBallController : MonoBehaviour
{

    [SerializeField] private float multiplier;

    public void spawnBall(Vector3 playerPos, float chargLevel,Quaternion rot)
    {
        Instantiate(gameObject, playerPos, rot);
        Vector3 scaling;
        scaling = new Vector3(transform.localScale.x*multiplier*chargLevel,
        transform.localScale.y * multiplier * chargLevel, 0f);
        GameObject ballInstant = GameObject.FindGameObjectWithTag("powerBall");
        ballInstant.transform.localScale = scaling;
        ballInstant.GetComponent<strongBallControllerMovement>().speed = 0.2f * chargLevel;
    }

}
