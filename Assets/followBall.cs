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
       // if (playerRB.velocity.magnitude > .1f)
        //{
            //            Quaternion lookR = Quaternion.LookRotation (playerRB.velocity);
            Quaternion thisFrameLookR = Quaternion.LookRotation(playerRB.velocity);       //Making data type to represent rotation
            Quaternion realLookR = Quaternion.Slerp(lastFrameLookR, thisFrameLookR, 0.1f);//Moves camera in an arc that moves between two Quaternion based on float timeCount

            lastFrameLookR = realLookR;

            //        Vector3 rotatedOffset = lookR * _offset;
            Vector3 rotatedOffset = realLookR * offset;
            transform.position = player.transform.position + rotatedOffset; //following player by transforming camera
            transform.LookAt(player.transform.position);                    //Forward vector points towards the players position
        //}

    }
}