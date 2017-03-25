using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour {
    public GameObject[] targets;

	// Use this for initialization
	void Start () {
		
	}

	void LateUpdate () {
        transform.position = Vector3.Lerp(transform.position, targets[0].transform.position, .1f);
	}
}
