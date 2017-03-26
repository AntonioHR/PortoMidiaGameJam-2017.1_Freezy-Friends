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
            var direction = (closest.transform.position - transform.position).normalized;
            if(Vector3.Dot(direction, body.velocity) > 0)
                body.AddForce( direction * force * (.5f + detector.EaseFactor(closest)), ForceMode.Acceleration);
        }
	}
}
