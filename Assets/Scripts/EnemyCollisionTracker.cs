using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCollisionTracker: MonoBehaviour
{

    private UIManager manager;
    public float forceVariable;

    private Rigidbody rb;
    private Vector3 velocity;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<UIManager>();
        rb = this.gameObject.GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player")) {
            if (col.attachedRigidbody.velocity.magnitude > 5)
            {
                if (this.gameObject.name.Contains("Grower"))
                {
                    velocity = new Vector3(-col.attachedRigidbody.velocity.x,0f, -col.attachedRigidbody.velocity.z);
                }
                else
                {
                    velocity = rb.velocity;
                }
                // Instantiate(explosion, transform.position, Quaternion.identity);
                //add kill counter maybe?
                col.attachedRigidbody.AddForce(velocity * forceVariable);
                if (gameObject.transform.parent == null)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    Destroy(this.transform.parent.gameObject);
                }
                
                manager.updateScore(col.attachedRigidbody.velocity.magnitude);
            }
            else
            {
                // Instantiate(explosion, col.gameObject.transform.position, Quaternion.identity);
                Destroy(col.gameObject);
                manager.showGameOver();
            }
        }
    }

}

