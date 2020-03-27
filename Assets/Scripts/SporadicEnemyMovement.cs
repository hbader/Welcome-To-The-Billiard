using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporadicEnemyMovement : MonoBehaviour
{
    public float speed;
    public float mindistance;
    public float rotationSpeed;

    public GameObject bodyprefab;
    private GameObject bodyChildAttatched;
    public GameObject child;

    private float dis;
    private Transform curBodyPart;
    private Transform prevBodyPart;
   


    private void Start()
    {
        Transform head = (Instantiate(bodyprefab, this.transform.position, this.transform.rotation) as GameObject).transform;
        head.SetParent(transform);
        bodyChildAttatched = Instantiate(child, head.position, Quaternion.identity);
        bodyChildAttatched.transform.parent = head.transform;

    }

    private void Update()
    {
        MoveSnake();
    }


    private void MoveSnake()
    {
        float curspeed = speed;

        for (int i = 1; i < 2; i++)
        {

            dis = Vector3.Distance(prevBodyPart.position, curBodyPart.position);

            Vector3 newpos = prevBodyPart.position;


            float T = Time.deltaTime * dis / mindistance * curspeed;

            if (T > 0.5f)
                T = 0.5f;
            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newpos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, T);
        }
    }
}
