using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Rigidbody myRig;
    public float speed = 5f;
    // Use this for initialization
	void Start () {
        myRig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float yVel = Input.GetAxis("Vertical");
        float xVel = Input.GetAxis("Horizontal");
        myRig.velocity = speed * (Vector3.forward * yVel + Vector3.right * xVel);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(myRig.velocity.normalized),0.4f);
        //transform.LookAt(transform.position + myRig.velocity.normalized);
    }
}
