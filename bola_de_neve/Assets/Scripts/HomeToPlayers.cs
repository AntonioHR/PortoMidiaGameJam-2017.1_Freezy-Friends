using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HomeToPlayers : MonoBehaviour {
    PlayerDetector detector;
    Rigidbody body;

    public float force;


	void Start () {
        detector = GetComponentInChildren<PlayerDetector>();
        body = GetComponent<Rigidbody>();
	}
	
	void Update () {
        var closest = detector.Closest;
        if(closest != null)
        {
            body.AddForce((closest.transform.position - transform.position).normalized * force * (.5f + detector.EaseFactor(closest)), ForceMode.Acceleration);
        }
	}
}
