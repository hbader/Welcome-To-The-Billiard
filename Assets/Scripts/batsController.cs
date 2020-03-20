using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class batsController: MonoBehaviour
{

    private UIManager manager;
    public float forceVariable;
    public Rigidbody rb;
    GameObject target;
    public float speed;
    Vector3 directionToTarget;
   // public GameObject explosion;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.Find("GameManager").GetComponent<UIManager>();
    }

    private void Update()
    {
            moveEnemy();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player")) {
            if (col.attachedRigidbody.velocity.magnitude > 5)
            {
                // Instantiate(explosion, transform.position, Quaternion.identity);
                //add kill counter maybe?
                col.attachedRigidbody.AddForce(rb.velocity * forceVariable);
                Destroy(gameObject);
                manager.updateScore(col.attachedRigidbody.velocity.magnitude);
            }
            else
            {
                // Instantiate(explosion, col.gameObject.transform.position, Quaternion.identity);
                Destroy(col.gameObject);
                target = null;
                manager.showGameOver();
            }
        }
    }

    void moveEnemy()
    {
        if(target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = 
                new Vector3(directionToTarget.x * speed*Time.deltaTime,
                0,
                directionToTarget.z * speed*Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector3.zero;
            this.StopAllCoroutines();
        }
    }
}

