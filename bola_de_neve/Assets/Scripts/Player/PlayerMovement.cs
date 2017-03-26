using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour {
    PlayerInput input;
    Player player;
    Rigidbody body;

    public float force = 3f;

    public float stopForce = 5f;
    public float velocityAutoStop = .1f;

    public float velocityCap = 2;

    void Start () {
        body = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>();
        player = GetComponent<Player>();
	}
	

	void FixedUpdate(){
        var inputDirection = input.pointedDirection;
        if (!player.CanMove)
        {
            Break();
        } else if (inputDirection.sqrMagnitude <= velocityAutoStop) {
            Break();
        } else  {
            var forceVec = force * inputDirection;
            if (body.velocity.magnitude > velocityCap && Vector3.Dot(forceVec, body.velocity) > 0)
            {
                var forceComponent = Vector3.Project(forceVec, body.velocity);
                forceVec = forceVec - forceComponent;
            }
            body.AddForce(forceVec, ForceMode.Acceleration);
        }

        if (inputDirection.sqrMagnitude >= 0.1f)
            transform.rotation = Quaternion.LookRotation(inputDirection, Vector3.up);

    }

    void Break()
    {
        if (!player.CanBreak)
        {
            Debug.Log("Not Breaking!!");
            return;
        }

        if (body.velocity.sqrMagnitude <= velocityAutoStop)
            body.velocity = Vector3.zero;
        else
        {
            body.AddForce(-body.velocity.normalized * stopForce);
        }
    }
}
