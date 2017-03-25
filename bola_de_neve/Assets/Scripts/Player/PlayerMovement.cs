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
        }
        else
        {
            if (!player.CanMove && inputDirection.sqrMagnitude <= velocityAutoStop)
            {
                Break();
            }
            else
            {
                body.AddForce(force * inputDirection, ForceMode.Acceleration);
            }
        }
        
	}

    void Break()
    {
        if (body.velocity.sqrMagnitude <= velocityAutoStop)
            body.velocity = Vector3.zero;
        else
        {
            body.AddForce(-body.velocity.normalized * stopForce);
        }
    }
}
