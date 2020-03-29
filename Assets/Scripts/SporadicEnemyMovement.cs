using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporadicEnemyMovement : MonoBehaviour
{
    public float speed;
    public List<Transform> BodyParts = new List<Transform>();
    public float mindistance;
    public float rotationSpeed;

    public GameObject bodyprefab;
    private GameObject bodyChildAttatched;
    public GameObject child;

    private float dis;
    private Transform curBodyPart;
    private Transform prevBodyPart;
   

    private int randomNumber;

    private void Start()
    {
        randomNumber = 3;
        Transform head = (Instantiate(bodyprefab, this.transform.position, this.transform.rotation) as GameObject).transform;
        head.SetParent(transform);
        BodyParts.Add(head);
        bodyChildAttatched = Instantiate(child, BodyParts[BodyParts.Count - 1].position, Quaternion.identity);
        bodyChildAttatched.transform.parent = head.transform;

        for (int i = 0; i < randomNumber; i++)
        {
            AddBodyPart();
        }
    }

    private void Update()
    {
        MoveSnake();
    }

    public void AddBodyPart()
    {
        Transform newpart = (Instantiate(bodyprefab, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation) as GameObject).transform;
        bodyChildAttatched = Instantiate(child, BodyParts[BodyParts.Count - 1].position, Quaternion.identity);
        bodyChildAttatched.transform.parent = newpart.transform;
        newpart.SetParent(transform);
        BodyParts.Add(newpart);
        Debug.LogError("Added Part");
    }

    private void MoveSnake()
    {
        float curspeed = speed;

        for (int i = 1; i < BodyParts.Count; i++)
        {
            curBodyPart = BodyParts[i];
            prevBodyPart = BodyParts[i - 1];

            dis = Vector3.Distance(prevBodyPart.position, curBodyPart.position);

            Vector3 newpos = prevBodyPart.position;

            newpos.y = BodyParts[0].position.y;

            float T = Time.deltaTime * dis / mindistance * curspeed;

            if (T > 0.5f)
                T = 0.5f;
            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newpos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, T);
        }
    }
}
