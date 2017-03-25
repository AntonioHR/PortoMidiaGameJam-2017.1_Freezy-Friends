using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody body;
    
    Vector3 inputDirection;

    public float force = 3f;
    
	void Start () {
        body = GetComponent<Rigidbody>();
	}
	
	void Update () {
        inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	}

	void FixedUpdate(){
        body.AddForce(force * inputDirection);
	}
}
