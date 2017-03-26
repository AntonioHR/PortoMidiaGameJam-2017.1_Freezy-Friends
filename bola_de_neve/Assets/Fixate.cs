using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixate : MonoBehaviour {
    Vector3 startPos;
    Quaternion startRot;

    public bool pos;
    public bool rot;
    void Start () {
        startPos = transform.position;
        startRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if(pos) {
            transform.position = startPos;
        }
        if(rot) {
            transform.rotation = startRot;
        }
	}
}
