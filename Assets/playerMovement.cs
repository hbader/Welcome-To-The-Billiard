using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float vert = Input.GetAxis("Vertical");
        Vector3 inputV = new Vector3(Input.GetAxis("Horizontal"), 0.0f, vert);
        //Debug.Log("vert=" + vert + " mag=" + rb.velocity.magnitude);
        Vector3 movement = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * inputV;
        if (rb.velocity.magnitude > 0.1f || vert >= 0) { 
            rb.AddForce(movement * speed * Time.deltaTime);
        } 
    }
}
