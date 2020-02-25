using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followBall : MonoBehaviour
{

public GameObject player;
public Vector3 offset;

Quaternion lastFrameLookR;
Quaternion thisFrameLookR;

Rigidbody playerRB;

void Start()
{
    playerRB = player.GetComponent<Rigidbody>();
}

void LateUpdate()
{
    if (playerRB.velocity.sqrMagnitude > .1f)
    {
        //            Quaternion lookR = Quaternion.LookRotation (playerRB.velocity);
        Quaternion thisFrameLookR = Quaternion.LookRotation(playerRB.velocity);
        Quaternion realLookR = Quaternion.Slerp(lastFrameLookR, thisFrameLookR, 0.1f);

        lastFrameLookR = realLookR;

        //        Vector3 rotatedOffset = lookR * _offset;
        Vector3 rotatedOffset = realLookR * offset;
        transform.position = player.transform.position + rotatedOffset;
        transform.LookAt(player.transform.position);
    }
}
 
}