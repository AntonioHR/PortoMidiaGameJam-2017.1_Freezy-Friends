using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerAimState : PlayerActionState
{
    public PlayerAimState(PlayerActionFSM fsm) : base(fsm)
    {
    }

    public override bool CanMove
    {
        get
        {
            return false;
        }
    }

    public override void Update()
    {
        if(fsm.player.PlayerInput.pointedDirection.sqrMagnitude >= 0.1f)
            fsm.player.cannon.transform.rotation = Quaternion.LookRotation(fsm.player.PlayerInput.pointedDirection, Vector3.up);
    }

    public override void ShootDown()
    {
    }
    public override void ShootUp()
    {
        fsm.player.cannon.Shoot(fsm.player.defaultBullet);
        fsm.AdvanceTo(new PlayerIdleState(fsm));
    }
}
