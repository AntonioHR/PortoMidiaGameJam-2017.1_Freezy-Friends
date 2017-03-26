using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Cannon cannon;

    public Bullet defaultBullet;

    public Rigidbody Body { get; private set; }
    public PlayerInput PlayerInput { get; private set; }

    public PlayerActionFSM fsm;

    public bool awaitLevelStart = false;

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
        if (awaitLevelStart)
            fsm.Push(new PlayerStartState(fsm));
        else
            fsm.Push(new PlayerIdleState(fsm));
	}
	
	void Update () {
        fsm.Current.Update();

        if (PlayerInput.pointedDirection.sqrMagnitude >= 0.1f)
            cannon.transform.rotation = Quaternion.LookRotation(PlayerInput.pointedDirection, Vector3.up);
    }

    public void ShootUp()
    {
        fsm.Current.ShootUp();
    }

    public void ShootDown()
    {
        fsm.Current.ShootDown();
    }

    public void OnBattleStart()
    {
        fsm.AdvanceTo(new PlayerIdleState(fsm));
    }
}
