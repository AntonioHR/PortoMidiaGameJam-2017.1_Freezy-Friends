using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Cannon cannon;

    public BulletData defaultBullet;

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
        cannon.owner = this;
        Body = GetComponent<Rigidbody>();
        PlayerInput = GetComponent<PlayerInput>();
        fsm = new PlayerActionFSM(this);
        if (awaitLevelStart)
            fsm.Push(new PlayerStartState(fsm));
        else
            fsm.Push(new PlayerIdleState(fsm));
	}

    internal void HitBy(Bullet bullet)
    {
        var direction = (transform.position - bullet.transform.position).normalized;
        Body.AddForce(direction * bullet.settings.Impact, ForceMode.Impulse);
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

    public static Player GetFromCollider(Collider col)
    {
        var player = col.GetComponent<Player>();
        var body = col.GetComponent<PlayerBody>();
        if (body != null && player == null)
        {
            player = body.owner;
        }
        return player;
    }
}
