using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Cannon cannon;

    public Bullet defaultBullet;

    public Rigidbody Body { get; private set; }
    public PlayerInput PlayerInput { get; private set; }

    public PlayerActionFSM fsm;

    public bool CanMove
    {
        get
        {
            return fsm.Current.CanMove;
        }
    }


	void Start () {
        Body = GetComponent<Rigidbody>();
        PlayerInput = GetComponent<PlayerInput>();
        fsm = new PlayerActionFSM(this);
        fsm.Push(new PlayerIdleState(fsm));
	}
	
	void Update () {
        fsm.Current.Update();
	}

    public void ShootUp()
    {
        fsm.Current.ShootUp();
    }

    public void ShootDown()
    {
        fsm.Current.ShootDown();
    }
}
