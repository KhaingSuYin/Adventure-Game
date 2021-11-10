using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
	public int speed = 10;
	Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate()
    {
        float zSpeed = Input.GetAxis("Vertical")*speed;
		float xSpeed = Input.GetAxis("Horizontal")*speed;
		rb.AddForce(new Vector3(xSpeed,0,zSpeed));
    }
}
