using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowObj : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate(){
		transform.position = Vector3.Lerp(transform.position, target.transform.position, 1f);
	}
}
